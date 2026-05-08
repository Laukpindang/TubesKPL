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
        public async Task Setup()
        {
            Transaksi.ClearTransaksi().Wait();
            Transaksi.TestFile();
        }
        [TestMethod]
        public async Task ManipulasiFileSesuai()
        {
            var car = new Cart();

            Transaksi.TambahTransaksi(car).Wait();
            var jumlahAwal = Transaksi.ListTransaksi.Count;


            Transaksi.ListTransaksi.Clear();
            Transaksi.LoadTransaksi().Wait();

            var jumlahAkhir = Transaksi.ListTransaksi.Count;

            Assert.AreEqual(jumlahAwal, jumlahAkhir);
        }
        [TestMethod]
        public async Task TanggalWaktuTransaksiSesuai()
        {
            var car = new Cart();
            var tanggalSeharusnya = DateTime.Now.ToString("yyyyMMdd");

            Transaksi.TambahTransaksi(car).Wait();

            Assert.AreEqual(tanggalSeharusnya, Transaksi.ListTransaksi.Values.Last().tanggal);
            Assert.IsNotNull(Transaksi.ListTransaksi.Values.Last().waktu);
        }
        [TestMethod]
        public async Task TambahTransaksiSesuai()
        {
            var car = new Cart();
            var jumlahAwal = Transaksi.ListTransaksi.Count;

            Transaksi.TambahTransaksi(car).Wait();
            var jumlahAkhir = Transaksi.ListTransaksi.Count;

            Assert.IsGreaterThan(jumlahAwal, jumlahAkhir);
        }


    }
}
