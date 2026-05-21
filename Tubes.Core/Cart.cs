using System.ComponentModel;

namespace Tubes.Core
{
    public class Cart
    {
        private BindingList<CartItem> barang ;

        public Cart()
        {
            barang = new BindingList<CartItem>();
        }

        public void TambahBarang(Barang b, int jumlah)
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
                barang.Add(new CartItem(b, jumlah));
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

        public BindingList<CartItem> GetBarang()
        {
            return barang;
        }

        public void ClearCart()
        {
            barang.Clear();
        }
    }
}