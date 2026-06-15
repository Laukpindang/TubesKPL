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
            ((System.ComponentModel.ISupportInitialize)listRiwayatTransaksi).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 0;
            label1.Text = "Riwayat Transaksi";
            // 
            // listRiwayatTransaksi
            // 
            listRiwayatTransaksi.AllowUserToAddRows = false;
            listRiwayatTransaksi.AllowUserToDeleteRows = false;
            listRiwayatTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            listRiwayatTransaksi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            listRiwayatTransaksi.Location = new Point(10, 24);
            listRiwayatTransaksi.Margin = new Padding(3, 2, 3, 2);
            listRiwayatTransaksi.Name = "listRiwayatTransaksi";
            listRiwayatTransaksi.ReadOnly = true;
            listRiwayatTransaksi.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            listRiwayatTransaksi.ScrollBars = ScrollBars.Vertical;
            listRiwayatTransaksi.Size = new Size(1002, 303);
            listRiwayatTransaksi.TabIndex = 1;
            // 
            // RiwayatTransaksi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 338);
            Controls.Add(listRiwayatTransaksi);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RiwayatTransaksi";
            Text = "Riwayat Transaksi";
            ((System.ComponentModel.ISupportInitialize)listRiwayatTransaksi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView listRiwayatTransaksi;
    }
}