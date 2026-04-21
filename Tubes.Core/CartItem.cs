using System.ComponentModel;

namespace Tubes.Core
{
    public class CartItem
    {
        // untuk DataGridView
        [Browsable(false)]
        public Barang barang { get; set; }

        public string NamaBarang
        {
            get { return barang.nama; }
        }

        public int Jumlah { get; set; }

        public CartItem(Barang barang, int jumlah)
        {
            this.barang = barang;
            this.Jumlah = jumlah;
        }
    }
}