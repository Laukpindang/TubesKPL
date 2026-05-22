namespace Tubes.Gui
{
    partial class LaporanPenjualan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblJudul = new Label();
            lblBulan = new Label();
            cmbBulan = new ComboBox();
            lblTahun = new Label();
            cmbTahun = new ComboBox();
            btnFilter = new Button();
            dataGridView = new DataGridView();
            colKode = new DataGridViewTextBoxColumn();
            colTanggal = new DataGridViewTextBoxColumn();
            colBarang = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colMetode = new DataGridViewTextBoxColumn();
            lblJumlahTransaksi = new Label();
            lblTotalPendapatan = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.Location = new Point(12, 12);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(760, 30);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Laporan Penjualan Bulanan";
            lblJudul.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBulan
            // 
            lblBulan.Location = new Point(12, 55);
            lblBulan.Name = "lblBulan";
            lblBulan.Size = new Size(51, 23);
            lblBulan.TabIndex = 1;
            lblBulan.Text = "Bulan:";
            lblBulan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbBulan
            // 
            cmbBulan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBulan.Location = new Point(69, 53);
            cmbBulan.Name = "cmbBulan";
            cmbBulan.Size = new Size(130, 28);
            cmbBulan.TabIndex = 2;
            // 
            // lblTahun
            // 
            lblTahun.Location = new Point(205, 55);
            lblTahun.Name = "lblTahun";
            lblTahun.Size = new Size(57, 23);
            lblTahun.TabIndex = 3;
            lblTahun.Text = "Tahun:";
            lblTahun.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTahun
            // 
            cmbTahun.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTahun.Location = new Point(268, 53);
            cmbTahun.Name = "cmbTahun";
            cmbTahun.Size = new Size(80, 28);
            cmbTahun.TabIndex = 4;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(668, 55);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(90, 26);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Tampilkan";
            btnFilter.Click += btnFilter_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colKode, colTanggal, colBarang, colTotal, colMetode });
            dataGridView.Location = new Point(12, 90);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(760, 380);
            dataGridView.TabIndex = 6;
            // 
            // colKode
            // 
            colKode.FillWeight = 15F;
            colKode.HeaderText = "Kode Transaksi";
            colKode.MinimumWidth = 6;
            colKode.Name = "colKode";
            colKode.ReadOnly = true;
            // 
            // colTanggal
            // 
            colTanggal.FillWeight = 18F;
            colTanggal.HeaderText = "Tanggal & Waktu";
            colTanggal.MinimumWidth = 6;
            colTanggal.Name = "colTanggal";
            colTanggal.ReadOnly = true;
            // 
            // colBarang
            // 
            colBarang.FillWeight = 35F;
            colBarang.HeaderText = "Barang";
            colBarang.MinimumWidth = 6;
            colBarang.Name = "colBarang";
            colBarang.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.FillWeight = 14F;
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 6;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colMetode
            // 
            colMetode.FillWeight = 18F;
            colMetode.HeaderText = "Metode Bayar";
            colMetode.MinimumWidth = 6;
            colMetode.Name = "colMetode";
            colMetode.ReadOnly = true;
            // 
            // lblJumlahTransaksi
            // 
            lblJumlahTransaksi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblJumlahTransaksi.Location = new Point(12, 480);
            lblJumlahTransaksi.Name = "lblJumlahTransaksi";
            lblJumlahTransaksi.Size = new Size(250, 23);
            lblJumlahTransaksi.TabIndex = 7;
            lblJumlahTransaksi.Text = "Total Transaksi: -";
            // 
            // lblTotalPendapatan
            // 
            lblTotalPendapatan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalPendapatan.Location = new Point(520, 480);
            lblTotalPendapatan.Name = "lblTotalPendapatan";
            lblTotalPendapatan.Size = new Size(252, 23);
            lblTotalPendapatan.TabIndex = 8;
            lblTotalPendapatan.Text = "Total Pendapatan: -";
            lblTotalPendapatan.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LaporanPenjualan
            // 
            ClientSize = new Size(784, 511);
            Controls.Add(lblJudul);
            Controls.Add(lblBulan);
            Controls.Add(cmbBulan);
            Controls.Add(lblTahun);
            Controls.Add(cmbTahun);
            Controls.Add(btnFilter);
            Controls.Add(dataGridView);
            Controls.Add(lblJumlahTransaksi);
            Controls.Add(lblTotalPendapatan);
            MinimumSize = new Size(800, 550);
            Name = "LaporanPenjualan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Laporan Penjualan";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblBulan;
        private System.Windows.Forms.ComboBox cmbBulan;
        private System.Windows.Forms.Label lblTahun;
        private System.Windows.Forms.ComboBox cmbTahun;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetode;
        private System.Windows.Forms.Label lblJumlahTransaksi;
        private System.Windows.Forms.Label lblTotalPendapatan;
    }
}