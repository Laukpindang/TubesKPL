namespace Tubes.Gui
{
    partial class Kasir
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            inputBarang = new ComboBox();
            label2 = new Label();
            inputJumlah = new NumericUpDown();
            listBarang = new DataGridView();
            cartItemBindingSource = new BindingSource(components);
            btnAdd = new Button();
            lblNamaKasir = new Label();
            lblTotalHarga = new Label();
            lblBayar = new Label();
            inputUangBayar = new NumericUpDown();
            btnBayar = new Button();
            ((System.ComponentModel.ISupportInitialize)inputJumlah).BeginInit();
            ((System.ComponentModel.ISupportInitialize)listBarang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cartItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputUangBayar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 77);
            label1.Name = "label1";
            label1.Size = new Size(119, 25);
            label1.TabIndex = 0;
            label1.Text = "Nama Barang";
            // 
            // inputBarang
            // 
            inputBarang.FormattingEnabled = true;
            inputBarang.Items.AddRange(new object[] { "Buku", "Pulpen", "Pensil", "Etanol", "Chitato", "Lays", "Bengbeng" });
            inputBarang.Location = new Point(36, 105);
            inputBarang.Name = "inputBarang";
            inputBarang.Size = new Size(321, 33);
            inputBarang.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 160);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 2;
            label2.Text = "Jumlah";
            // 
            // inputJumlah
            // 
            inputJumlah.Location = new Point(36, 188);
            inputJumlah.Name = "inputJumlah";
            inputJumlah.Size = new Size(321, 31);
            inputJumlah.TabIndex = 3;
            // 
            // listBarang
            // 
            listBarang.AllowUserToAddRows = false;
            listBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listBarang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listBarang.Location = new Point(36, 302);
            listBarang.Name = "listBarang";
            listBarang.ReadOnly = true;
            listBarang.RowHeadersVisible = false;
            listBarang.RowHeadersWidth = 62;
            listBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listBarang.Size = new Size(360, 225);
            listBarang.TabIndex = 5;
            // 
            // cartItemBindingSource
            // 
            cartItemBindingSource.DataSource = typeof(Core.CartItem);
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(245, 246);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Tambah";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblNamaKasir
            // 
            lblNamaKasir.AutoSize = true;
            lblNamaKasir.Location = new Point(36, 31);
            lblNamaKasir.Name = "lblNamaKasir";
            lblNamaKasir.Size = new Size(101, 25);
            lblNamaKasir.TabIndex = 7;
            lblNamaKasir.Text = "Nama Kasir";
            // 
            // lblTotalHarga
            // 
            lblTotalHarga.AutoSize = true;
            lblTotalHarga.Location = new Point(397, 108);
            lblTotalHarga.Name = "lblTotalHarga";
            lblTotalHarga.Size = new Size(102, 25);
            lblTotalHarga.TabIndex = 8;
            lblTotalHarga.Text = "Total Harga";
            // 
            // lblBayar
            // 
            lblBayar.AutoSize = true;
            lblBayar.Location = new Point(397, 160);
            lblBayar.Name = "lblBayar";
            lblBayar.Size = new Size(169, 25);
            lblBayar.TabIndex = 9;
            lblBayar.Text = "Jumlah Pembayaran";
            // 
            // inputUangBayar
            // 
            inputUangBayar.Location = new Point(397, 188);
            inputUangBayar.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            inputUangBayar.Name = "inputUangBayar";
            inputUangBayar.Size = new Size(322, 31);
            inputUangBayar.TabIndex = 10;
            // 
            // btnBayar
            // 
            btnBayar.Location = new Point(607, 246);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(112, 34);
            btnBayar.TabIndex = 11;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // Kasir
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 539);
            Controls.Add(btnBayar);
            Controls.Add(inputUangBayar);
            Controls.Add(lblBayar);
            Controls.Add(lblTotalHarga);
            Controls.Add(lblNamaKasir);
            Controls.Add(btnAdd);
            Controls.Add(listBarang);
            Controls.Add(inputJumlah);
            Controls.Add(label2);
            Controls.Add(inputBarang);
            Controls.Add(label1);
            Name = "Kasir";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)inputJumlah).EndInit();
            ((System.ComponentModel.ISupportInitialize)listBarang).EndInit();
            ((System.ComponentModel.ISupportInitialize)cartItemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputUangBayar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox inputBarang;
        private Label label2;
        private NumericUpDown inputJumlah;
        private DataGridView listBarang;
        private BindingSource cartItemBindingSource;
        private Button btnAdd;
        private Label lblNamaKasir;
        private Label lblTotalHarga;
        private Label lblBayar;
        private NumericUpDown inputUangBayar;
        private Button btnBayar;
    }
}
