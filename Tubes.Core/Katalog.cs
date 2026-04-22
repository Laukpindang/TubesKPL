using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tubes.Core
{
    public static class Katalog
    {
        public static List<Barang> listBarang { get; set; }
        public static void LoadData()
        {
            string jsonString = File.ReadAllText("Tubes.core/dataBarang.json");
            DataKatalog jsonData = JsonSerializer.Deserialize<DataKatalog>(jsonString);
            listBarang = jsonData.barang;
        }
        public static Barang cariBarang(string nama)
        {
            if (listBarang == null) return null;
            return listBarang.FirstOrDefault(b => b.nama.Equals(nama, StringComparison.OrdinalIgnoreCase));
        }
        public static List<Barang> GetAllBarang()
        {
            return listBarang;
        }
    }
    class DataKatalog
    {
        public List<Barang> barang { get;  set; }
    }
}
