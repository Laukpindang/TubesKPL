using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tubes.Core
{
    public class Transaksi
    {
        [JsonIgnore]
        private static string _filepath = Path.Combine(
                                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                            "DataTubesKPL",
                                            "logTransaksi.json");

        [JsonPropertyName("listTransaksi")]
        public static Dictionary<string, DetailTransaksi> ListTransaksi = new Dictionary<string, DetailTransaksi>();

        public static void TestFile()
        {
            _filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                            "DataTubesKPL",
                                            "logTransaksiTest.json");
        }

        public static void LoadTransaksi()
        {
            string? directory = Path.GetDirectoryName(_filepath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filepath))
            {
                File.WriteAllTextAsync(_filepath, "{}");
            }

            string jsonString = File.ReadAllText(_filepath);

            if (string.IsNullOrEmpty(jsonString))
            {
                ListTransaksi = new Dictionary<string, DetailTransaksi>();
            }
            else
            {
                ListTransaksi = JsonSerializer.Deserialize<Dictionary<string, DetailTransaksi>>(jsonString) ?? new Dictionary<string, DetailTransaksi>();
            }
        }

        public static void saveTransaksi()
        {
            string jsonString = JsonSerializer.Serialize(ListTransaksi);
            File.WriteAllTextAsync(_filepath, jsonString);
        }

        public static void TambahTransaksi(Cart<Barang> keranjang)
        {
            DetailTransaksi detail = new DetailTransaksi(keranjang);
            ListTransaksi.Add(MembuatKode(detail), detail);

            saveTransaksi();
            LoadTransaksi();
        }

        public static void ClearTransaksi()
        {
            ListTransaksi.Clear();
            saveTransaksi();
        }

        public static string MembuatKode(DetailTransaksi detail)
        {
            return $"{detail.tanggal}{ListTransaksi.Count + 1:D4}";
        }

    }

    public class DetailTransaksi
    {
        [JsonPropertyName("tanggal")]
        public string tanggal { get; init; }
        [JsonPropertyName("waktu")]
        public string waktu { get; init; }
        [JsonPropertyName("barang")]
        public BindingList<CartItem<Barang>> barang { get; init; }
        [JsonPropertyName("total")]
        public int total { get; init; }

        public DetailTransaksi() { }

        public DetailTransaksi(Cart<Barang> keranjang)
        {
            tanggal = DateTime.Now.ToString("yyyyMMdd");
            waktu = DateTime.Now.ToString("HH:mm:ss");
            barang = keranjang.GetBarang();
            total = keranjang.TotalHarga();
        }


    }
}
