using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes.Core
{
    public class TransaksiStateMachine
    {
        public TransaksiState CurrentState { get; private set; }

        public TransaksiStateMachine()
        {
            CurrentState = TransaksiState.Idle;
        }

        public void StartBelanja()
        {
            if (CurrentState != TransaksiState.Idle)
            {
                throw new InvalidOperationException($"Tidak Bisa mulai transaksi dari {CurrentState}");
            }
            CurrentState = TransaksiState.Belanja;
        }

        public void Checkout()
        {
            if (CurrentState != TransaksiState.Belanja)
            {
                throw new InvalidOperationException($"Tidak Bisa Checkout dari {CurrentState}");
            }
            CurrentState = TransaksiState.MenungguBayar;
        }

        public void Bayar()
        {
            if (CurrentState != TransaksiState.MenungguBayar)
            {
                throw new InvalidOperationException($"Tidak Bisa Bayar dari {CurrentState}");
            }
            CurrentState = TransaksiState.Selesai;
        }

        public void tambahBarangLagi()
        {
            if (CurrentState != TransaksiState.MenungguBayar)
            {
                throw new InvalidOperationException($"Tidak Bisa tambah barang lagi dari {CurrentState}");
            }
            CurrentState = TransaksiState.Belanja;
        }

        public void Batal()
        {
            if (CurrentState != TransaksiState.Belanja && CurrentState != TransaksiState.MenungguBayar)
            {
                throw new InvalidOperationException($"Tidak Bisa batal transaksi dari {CurrentState}");
            }
            CurrentState = TransaksiState.Batal;
        }

        public void reset()
        {
            CurrentState = TransaksiState.Idle;
        }
    }
}
