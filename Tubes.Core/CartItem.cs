using System.ComponentModel;

namespace Tubes.Core
{
    public class CartItem<T> where T : IBarang
    {
        // untuk DataGridView
        [Browsable(false)]
        public T barang { get; set; }

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

        public CartItem(T barang, int jumlah)
        {
            this.barang = barang;
            this.jumlah = jumlah;
        }
    }
}