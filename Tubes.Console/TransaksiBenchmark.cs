using BenchmarkDotNet.Attributes;
using Tubes.Core;

namespace Tubes.ConsoleApp
{
    [MemoryDiagnoser]
    public class TransaksiBenchmark
    {
        private Cart<Barang> _tempCart;

        //Test dari beberapa ukuran riwayat
        //Penyusutan jumlah paramater dari [10, 50] (laptop hampir meledak) :v
        [Params(1, 5, 10)] 
        public int TransactionCount;

        [GlobalSetup] 
        public void Setup() 
        {
            Transaksi.TestFile();
            Transaksi.ClearTransaksi();

            _tempCart = new Cart<Barang>();
            for (int i = 0; i < TransactionCount; i++)
            {
                Transaksi.TambahTransaksi(_tempCart);
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            Transaksi.ClearTransaksi();
        }

        [Benchmark]
        public void BenchmarkLoad()
        {
            //Tes kecepatan membaca
            Transaksi.LoadTransaksi();
        }

        [Benchmark]
        public void FileManipulationTest()
        {
            //Tes dampak penambahan riwayat baru
            Transaksi.TambahTransaksi(_tempCart);
        }

    }
}

