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
            button1 = new Button();
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
            panelMenu.Controls.Add(button1);
            panelMenu.Controls.Add(btnTransaksi);
            panelMenu.Controls.Add(btnBarang);
            panelMenu.Controls.Add(btnKasir);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 450);
            panelMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 172);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(175, 34);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 132);
            button1.Name = "button1";
            button1.Size = new Size(175, 34);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnTransaksi
            // 
            btnTransaksi.Location = new Point(12, 92);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(175, 34);
            btnTransaksi.TabIndex = 2;
            btnTransaksi.Text = "Riwayat Transaksi";
            btnTransaksi.UseVisualStyleBackColor = true;
            btnTransaksi.Click += btnTransaksi_Click;
            // 
            // btnBarang
            // 
            btnBarang.Location = new Point(12, 52);
            btnBarang.Name = "btnBarang";
            btnBarang.Size = new Size(175, 34);
            btnBarang.TabIndex = 1;
            btnBarang.Text = "Kelola Barang";
            btnBarang.UseVisualStyleBackColor = true;
            btnBarang.Click += btnBarang_Click;
            // 
            // btnKasir
            // 
            btnKasir.Location = new Point(12, 12);
            btnKasir.Name = "btnKasir";
            btnKasir.Size = new Size(175, 34);
            btnKasir.TabIndex = 0;
            btnKasir.Text = "Kasir";
            btnKasir.UseVisualStyleBackColor = true;
            btnKasir.Click += btnKasir_Click;
            // 
            // panelKonten
            // 
            panelKonten.Dock = DockStyle.Fill;
            panelKonten.Location = new Point(200, 0);
            panelKonten.Name = "panelKonten";
            panelKonten.Size = new Size(600, 450);
            panelKonten.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelKonten);
            Controls.Add(panelMenu);
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button btnKasir;
        private Button btnBarang;
        private Button btnTransaksi;
        private Button btnLogout;
        private Button button1;
        private Panel panelKonten;
    }
}