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
            colTanggal = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colLaba = new DataGridViewTextBoxColumn();
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
            cmbBulan.SelectedIndexChanged += cmbBulan_SelectedIndexChanged;
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
            btnFilter.Location = new Point(668, 51);
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colTanggal, colTotal, colLaba });
            dataGridView.Location = new Point(12, 90);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(760, 380);
            dataGridView.TabIndex = 6;
            // 
            // colTanggal
            // 
            colTanggal.FillWeight = 33F;
            colTanggal.HeaderText = "Tanggal";
            colTanggal.MinimumWidth = 6;
            colTanggal.Name = "colTanggal";
            colTanggal.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.FillWeight = 33F;
            colTotal.HeaderText = "Jumlah Transaksi";
            colTotal.MinimumWidth = 6;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colLaba
            // 
            colLaba.FillWeight = 33F;
            colLaba.HeaderText = "Pendapatan ";
            colLaba.MinimumWidth = 6;
            colLaba.Name = "colLaba";
            colLaba.ReadOnly = true;
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
            lblTotalPendapatan.Location = new Point(490, 480);
            lblTotalPendapatan.Name = "lblTotalPendapatan";
            lblTotalPendapatan.Size = new Size(282, 23);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLaba;
        private System.Windows.Forms.Label lblJumlahTransaksi;
        private System.Windows.Forms.Label lblTotalPendapatan;
    }
}