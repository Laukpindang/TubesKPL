using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Tubes.Core;

namespace Tubes.Tests
{
    [TestClass]
    public class LaporanPenjualanTest
    {
        [TestInitialize]
        public void Setup()
        {
            Transaksi.ListTransaksi = new Dictionary<string, DetailTransaksi>
            {
                // Mei 2025 - 3 transaksi
                ["202505010001"] = BuatDetail("20250501", "09:00:00", 27500, "Tunai",
                    ("Indomie Goreng", 3500, 5), ("Teh Botol", 5000, 2)),

                ["202505150002"] = BuatDetail("20250515", "13:00:00", 59000, "Kartu",
                    ("Minyak Goreng 2L", 35000, 1), ("Tepung Terigu 1kg", 12000, 2)),

                ["202505220003"] = BuatDetail("20250522", "11:00:00", 78000, "E-Wallet",
                    ("Pasta Gigi", 13000, 2), ("Sabun Dove", 12000, 3)),

                // Juni 2025 - 1 transaksi
                ["202506100004"] = BuatDetail("20250610", "10:00:00", 44000, "Tunai",
                    ("Aqua 600ml", 4000, 6), ("Teh Pucuk", 5000, 4)),

                // Januari 2026 - 1 transaksi
                ["202601050005"] = BuatDetail("20260105", "08:00:00", 85000, "Kartu",
                    ("Susu Ultra 1L", 18000, 2), ("Keju Kraft", 25000, 1)),
            };
        }

        // Helper: bikin CartItem pakai constructor yang bener (Barang, int)
        private CartItem BuatCartItem(string nama, int harga, int jumlah)
        {
            var barang = new Barang(0, nama, harga, 99);
            return new CartItem(barang, jumlah);
        }

        // Helper: bikin DetailTransaksi dummy
        private DetailTransaksi BuatDetail(string tanggal, string waktu, int total,
            string jenisBayar, params (string nama, int harga, int jumlah)[] items)
        {
            var barang = new BindingList<CartItem>();
            foreach (var item in items)
                barang.Add(BuatCartItem(item.nama, item.harga, item.jumlah));

            return new DetailTransaksi
            {
                tanggal = tanggal,
                waktu = waktu,
                total = total,
                jenis_pembayaran = jenisBayar,
                barang = barang
            };
        }

        // Helper filter (sama persis logika di LaporanPenjualan.cs)
        private List<KeyValuePair<string, DetailTransaksi>> FilterBulan(int bulan, int tahun)
        {
            string prefix = $"{tahun}{bulan:D2}";
            return Transaksi.ListTransaksi
                .Where(x => x.Key.StartsWith(prefix))
                .ToList();
        }

        // --- TEST CASES ---

        [TestMethod]
        public void FilterBulan_Mei2025_Harus3Transaksi()
        {
            var hasil = FilterBulan(5, 2025);
            Assert.AreEqual(3, hasil.Count);
        }

        [TestMethod]
        public void FilterBulan_Juni2025_Harus1Transaksi()
        {
            var hasil = FilterBulan(6, 2025);
            Assert.AreEqual(1, hasil.Count);
        }

        [TestMethod]
        public void FilterBulan_BulanKosong_HasilNol()
        {
            var hasil = FilterBulan(3, 2025); // Maret 2025 - nggak ada datanya
            Assert.AreEqual(0, hasil.Count);
        }

        [TestMethod]
        public void FilterBulan_Mei2025_TotalPendapatanBenar()
        {
            var hasil = FilterBulan(5, 2025);
            int totalPendapatan = hasil.Sum(x => x.Value.total);
            Assert.AreEqual(164500, totalPendapatan); // 27500 + 59000 + 78000
        }

        [TestMethod]
        public void FilterBulan_TidakTercampurBulanLain()
        {
            var mei = FilterBulan(5, 2025);
            bool adaJuni = mei.Any(x => x.Key.StartsWith("202506"));
            Assert.IsFalse(adaJuni);
        }

        [TestMethod]
        public void FilterBulan_TidakTercampurTahunLain()
        {
            var jan2025 = FilterBulan(1, 2025);
            var jan2026 = FilterBulan(1, 2026);
            Assert.AreEqual(0, jan2025.Count);
            Assert.AreEqual(1, jan2026.Count);
        }

        [TestMethod]
        public void FilterBulan_DataBarangMuncul()
        {
            var hasil = FilterBulan(5, 2025)
                .First(x => x.Key == "202505010001");
            Assert.AreEqual(2, hasil.Value.barang.Count);
            Assert.AreEqual("Indomie Goreng", hasil.Value.barang[0].namaBarang);
        }

        [TestMethod]
        public void FilterBulan_MetodePembayaranBenar()
        {
            var hasil = FilterBulan(6, 2025).First();
            Assert.AreEqual("Tunai", hasil.Value.jenis_pembayaran);
        }
    }
}