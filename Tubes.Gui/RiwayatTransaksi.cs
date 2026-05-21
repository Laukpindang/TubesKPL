using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tubes.Core;

namespace Tubes.Gui
{
    public partial class RiwayatTransaksi : Form
    {
        private readonly TransaksiService _service;

        public RiwayatTransaksi()
        {
            InitializeComponent();
            _service = new TransaksiService(Transaksi.ListTransaksi);
            listRiwayatTransaksi.DataSource = _service.GetRiwayatTransaksi();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //KEMBALI KE MENU SEBELUMNYA
            this.Close();
        }
    }
}
