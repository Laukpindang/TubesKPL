namespace Tubes.Core
{
    public class Barang
    {
        public int id { get; set; }
        public string nama { get; set; }
        public int harga { get; set; }
        public int stok { get; set; }
        public Barang() { }
        public Barang(int id, string nama, int harga, int stok) 
        {
            this.id = id;
            this.nama = nama;
            this.harga = harga;
            this.stok = stok;
        }
        public void KurangiStok(int jumlah)
        {
            if (jumlah > stok)
            {
                throw new InvalidOperationException("Stok tidak cukup");
            }
            stok -= jumlah;
        }
    }
}
