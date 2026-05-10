using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tubes.Core
{
    public static class Katalog
    {
        public static List<Barang> listBarang { get; set; }
        public static void LoadData()
        {
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseFolder, "dataBarang.json");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File json tidak ditemukan di: {filePath}");
            }
            string jsonString = File.ReadAllText(filePath);
            DataKatalog jsonData = JsonSerializer.Deserialize<DataKatalog>(jsonString) ?? throw new JsonException("Error ketika deserialize dataBarang.json");
            listBarang = jsonData.barang;
        }
        public static Barang cariBarang(string nama)
        {
            if (listBarang == null) return null;
            Barang barang = listBarang.FirstOrDefault(b => b.nama.Equals(nama, StringComparison.OrdinalIgnoreCase)) ?? throw new KeyNotFoundException($"Barang dengan nama {nama} tidak ditemukan");
            return barang;
        }
        public static List<Barang> GetAllBarang()
        {
            return listBarang;
        }
    }
    class DataKatalog
    {
        public List<Barang> barang { get; set; }
    }
}
