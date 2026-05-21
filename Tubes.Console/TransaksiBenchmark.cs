using BenchmarkDotNet.Attributes;
using Tubes.Core;

namespace Tubes.ConsoleApp
{
    [MemoryDiagnoser]
    public class TransaksiBenchmark
    {
        private Cart _tempCart;
        private string paymentType;

        //Test dari beberapa ukuran riwayat
        //Penyusutan jumlah paramater dari [10, 50] (laptop hampir meledak) :v
        [Params(1, 5, 10)] 
        public int TransactionCount;

        [GlobalSetup] 
        public void Setup() 
        {
            Transaksi.TestFile();
            Transaksi.ClearTransaksi();

            _tempCart = new Cart();
            paymentType = "Cash";
            for (int i = 0; i < TransactionCount; i++)
            {
                Transaksi.TambahTransaksi(_tempCart, paymentType);
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
            Transaksi.TambahTransaksi(_tempCart, paymentType);
        }

    }
}

