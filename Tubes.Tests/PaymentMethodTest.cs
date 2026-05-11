using System;
using System.Collections.Generic;
using System.Text;
using Tubes.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tubes.Tests
{
    [TestClass]
    public class PaymentMethodTest
    {
        private PaymentMethod pm;

        [TestInitialize]
        public void Setup()
        {
            pm = new PaymentMethod();
        }

        // UNIT TESTS

        [TestMethod]
        public void StartBelanja_DariInactive_StateJadiTidakAda()
        {
            pm.StartBelanja();
            Assert.AreEqual(PaymentType.Tidak_Ada, pm.CurrentState);
        }

        [TestMethod]
        public void Reset_StateKembaliInactive()
        {
            pm.StartBelanja();
            pm.Reset();
            Assert.AreEqual(PaymentType.Inactive, pm.CurrentState);
        }

        [TestMethod]
        public void Payment_DariTidakAda_StateJadiMetodePembayaran()
        {
            pm.StartBelanja();
            string[] paymentTypes = pm.getPaymentType();
            for (int i = 1; i <= paymentTypes.Length; i++)
            {
                string expectedPaymentType = paymentTypes[i - 1];
                string actualPaymentType = pm.Payment(i);
                Assert.AreEqual(expectedPaymentType, actualPaymentType);
                Assert.AreEqual((PaymentType)i, pm.CurrentState);
            }
        }

        // EXCEPTION TESTS

        [TestMethod]
        public void StartBelanja_DariStateAktif_ThrowInvalidOperationException()
        {
            pm.StartBelanja();
            Assert.Throws<InvalidOperationException>(() => pm.StartBelanja());
        }

        public void Reset_DariStateAktif_ThrowInvalidOperationException()
        {
            pm.StartBelanja();
            Assert.Throws<InvalidOperationException>(() => pm.Reset());
        }

        public void Payment_DariStateInactive_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => pm.Payment(1));
        }

        public void Payment_DenganPilihanDiluarRentang_ThrowArgumentOutOfRangeException()
        {
            pm.StartBelanja();
            string[] paymentTypes = pm.getPaymentType();
            int invalidCount = paymentTypes.Length + 1;
            Assert.Throws<ArgumentOutOfRangeException>(() => pm.Payment(invalidCount));
        }

        public void Payment_DenganPilihanNol_ThrowArgumentOutOfRangeException()
        {
            pm.StartBelanja();
            Assert.Throws<ArgumentOutOfRangeException>(() => pm.Payment(0));
        }

        public void Payment_DenganPilihanNegatif_ThrowArgumentOutOfRangeException()
        {
            pm.StartBelanja();
            Assert.Throws<ArgumentOutOfRangeException>(() => pm.Payment(-1));
        }

        public void Payment_DenganPilihanSamaDenganJumlahMetode_ThrowArgumentOutOfRangeException()
        {
            pm.StartBelanja();
            string[] paymentTypes = pm.getPaymentType();
            int invalidCount = paymentTypes.Length;
            Assert.Throws<ArgumentOutOfRangeException>(() => pm.Payment(invalidCount));
        }
    }
}
