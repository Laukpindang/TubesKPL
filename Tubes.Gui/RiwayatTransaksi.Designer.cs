namespace Tubes.Gui
{
    partial class RiwayatTransaksi
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
            label1 = new Label();
            listRiwayatTransaksi = new DataGridView();
            btn = new Button();
            ((System.ComponentModel.ISupportInitialize)listRiwayatTransaksi).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // listRiwayatTransaksi
            // 
            listRiwayatTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listRiwayatTransaksi.Location = new Point(12, 32);
            listRiwayatTransaksi.Name = "listRiwayatTransaksi";
            listRiwayatTransaksi.RowHeadersWidth = 51;
            listRiwayatTransaksi.Size = new Size(776, 371);
            listRiwayatTransaksi.TabIndex = 1;
            // 
            // btn
            // 
            btn.Location = new Point(351, 409);
            btn.Name = "btn";
            btn.Size = new Size(94, 29);
            btn.TabIndex = 2;
            btn.Text = "Kembali";
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn_Click;
            // 
            // RiwayatTransaksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn);
            Controls.Add(listRiwayatTransaksi);
            Controls.Add(label1);
            Name = "RiwayatTransaksi";
            Text = "Riwayat Transaksi";
            ((System.ComponentModel.ISupportInitialize)listRiwayatTransaksi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView listRiwayatTransaksi;
        private Button btn;
    }
}