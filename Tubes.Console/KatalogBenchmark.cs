using BenchmarkDotNet.Attributes;
using Tubes.Core;

namespace Tubes.ConsoleApp
{
    [MemoryDiagnoser]
    public class KatalogBenchmark
    {
        // GlobalSetup untuk load data SEKALI SEBELUM semua benchmark dijalankan
        [GlobalSetup]
        public void Setup()
        {
            Katalog.LoadData();
        }
        [Benchmark]
        public void SearchSuccessTest()
        {
            // Mencari barang yang ada
            Katalog.cariBarang("Buku");
        }
        [Benchmark]
        public void SearchFailTest()
        {
            try
            {
                Katalog.cariBarang("asdadsds");
            }
            catch
            {
                // Tangkap error agar benchmark tidak berhenti
            }
        }
    }
}
