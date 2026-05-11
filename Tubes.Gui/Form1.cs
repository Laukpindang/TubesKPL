using Tubes.Core;

namespace Tubes.Gui
{
    public partial class Form1 : Form
    {
        Cart<Barang> cart;
        public Form1()
        {
            InitializeComponent();
            this.cart = new Cart<Barang>();
            listBarang.DataSource = cart.GetBarang();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string namaBarang = inputBarang.Text;
            int jumlahBarang = (int)inputJumlah.Value;

            if (!string.IsNullOrEmpty(namaBarang))
            {
                // TODO: Implementasi logika untuk menambahkan barang ke cart (bisa cek console untuk referensi)
                Barang barang = Katalog.cariBarang(namaBarang);
            }
            else
            {
                MessageBox.Show("Nama barang tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
