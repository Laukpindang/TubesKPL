using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Tubes.Core
{

    public class TransaksiService
    {
        private readonly Dictionary<string, DetailTransaksi> _RiwayatTransaksi;

        public TransaksiService(Dictionary<string, DetailTransaksi> riwayatTransaksi)
        {
            _RiwayatTransaksi = riwayatTransaksi;
        }

        public BindingList<DetailTransaksiPlusKey> GetRiwayatTransaksi()
        {
            return new BindingList<DetailTransaksiPlusKey>(_RiwayatTransaksi.Select(kvp => new DetailTransaksiPlusKey(kvp.Key, kvp.Value)).ToList());
        }
    }

    public class DetailTransaksiPlusKey
    {
        public string kode_pembelian { get; init; }
        public string tanggal { get; init; }
        public string waktu { get; init; }
        public BindingList<CartItem> barang { get; init; }
        public int jumlah_pembayaran { get; init; }
        public int total { get; init; }
        public string jenis_pembayaran { get; init; }

        public DetailTransaksiPlusKey() { }

        public DetailTransaksiPlusKey(string key, DetailTransaksi detail)
        {
            kode_pembelian = key;
            tanggal = detail.tanggal;
            waktu = detail.waktu;
            barang = detail.barang;
            total = detail.total;
            jumlah_pembayaran = detail.jumlah_pembayaran;
            jenis_pembayaran = detail.jenis_pembayaran;
        }
    }
}