using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes.Core;

namespace Tubes.Tests
{
    [TestClass]
    public sealed class KatalogTest
    {
        [TestInitialize]
        public void Setup()
        {
            Katalog.LoadData();
        }
        [TestMethod]
        public void CariBarangSesuai()
        {
            string namaBarang = "Buku";
            Barang hasil = Katalog.cariBarang(namaBarang);

            Assert.IsNotNull(hasil, "Barang seharusnya ditemukan, tetapi malah mengembalikan null");
            Assert.AreEqual("Buku", hasil.nama, "Nama barang tidak sesuai");
            Assert.AreEqual(5000, hasil.harga, "Harga barang tidak sesuai");
        }
        [TestMethod]
        public void CariBarangCaseSensitive()
        {
            string namaCari = "pUlPeN";
            Barang hasil = Katalog.cariBarang(namaCari);

            Assert.IsNotNull(hasil, "Pencarian gagal mendeteksi huruf besar/kecil (case-insensitive).");
            Assert.AreEqual("Pulpen", hasil.nama);
        }
        [TestMethod]
        public void CariBarangTidakAda()
        {
            string namaCari = "Barang halusinasi";
            Assert.Throws<KeyNotFoundException>(() =>
            {
                Katalog.cariBarang(namaCari);
            }, "Fungsi harus melempar NullReferenceException saat barang tidak ditemukan.");
        }
    }
}
