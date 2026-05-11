using System;
using System.Collections.Generic;
using System.Text;
using Tubes.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        // UNIT TESTS

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


        // Defensive Tests

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
