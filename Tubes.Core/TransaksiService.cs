using System.ComponentModel;
using System.Data;

namespace Tubes.Core
{

    public class TransaksiService
    {
        private readonly Dictionary<string, DetailTransaksi> _RiwayatTransaksi;

        public TransaksiService(Dictionary<string, DetailTransaksi> riwayatTransaksi)
        {
            _RiwayatTransaksi = riwayatTransaksi;
        }

        public DataTable GetRiwayatTransaksi()
        {
            var transaksiList = _RiwayatTransaksi.Select(kvp => new DetailTransaksiPlusKey(kvp.Key, kvp.Value)).ToList();
            return transaksiList.ToDynamicDataTable();
        }
    }

    public class DetailTransaksiPlusKey
    {
        public string kode_pembelian { get; init; }
        public string tanggal { get; init; }
        public string waktu { get; init; }
        public Dictionary<string, int> barang_list { get; init; }
        public int total_pembayaran { get; init; }
        public int total_dibayar { get; init; }
        public string jenis_pembayaran { get; init; }

        public DetailTransaksiPlusKey() { }

        public DetailTransaksiPlusKey(string key, DetailTransaksi detail)
        {
            kode_pembelian = key;
            tanggal = detail.tanggal;
            waktu = detail.waktu;
            barang_list = detail.barang.ToDictionary(b => b.namaBarang, b => b.jumlah);
            total_pembayaran = detail.jumlah_pembayaran;
            total_dibayar = detail.total;
            jenis_pembayaran = detail.jenis_pembayaran;
        }
    }
    public static class TransaksiGridExtensions
    {
        public static DataTable ToDynamicDataTable(this IEnumerable<DetailTransaksiPlusKey> transaksiList)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Kode Pembelian", typeof(string));
            table.Columns.Add("Tanggal", typeof(string));
            table.Columns.Add("Waktu", typeof(string));

            var uniqueItems = transaksiList
                .SelectMany(t => t.barang_list.Keys)
                .Distinct()
                .OrderBy(name => name);

            foreach (var itemName in uniqueItems)
            {
                table.Columns.Add(itemName, typeof(int));
            }

            table.Columns.Add("Total Pembayaran", typeof(int));
            table.Columns.Add("Total Dibayar", typeof(int));
            table.Columns.Add("Jenis Pembayaran", typeof(string));


            foreach (var transaksi in transaksiList)
            {
                DataRow row = table.NewRow();
                row["Kode Pembelian"] = transaksi.kode_pembelian;
                row["Tanggal"] = transaksi.tanggal;
                row["Waktu"] = transaksi.waktu; 
                
                foreach (var itemName in uniqueItems)
                {
                    row[itemName] = transaksi.barang_list.ContainsKey(itemName)
                        ? transaksi.barang_list[itemName]
                        : 0;
                }

                row["Total Pembayaran"] = transaksi.total_pembayaran;
                row["Total Dibayar"] = transaksi.total_dibayar;
                row["Jenis Pembayaran"] = transaksi.jenis_pembayaran;

                

                table.Rows.Add(row);
            }

            return table;
        }
    }
}