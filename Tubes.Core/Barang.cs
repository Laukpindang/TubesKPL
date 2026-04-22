namespace Tubes.Core
{
    public class Barang
    {
        public int id { get; set; }
        public string nama { get; set; }
        public int harga { get; set; }
        public Barang() { }
        public Barang(int id, string nama, int harga) 
        {
            this.id = id;
            this.nama = nama;
            this.harga = harga;
        }
    }
}
