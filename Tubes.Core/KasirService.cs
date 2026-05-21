using System.ComponentModel;

namespace Tubes.Core
{
    public class KasirService
    {
        private readonly Cart _cart;

        // Dependency Injection
        public KasirService(Cart cart)
        {
            _cart = cart;
        }

        public BindingList<CartItem> GetDaftarKeranjang()
        {
            return _cart.GetBarang();
        }

        public OperationResult ProsesTambahBarang(string namaInput, int jumlah)
        {
            // SECURE CODING
            string namaBarang = namaInput.Trim();

            if (string.IsNullOrWhiteSpace(namaBarang))
            {
                return OperationResult.Fail("Nama barang tidak boleh kosong.");
            }

            // SECURE CODING
            if (jumlah <= 0 || jumlah > 1000)
            {
                return OperationResult.Fail("Jumlah barang tidak valid. Harus antara 1 hingga 1000.");
            }

            Barang barangDitemukan;
            try
            {
                barangDitemukan = Katalog.cariBarang(namaBarang);
            }
            catch (System.Exception)
            {
                // SECURE CODING
                return OperationResult.Fail("Terjadi gangguan saat mengakses katalog database.");
            }

            // CLEAN CODE
            if (barangDitemukan == null)
            {
                return OperationResult.Fail($"Barang '{namaBarang}' tidak ditemukan di katalog.");
            }

            _cart.TambahBarang(barangDitemukan, jumlah);
            return OperationResult.Success();
        }
        public int HitungTotalBelanja()
        {
            return _cart.GetBarang().Sum(item => item.subTotal);
        }
        public OperationResult ProsesPembayaran(int uangBayar)
        {
            int total = HitungTotalBelanja();

            if (total == 0)
            {
                return OperationResult.Fail("Keranjang masih kosong.");
            }

            if (uangBayar < total)
            {
                return OperationResult.Fail($"Uang pembayaran kurang! Total belanja adalah Rp {total}");
            }

            int kembalian = uangBayar - total;

            // MASUKKAN HASIL TRANSAKSI KE LOG JSON DISINI!!!!

            // KOSONGKAN KERANJANG SETELAH TRANSAKSI BERHASIL
            _cart.GetBarang().Clear();

            return OperationResult.Success();
        }
    }
}