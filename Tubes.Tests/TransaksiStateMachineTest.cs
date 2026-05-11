using Tubes.Core;

namespace Tubes.Tests
{
    [TestClass]
    public class TransaksiStateMachineTest
    {
        private TransaksiStateMachine sm;

        [TestInitialize]
        public void Setup()
        {
            sm = new TransaksiStateMachine();
        }

        // UNIT TESTS - memastikan setiap transisi state berjalan sesuai aturan

        [TestMethod]
        public void StartBelanja_DariIdle_StateJadiBelanja()
        {
            sm.StartBelanja();
            Assert.AreEqual(TransaksiState.Belanja, sm.CurrentState);
        }

        [TestMethod]
        public void Checkout_DariBelanja_StateJadiMenungguBayar()
        {
            sm.StartBelanja();
            sm.Checkout();
            Assert.AreEqual(TransaksiState.MenungguBayar, sm.CurrentState);
        }

        [TestMethod]
        public void Bayar_DariMenungguBayar_StateJadiSelesai()
        {
            sm.StartBelanja();
            sm.Checkout();
            sm.Bayar();
            Assert.AreEqual(TransaksiState.Selesai, sm.CurrentState);
        }

        [TestMethod]
        public void Batal_DariBelanja_StateJadiBatal()
        {
            sm.StartBelanja();
            sm.Batal();
            Assert.AreEqual(TransaksiState.Batal, sm.CurrentState);
        }

        [TestMethod]
        public void Reset_StateKembaliIdle()
        {
            sm.StartBelanja();
            sm.Batal();
            sm.reset();
            Assert.AreEqual(TransaksiState.Idle, sm.CurrentState);
        }

        [TestMethod]
        public void TambahBarangLagi_DariMenungguBayar_StateJadiBelanja()
        {
            sm.StartBelanja();
            sm.Checkout();
            sm.tambahBarangLagi();
            Assert.AreEqual(TransaksiState.Belanja, sm.CurrentState);
        }


        // Defensive Tests - memastikan transisi yang tidak valid melempar exception

        [TestMethod]
        public void StartBelanja_DariBukanIdle_HarusThrowException()
        {
            sm.StartBelanja();
            try
            {
                sm.StartBelanja();
                Assert.Fail("Harusnya throw exception");
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void Checkout_DariIdle_HarusThrowException()
        {
            try
            {
                sm.Checkout();
                Assert.Fail("Harusnya throw exception");
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void Bayar_DariBelanja_HarusThrowException()
        {
            sm.StartBelanja();
            try
            {
                sm.Bayar();
                Assert.Fail("Harusnya throw exception");
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void Batal_DariIdle_HarusThrowException()
        {
            try
            {
                sm.Batal();
                Assert.Fail("Harusnya throw exception");
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void TambahBarangLagi_DariBelanja_HarusThrowException()
        {
            sm.StartBelanja();
            try
            {
                sm.tambahBarangLagi();
                Assert.Fail("Harusnya throw exception");
            }
            catch (InvalidOperationException) { }
        }

        // Performance Test - memastikan state machine tetap responsif meskipun ada banyak transaksi

        [TestMethod]
        public void PerformanceTest_MultipleTransactions()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                sm.StartBelanja();
                sm.Checkout();
                sm.Bayar();
                sm.reset();
            }

            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds < 1000, $"Terlalu lambat: {sw.ElapsedMilliseconds}ms");
            Assert.AreEqual(TransaksiState.Idle, sm.CurrentState);
        }
        [TestMethod]
        public void PerformanceTest_GenericCart_TambahBanyakBarang()
        {
            var cart = new Cart<Barang>();
            var barang = new Barang(1, "Buku", 5000, 99999);
            var sw = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
                cart.TambahBarang(barang, 1);

            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds < 1000, $"TambahBarang terlalu lambat: {sw.ElapsedMilliseconds}ms");
        }

        [TestMethod]
        public void PerformanceTest_GenericCart_TotalHarga()
        {
            var cart = new Cart<Barang>();
            var barang = new Barang(1, "Buku", 5000, 99999);
            for (int i = 0; i < 1000; i++)
                cart.TambahBarang(barang, 1);

            var sw = System.Diagnostics.Stopwatch.StartNew();
            cart.TotalHarga();
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 1000, $"TotalHarga terlalu lambat: {sw.ElapsedMilliseconds}ms");
        }
    }
}
