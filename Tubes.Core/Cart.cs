using System.ComponentModel;

namespace Tubes.Core
{
    public class Cart<T> where T : IBarang
    {
        private BindingList<CartItem<T>> barang ;

        public Cart()
        {
            barang = new BindingList<CartItem<T>>();
        }

        public void TambahBarang(T b, int jumlah)
        {
            var itemDitemukan = barang.FirstOrDefault(item => item.barang.nama == b.nama);
            if (itemDitemukan != null)
            {
                itemDitemukan.jumlah += jumlah;

                // update datagrid
                int index = barang.IndexOf(itemDitemukan);
                barang.ResetItem(index);
            }
            else
            {
                barang.Add(new CartItem<T>(b, jumlah));
            }
        }

        public int TotalHarga()
        {
            int total = 0;
            foreach (var item in barang)
            {
                total += item.jumlah * item.barang.harga;
            }
            return total;
        }

        public BindingList<CartItem<T>> GetBarang()
        {
            return barang;
        }

        public void ClearCart()
        {
            barang.Clear();
        }
    }
}