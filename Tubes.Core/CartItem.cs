using System.ComponentModel;

namespace Tubes.Core
{
    public class CartItem
    {
        // untuk DataGridView
        [Browsable(false)]
        public Barang barang { get; set; }

        public string namaBarang
        {
            get { return barang.nama; }
        }
        public int hargaBarang
        {
            get { return barang.harga; }
        }

        public int jumlah { get; set; }
        public int subTotal
        {
            get { return barang.harga * jumlah; }
        }

        public CartItem(Barang barang, int jumlah)
        {
            this.barang = barang;
            this.jumlah = jumlah;
        }

        public CartItem() 
        {
            barang = new Barang();
        }
    }
}