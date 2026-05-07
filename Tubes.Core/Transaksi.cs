using System.ComponentModel;
using System.Text.Json;

namespace Tubes.Core
{
    public class Transaksi
    {
        private static readonly string _filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logTransaksi.json");

        public Dictionary<string, DetailTransaksi> ListTransaksi = new Dictionary<string, DetailTransaksi>();

        public void loadTransaksi()
        {
            if (!File.Exists(_filepath))
            {
                File.WriteAllText(_filepath, "{}");
            }
            string jsonString = File.ReadAllText(_filepath);
            ListTransaksi = JsonSerializer.Deserialize<Dictionary<string, DetailTransaksi>>(jsonString) ?? new Dictionary<string, DetailTransaksi>();
        }

        public void saveTransaksi() 
        { 
            string jsonString = JsonSerializer.Serialize(ListTransaksi);
            File.WriteAllText(_filepath, jsonString);
        }

        public void TambahTransaksi(Cart keranjang) 
        {
            DetailTransaksi detail = new DetailTransaksi(keranjang);
            ListTransaksi.Add(MembuatKode(keranjang), detail);

            saveTransaksi();
        }

        public string MembuatKode(Cart keranjang)
        {
            return $"{DateTime.Now:yyyyMMdd} - {ListTransaksi.Count}";
        }

    }

    public class DetailTransaksi
    {
        public string tanggal { get; init; }
        public string waktu { get; init; }
        public BindingList<CartItem> barang { get; init; }
        public int total { get; init; }

        public DetailTransaksi(Cart keranjang) 
        {
            tanggal = DateTime.Now.ToString("yyyyMMdd");
            waktu = DateTime.Now.ToString("HH:mm:ss");
            barang = keranjang.GetBarang();
            total = TotalHarga(keranjang);
        }

        public int TotalHarga(Cart keranjang)
        {
            int total = 0;
            foreach(CartItem item in keranjang.GetBarang())
            {
                total += item.subTotal;
            }

            return total;
        }

    }
}
