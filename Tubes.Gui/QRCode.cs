using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tubes.Gui
{
    public partial class QRCode : Form
    {
        public QRCode(string title)
        {
            InitializeComponent();
            Text = title;
        }

        public static DialogResult Show()
        {
            using (var msgBox = new QRCode("QR Code"))
            {
                return msgBox.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Kasir.PembayaranBerhasil();
        }
    }
}
