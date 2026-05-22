using BenchmarkDotNet.Attributes;
using Tubes.Core;

namespace Tubes.ConsoleApp
{
    [MemoryDiagnoser]
    public class TransaksiBenchmark
    {
        private Cart<Barang> _tempCart;
        private string paymentType;
        private TransaksiStateMachine _sm;

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
            paymentType = "Cash";
            for (int i = 0; i < TransactionCount; i++)
            {
                Transaksi.TambahTransaksi(_tempCart, paymentType);
            }

            _sm = new TransaksiStateMachine();
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

        // --- Benchmark StateMachine ---

        [Benchmark]
        public void BenchmarkStartBelanja()
        {
            _sm.reset();
            _sm.StartBelanja();
        }

        [Benchmark]
        public void BenchmarkCheckout()
        {
            _sm.reset();
            _sm.StartBelanja();
            _sm.Checkout();
        }

        [Benchmark]
        public void BenchmarkFullFlow()
        {
            _sm.reset();
            _sm.StartBelanja();
            _sm.Checkout();
            _sm.Bayar();
        }

        [Benchmark]
        public void BenchmarkBatal()
        {
            _sm.reset();
            _sm.StartBelanja();
            _sm.Batal();
        }

        [Benchmark]
        public void BenchmarkReset()
        {
            _sm.reset();
        }

        [Benchmark]
        public void BenchmarkTambahBarangLagi()
        {
            _sm.reset();
            _sm.StartBelanja();
            _sm.Checkout();
            _sm.tambahBarangLagi();
        }

    }
}

