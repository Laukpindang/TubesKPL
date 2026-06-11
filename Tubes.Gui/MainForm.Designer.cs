namespace Tubes.Gui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            btnLogout = new Button();
            btnLaporan= new Button();
            btnTransaksi = new Button();
            btnBarang = new Button();
            btnKasir = new Button();
            panelKonten = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnLaporan);
            panelMenu.Controls.Add(btnTransaksi);
            panelMenu.Controls.Add(btnBarang);
            panelMenu.Controls.Add(btnKasir);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(160, 450);
            panelMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(10, 138);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 27);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.Location = new Point(10, 106);
            btnLaporan.Margin = new Padding(2);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(140, 27);
            btnLaporan.TabIndex = 3;
            btnLaporan.Text = "Laporan Penjualan";
            btnLaporan.UseVisualStyleBackColor = true;
            btnLaporan.Click += btnLaporan_Click;
            // 
            // btnTransaksi
            // 
            btnTransaksi.Location = new Point(10, 74);
            btnTransaksi.Margin = new Padding(2);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(140, 27);
            btnTransaksi.TabIndex = 2;
            btnTransaksi.Text = "Riwayat Transaksi";
            btnTransaksi.UseVisualStyleBackColor = true;
            btnTransaksi.Click += btnTransaksi_Click;
            // 
            // btnBarang
            // 
            btnBarang.Location = new Point(10, 42);
            btnBarang.Margin = new Padding(2);
            btnBarang.Name = "btnBarang";
            btnBarang.Size = new Size(140, 27);
            btnBarang.TabIndex = 1;
            btnBarang.Text = "Kelola Barang";
            btnBarang.UseVisualStyleBackColor = true;
            btnBarang.Click += btnBarang_Click;
            // 
            // btnKasir
            // 
            btnKasir.Location = new Point(10, 10);
            btnKasir.Margin = new Padding(2);
            btnKasir.Name = "btnKasir";
            btnKasir.Size = new Size(140, 27);
            btnKasir.TabIndex = 0;
            btnKasir.Text = "Kasir";
            btnKasir.UseVisualStyleBackColor = true;
            btnKasir.Click += btnKasir_Click;
            // 
            // panelKonten
            // 
            panelKonten.Dock = DockStyle.Fill;
            panelKonten.Location = new Point(160, 0);
            panelKonten.Margin = new Padding(2);
            panelKonten.Name = "panelKonten";
            panelKonten.Size = new Size(640, 450);
            panelKonten.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelKonten);
            Controls.Add(panelMenu);
            Margin = new Padding(2);
            MinimumSize = new Size(818, 497);
            Name = "MainForm";
            Text = "MainForm";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button btnKasir;
        private Button btnBarang;
        private Button btnTransaksi;
        private Button btnLogout;
        private Button btnLaporan;
        private Panel panelKonten;
    }
}