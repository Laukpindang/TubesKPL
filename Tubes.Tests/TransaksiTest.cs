using System;
using System.Collections.Generic;
using System.Text;
using Tubes.Core;

namespace Tubes.Tests
{
    [TestClass]
    public sealed class TransaksiTest
    {
        [TestInitialize]
        public void Setup()
        {
            Transaksi.ClearTransaksi();
            Transaksi.TestFile();
        }
        [TestMethod]
        public void ManipulasiFileSesuai()
        {
            var car = new Cart<Barang>();

            Transaksi.TambahTransaksi(car);
            var jumlahAwal = Transaksi.ListTransaksi.Count;


            Transaksi.ListTransaksi.Clear();
            Transaksi.LoadTransaksi();

            var jumlahAkhir = Transaksi.ListTransaksi.Count;

            Assert.AreEqual(jumlahAwal, jumlahAkhir);
        }
        [TestMethod]
        public void TanggalWaktuTransaksiSesuai()
        {
            var car = new Cart<Barang>();
            var tanggalSeharusnya = DateTime.Now.ToString("yyyyMMdd");

            Transaksi.TambahTransaksi(car);

            Assert.AreEqual(tanggalSeharusnya, Transaksi.ListTransaksi.Values.Last().tanggal);
            Assert.IsNotNull(Transaksi.ListTransaksi.Values.Last().waktu);
        }
        [TestMethod]
        public void TambahTransaksiSesuai()
        {
            var car = new Cart<Barang>();
            var jumlahAwal = Transaksi.ListTransaksi.Count;

            Transaksi.TambahTransaksi(car);
            var jumlahAkhir = Transaksi.ListTransaksi.Count;

            Assert.IsGreaterThan(jumlahAwal, jumlahAkhir);
        }


    }
}
