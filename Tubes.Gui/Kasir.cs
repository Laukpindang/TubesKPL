using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using Tubes.Core;

namespace Tubes.Gui
{
    public partial class Kasir : Form
    {
        private readonly KasirService _service;
        public Kasir()
        {
            InitializeComponent();
            _service = new KasirService(new Cart());
            listBarang.DataSource = _service.GetDaftarKeranjang();
            if (Session.CurrentUser != null)
            {
                lblNamaKasir.Text = $"Kasir Bertugas: {Session.CurrentUser.Username}";
            }

            inputBarang.DataSource = Katalog.GetAllBarang();
            inputBarang.DisplayMember = "nama";
            inputBarang.ValueMember = "nama";

            inputPayment.DataSource = PaymentMethod.getPaymentType();
            inputPayment.DisplayMember = "";
            inputPayment.ValueMember = "";

            _service.GetDaftarKeranjang().ListChanged += PerbaruiTotalHarga;
        }
        private void PerbaruiTotalHarga(object sender, ListChangedEventArgs e)
        {
            int total = _service.HitungTotalBelanja();
            lblTotalHarga.Text = $"Total: Rp {total}";
        }

        private void UpdateTotalBayar()
        {
            if (!(inputPayment.SelectedItem == PaymentMethod.getPaymentType()[0]))
            {
                inputUangBayar.Enabled = false;
                inputUangBayar.Text = _service.HitungTotalBelanja().ToString();
            }
        }

        private void inputPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((inputPayment.SelectedItem == PaymentMethod.getPaymentType()[0]))
            {
                inputUangBayar.Enabled = true;
                inputUangBayar.Text = "0";
            }
            else
            {
                UpdateTotalBayar();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string namaBarang = inputBarang.Text;
            int jumlahBarang = (int)inputJumlah.Value;

            OperationResult res = _service.ProsesTambahBarang(namaBarang, jumlahBarang);
            if (!res.IsSuccess)
            {
                MessageBox.Show(
                    res.ErrorMessage,
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                // CLEAN CODE
                UpdateTotalBayar();
                inputJumlah.Value = 0;
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            // Ambil input uang dari textbox (pastikan di-convert ke integer)
            if (!int.TryParse(inputUangBayar.Text, out int uangBayar))
            {
                MessageBox.Show("Mohon masukkan angka uang yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult;

            switch (inputPayment.Text)
            {
                case "E_Wallet":
                    dialogResult = QRCode.Show();
                    break;
                case "Kartu":
                    dialogResult = Kartu.Show();
                    break;
                default:
                    break;
            }

            // Serahkan ke Service untuk diproses
            OperationResult hasil = _service.ProsesPembayaran(uangBayar, inputPayment.Text);

            if (!hasil.IsSuccess)
            {
                MessageBox.Show(hasil.ErrorMessage, "Pembayaran Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Pembayaran berhasil!", "Pembayaran Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                inputUangBayar.Value = 0;
            }
        }
    }
}
