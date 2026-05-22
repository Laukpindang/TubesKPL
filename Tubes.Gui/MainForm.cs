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
    public partial class MainForm : Form
    {
        private Form? _halamanAktif = null;
        public MainForm()
        {
            InitializeComponent();
            MainForm_Load(this, EventArgs.Empty);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            BukaHalaman(new Kasir());
        }
        private void BukaHalaman(Form newForm)
        {
            _halamanAktif?.Close();
            _halamanAktif = newForm;
            // Konfigurasi form baru agar tampil di panel
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            // Input form baru ke panel
            panelKonten.Controls.Add(newForm);
            panelKonten.Tag = newForm;
            // Tampilkan form baru
            newForm.BringToFront();
            newForm.Show();
        }

        private void btnKasir_Click(object sender, EventArgs e)
        {
            Katalog.LoadData();
            BukaHalaman(new Kasir());
        }

        private void btnBarang_Click(object sender, EventArgs e)
        {
            BukaHalaman(new ManajemenBarangPage());
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            BukaHalaman(new RiwayatTransaksi());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.logout();
            
            Application.Restart();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            Application.Exit();
        }
    }
}
