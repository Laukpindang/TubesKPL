namespace Tubes.Gui
{
    partial class ManajemenBarangPage
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
            SuspendLayout();
            // 
            // ManajemenBarangPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "ManajemenBarangPage";
            Text = "ManajemenBarangPage";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel ContainerTop;
        private FlowLayoutPanel ContainerSide;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnHapus;
        private DataGridView TabelBarang;

        private FlowLayoutPanel FormPanel;

        #region Tambah Form Component
        private TextBox IdText;
        private TextBox NameText;
        private TextBox PriceText;
        private TextBox StockText;
        #endregion
    }
}