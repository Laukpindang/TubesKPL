using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tubes.Core;

namespace Tubes.Gui
{
    public partial class LaporanPenjualan : Form
    {
        public LaporanPenjualan()
        {
            InitializeComponent();
            IsiDropdownBulanTahun();
            MuatDataTransaksi();
        }

        private void IsiDropdownBulanTahun()
        {
            // Isi dropdown tahun: 2 tahun ke belakang sampai sekarang
            int tahunSekarang = DateTime.Now.Year;
            for (int t = tahunSekarang - 2; t <= tahunSekarang; t++)
            {
                cmbTahun.Items.Add(t);
            }
            cmbTahun.SelectedItem = tahunSekarang;

            // Isi dropdown bulan
            for (int b = 1; b <= 12; b++)
            {
                cmbBulan.Items.Add(new BulanItem(b));
            }
            cmbBulan.DisplayMember = "Nama";
            cmbBulan.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void MuatDataTransaksi()
        {
            Transaksi.LoadTransaksi();

            int bulanDipilih = ((BulanItem)cmbBulan.SelectedItem).Nomor;
            int tahunDipilih = (int)cmbTahun.SelectedItem;
            string prefixBulan = $"{tahunDipilih}{bulanDipilih:D2}";

            // Filter transaksi berdasarkan bulan & tahun
            var filtered = Transaksi.ListTransaksi
                .Where(x => x.Key.StartsWith(prefixBulan))
                .ToList();

            // Isi tabel
            dataGridView.Rows.Clear();
            int totalKeseluruhan = 0;

            foreach (var entry in filtered)
            {
                string kode = entry.Key;
                DetailTransaksi d = entry.Value;

                string listBarang = string.Join(", ",
                    d.barang.Select(b => $"{b.namaBarang} x{b.jumlah}"));

                dataGridView.Rows.Add(
                    kode,
                    $"{d.tanggal[6..8]}/{d.tanggal[4..6]}/{d.tanggal[0..4]} {d.waktu}",
                    listBarang,
                    $"Rp {d.total:N0}",
                    d.jenis_pembayaran
                );

                totalKeseluruhan += d.total;
            }

            lblJumlahTransaksi.Text = $"Total Transaksi: {filtered.Count}";
            lblTotalPendapatan.Text = $"Total Pendapatan: Rp {totalKeseluruhan:N0}";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            MuatDataTransaksi();
        }
    }

    // Helper class buat dropdown bulan
    class BulanItem
    {
        public int Nomor { get; }
        public string Nama { get; }
        public BulanItem(int nomor)
        {
            Nomor = nomor;
            Nama = new DateTime(2000, nomor, 1).ToString("MMMM");
        }
    }
}