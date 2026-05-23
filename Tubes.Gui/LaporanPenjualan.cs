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
            int tahunSekarang = DateTime.Now.Year;
            for (int t = tahunSekarang - 2; t <= tahunSekarang; t++)
                cmbTahun.Items.Add(t);
            cmbTahun.SelectedItem = tahunSekarang;

            for (int b = 1; b <= 12; b++)
                cmbBulan.Items.Add(new BulanItem(b));
            cmbBulan.DisplayMember = "Nama";
            cmbBulan.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void MuatDataTransaksi()
        {
            Transaksi.LoadTransaksi();

            int bulanDipilih = ((BulanItem)cmbBulan.SelectedItem).Nomor;
            int tahunDipilih = (int)cmbTahun.SelectedItem;
            string prefixBulan = $"{tahunDipilih}{bulanDipilih:D2}";

            // Filter transaksi berdasarkan bulan & tahun, group per hari
            var perHari = Transaksi.ListTransaksi
                .Where(x => x.Key.StartsWith(prefixBulan))
                .GroupBy(x => x.Value.tanggal)
                .OrderBy(g => g.Key)
                .ToList();

            dataGridView.Rows.Clear();
            int totalKeseluruhan = 0;

            foreach (var hari in perHari)
            {
                string tanggal = hari.Key;
                string tanggalFormatted = $"{tanggal[6..8]}/{tanggal[4..6]}/{tanggal[0..4]}";
                int totalHari = hari.Sum(x => x.Value.total);

                dataGridView.Rows.Add(
                    tanggalFormatted,
                    $"Rp {totalHari:N0}",
                    $"Rp {totalHari:N0}"  // sementara laba = total
                );

                totalKeseluruhan += totalHari;
            }

            lblJumlahTransaksi.Text = $"Total Transaksi: {Transaksi.ListTransaksi.Count(x => x.Key.StartsWith(prefixBulan))}";
            lblTotalPendapatan.Text = $"Total Pendapatan: Rp {totalKeseluruhan:N0}";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            MuatDataTransaksi();
        }
    }

    class BulanItem
    {
        public int Nomor { get; }
        public string Nama { get; }
        public BulanItem(int nomor)
        {
            Nomor = nomor;
            Nama = new DateTime(2000, nomor, 1).ToString("MMMM", new System.Globalization.CultureInfo("id-ID"));
        }
    }
}