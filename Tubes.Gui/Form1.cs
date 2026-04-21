using Tubes.Core;

namespace Tubes.Gui
{
    public partial class Form1 : Form
    {
        Cart cart;
        public Form1()
        {
            InitializeComponent();
            this.cart = new Cart();
            listBarang.DataSource = cart.GetBarang();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string namaBarang = inputBarang.Text;
            int jumlahBarang = (int)inputJumlah.Value;

            if (!string.IsNullOrEmpty(namaBarang))
            {
                cart.TambahBarang(new Barang(namaBarang), jumlahBarang);
            }
            else
            {
                MessageBox.Show("Nama barang tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
