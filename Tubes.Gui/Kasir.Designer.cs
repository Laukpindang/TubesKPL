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
            label3 = new Label();
            inputPayment = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)inputJumlah).BeginInit();
            ((System.ComponentModel.ISupportInitialize)listBarang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cartItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputUangBayar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 62);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 0;
            label1.Text = "Nama Barang";
            // 
            // inputBarang
            // 
            inputBarang.FormattingEnabled = true;
            inputBarang.Items.AddRange(new object[] { "Buku", "Pulpen", "Pensil", "Etanol", "Chitato", "Lays", "Bengbeng" });
            inputBarang.Location = new Point(29, 84);
            inputBarang.Margin = new Padding(2);
            inputBarang.Name = "inputBarang";
            inputBarang.Size = new Size(258, 28);
            inputBarang.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 128);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 2;
            label2.Text = "Jumlah";
            // 
            // inputJumlah
            // 
            inputJumlah.Location = new Point(29, 150);
            inputJumlah.Margin = new Padding(2);
            inputJumlah.Name = "inputJumlah";
            inputJumlah.Size = new Size(257, 27);
            inputJumlah.TabIndex = 3;
            // 
            // listBarang
            // 
            listBarang.AllowUserToAddRows = false;
            listBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listBarang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listBarang.Location = new Point(29, 242);
            listBarang.Margin = new Padding(2);
            listBarang.Name = "listBarang";
            listBarang.ReadOnly = true;
            listBarang.RowHeadersVisible = false;
            listBarang.RowHeadersWidth = 62;
            listBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listBarang.Size = new Size(580, 180);
            listBarang.TabIndex = 5;
            // 
            // cartItemBindingSource
            // 
            cartItemBindingSource.DataSource = typeof(Core.CartItem);
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(196, 197);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 27);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Tambah";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblNamaKasir
            // 
            lblNamaKasir.AutoSize = true;
            lblNamaKasir.Location = new Point(29, 25);
            lblNamaKasir.Margin = new Padding(2, 0, 2, 0);
            lblNamaKasir.Name = "lblNamaKasir";
            lblNamaKasir.Size = new Size(85, 20);
            lblNamaKasir.TabIndex = 7;
            lblNamaKasir.Text = "Nama Kasir";
            // 
            // lblTotalHarga
            // 
            lblTotalHarga.AutoSize = true;
            lblTotalHarga.Location = new Point(351, 25);
            lblTotalHarga.Margin = new Padding(2, 0, 2, 0);
            lblTotalHarga.Name = "lblTotalHarga";
            lblTotalHarga.Size = new Size(87, 20);
            lblTotalHarga.TabIndex = 8;
            lblTotalHarga.Text = "Total Harga";
            // 
            // lblBayar
            // 
            lblBayar.AutoSize = true;
            lblBayar.Location = new Point(351, 62);
            lblBayar.Margin = new Padding(2, 0, 2, 0);
            lblBayar.Name = "lblBayar";
            lblBayar.Size = new Size(140, 20);
            lblBayar.TabIndex = 9;
            lblBayar.Text = "Jumlah Pembayaran";
            // 
            // inputUangBayar
            // 
            inputUangBayar.Location = new Point(351, 84);
            inputUangBayar.Margin = new Padding(2);
            inputUangBayar.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            inputUangBayar.Name = "inputUangBayar";
            inputUangBayar.Size = new Size(258, 27);
            inputUangBayar.TabIndex = 10;
            // 
            // btnBayar
            // 
            btnBayar.Location = new Point(519, 197);
            btnBayar.Margin = new Padding(2);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(90, 27);
            btnBayar.TabIndex = 11;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(351, 128);
            label3.Name = "label3";
            label3.Size = new Size(146, 20);
            label3.TabIndex = 12;
            label3.Text = "Metode Pembayaran";
            // 
            // inputPayment
            // 
            inputPayment.FormattingEnabled = true;
            inputPayment.Items.AddRange(new object[] { "Tunai", "Kartu", "E_Wallet" });
            inputPayment.Location = new Point(351, 149);
            inputPayment.Name = "inputPayment";
            inputPayment.Size = new Size(258, 28);
            inputPayment.TabIndex = 13;
            // 
            // Kasir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 431);
            Controls.Add(inputPayment);
            Controls.Add(label3);
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
            Margin = new Padding(2);
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
        private Label label3;
        private ComboBox inputPayment;
    }
}
