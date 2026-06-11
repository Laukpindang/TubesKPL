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
    }
}
