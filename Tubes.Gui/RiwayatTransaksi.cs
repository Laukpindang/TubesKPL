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
            ComponentPlacing();
            _service = new TransaksiService(Transaksi.ListTransaksi);
            listRiwayatTransaksi.DataSource = _service.GetRiwayatTransaksi();
            listRiwayatTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ComponentPlacing()
        {
            label1.Text = "Riwayat Transaksi";
            TabelRiwayatProp();
        }

        private void TabelRiwayatProp()
        {
            //Cells
            listRiwayatTransaksi.RowHeadersVisible = false;

            //Columns Sizing
            listRiwayatTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Read Only
            listRiwayatTransaksi.ReadOnly = true;
            listRiwayatTransaksi.AllowUserToAddRows = false;
            listRiwayatTransaksi.AllowUserToOrderColumns = false;
            listRiwayatTransaksi.AllowUserToResizeColumns = false;
            listRiwayatTransaksi.AllowUserToResizeRows = false;
            listRiwayatTransaksi.AllowUserToDeleteRows = false;
            listRiwayatTransaksi.MultiSelect = false;
            listRiwayatTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btn_Click(object sender, EventArgs e)
        {
            //KEMBALI KE MENU SEBELUMNYA
            this.Close();
        }
    }
}
