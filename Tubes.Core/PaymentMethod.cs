using System;
using System.Collections.Generic;
using System.Text;

namespace Tubes.Core
{
    public class PaymentMethod
    {
        public PaymentType CurrentState { get; private set; }

        public void StartBelanja()
        {
            if (CurrentState != PaymentType.Inactive)
            {
                throw new InvalidOperationException($"Tidak Bisa mulai transaksi dari {CurrentState}");
            }
            CurrentState = PaymentType.Tidak_Ada;
        }

        public void Reset()
        {
            CurrentState = PaymentType.Inactive;
        }

        public string[] getPaymentType() 
        {
            int min = (int)PaymentType.Inactive + 1;
            int max = (int)PaymentType.Tidak_Ada - 1;

            List<string> rangedNames = Enum.GetValues(typeof(PaymentType))
            .Cast<PaymentType>()
            .Where(e => (int)e >= min && (int)e <= max)
            .Select(e => e.ToString())
            .ToList();
            return rangedNames.ToArray();
        }

        public string Payment(int count) {             
            if (CurrentState == PaymentType.Inactive)
            {
                throw new InvalidOperationException($"Tidak Bisa memilih metode pembayaran dari {CurrentState}");
            }
            string[] paymentTypes = getPaymentType();
            if (count < 1 || count > paymentTypes.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Pilihan harus antara 1 dan {paymentTypes.Length - 1}");
            }
            CurrentState = (PaymentType)(count);
            return paymentTypes[count - 1];
        }
    }
}