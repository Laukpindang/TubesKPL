using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using Tubes.Core;


namespace Tubes.Gui
{
    enum ManajemenMode
    {
        None,
        Tambah,
        Edit
    }

    public partial class ManajemenBarangPage : Form
    {
        private ManajemenMode currentState = ManajemenMode.None;

        public ManajemenBarangPage()
        {
            InitializeComponent();
            InitializeElements();
        }

        #region Components Initial
        private void InitializeElements()
        {
            Size FormSize = this.ClientSize;

            int FWidth = FormSize.Width;
            int FHeight = FormSize.Height;

            #region Top Container
            ContainerTop = new FlowLayoutPanel();

            ContainerTop.Width = FWidth - 30;
            ContainerTop.Height = FHeight - 20;

            ContainerTop.Location = new Point(15, 10);
            this.Controls.Add(ContainerTop);

            #endregion

            #region List Barang Table

            //Membuat Tabel
            TabelBarang = new DataGridView();
            TabelBarang.Font = new Font("Segoe UI", 10);
            TabelBarang.RowHeadersVisible = false;
            TabelBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TabelBarang.ScrollBars = ScrollBars.Vertical;
            TabelBarang.AutoGenerateColumns = true;

            //Ukuran dan Posisi
            TabelBarang.Width = (int)(ContainerTop.Width * 0.6);
            TabelBarang.Height = ContainerTop.Height - 10;
            TabelBarang.Location = new Point(10, 10);

            //Read-Only ability
            TabelBarang.ReadOnly = true;
            TabelBarang.AllowUserToAddRows = false;
            TabelBarang.AllowUserToOrderColumns = false;
            TabelBarang.AllowUserToResizeColumns = false;
            TabelBarang.AllowUserToResizeRows = false;
            TabelBarang.AllowUserToDeleteRows = false;
            TabelBarang.MultiSelect = false;
            TabelBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Binding Data
            Core.ManajemenBarang.LoadDataBarang();
            TabelBarang.DataSource = null;
            TabelBarang.DataSource = Core.ManajemenBarang.daftarBarang;

            //Menambahkan data ke container
            ContainerTop.Controls.Add(TabelBarang);

            #endregion

            #region Side Container

            ContainerSide = new FlowLayoutPanel();

            ContainerSide.Width = (int)(ContainerTop.Width * 0.38);
            ContainerSide.Height = ContainerTop.Height - 10;
            ContainerSide.Location = new Point((int)(ContainerTop.Width * 0.65) + 10, 10);
            ContainerSide.BorderStyle = BorderStyle.FixedSingle;
            ContainerTop.Controls.Add(ContainerSide);

            //Showed panel
            var menuPanel = MenuBtnPanels(ContainerSide);
            ContainerSide.Controls.Add(menuPanel);
            #endregion



        }

        #region Menu Buttons
        private FlowLayoutPanel MenuBtnPanels(Panel Container)
        {
            //Panel untuk menampung tombol-tombol menu
            var BtnContainer = new FlowLayoutPanel();
            BtnContainer.FlowDirection = FlowDirection.TopDown;
            BtnContainer.WrapContents = false;

            BtnContainer.Width = Container.Width - 20;
            BtnContainer.Height = (int)(Container.Height * 0.4);

            BtnContainer.Margin = new Padding(8, (Container.Height / 2) - (int)(BtnContainer.Height * 0.5), 8, 0);

            //Button
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();

            var btnSize = new Size(BtnContainer.Width, 40);
            var margins = new Padding(0, 5, 0, 5);

            btnTambah.Size = btnSize;
            btnEdit.Size = btnSize;
            btnHapus.Size = btnSize;

            btnTambah.Margin = margins;
            btnEdit.Margin = margins;
            btnHapus.Margin = margins;

            btnTambah.Text = "Tambah Barang";
            btnEdit.Text = "Edit Barang";
            btnHapus.Text = "Hapus Barang";

            //Daftar event handler
            btnTambah.Click += (sender, e) => {
                currentState = ManajemenMode.Tambah;
                btnToForm_Click(sender, e);
            };
            btnEdit.Click += (sender, e) => {
                currentState = ManajemenMode.Edit;
                btnToForm_Click(sender, e);
            }; 
            btnHapus.Click += btnHapus_Click;

            BtnContainer.Controls.Add(btnTambah);
            BtnContainer.Controls.Add(btnEdit);
            BtnContainer.Controls.Add(btnHapus);

            return BtnContainer;
        }
        #endregion

        #region Form
        private FlowLayoutPanel FormBarang(Panel container)
        {
            var FormPanel = new FlowLayoutPanel();
            FormPanel.FlowDirection = FlowDirection.TopDown;
            FormPanel.Size = new Size(container.Width - 8, container.Height - 8);
            FormPanel.Font = new Font("Segoe UI", 9F);

            var tbWidth = FormPanel.Width - 8;
            var tbHeight = 20;

            var labelId = new Label();
            labelId.Text = "ID:";
            IdText = new TextBox();
            IdText.Width = tbWidth;

            var labelName = new Label();
            labelName.Text = "Name:";
            NameText = new TextBox();
            NameText.Width = tbWidth;

            var labelPrice = new Label();
            labelPrice.Text = "Price:";
            PriceText = new TextBox();
            PriceText.Width = tbWidth;

            var labelStock = new Label();
            labelStock.Text = "Stock:";
            StockText = new TextBox();
            StockText.Width = tbWidth;

            if(currentState == ManajemenMode.Edit)
            {
                IdText.Text = TabelBarang.SelectedRows[0].Cells["id"].Value.ToString();
                NameText.Text = TabelBarang.SelectedRows[0].Cells["nama"].Value.ToString();
                PriceText.Text = TabelBarang.SelectedRows[0].Cells["harga"].Value.ToString();
                StockText.Text = TabelBarang.SelectedRows[0].Cells["stok"].Value.ToString();

                IdText.Enabled = false;
            }

            #region Label + TextBox Addition
            FormPanel.Controls.Add(labelId);
            FormPanel.Controls.Add(IdText);
            FormPanel.Controls.Add(labelName);
            FormPanel.Controls.Add(NameText);
            FormPanel.Controls.Add(labelPrice);
            FormPanel.Controls.Add(PriceText);
            FormPanel.Controls.Add(labelStock);
            FormPanel.Controls.Add(StockText);
            #endregion

            var btnGrp = new FlowLayoutPanel();
            btnGrp.FlowDirection = FlowDirection.LeftToRight;
            btnGrp.Width = FormPanel.Width - 2;
            btnGrp.Height = 60;
            btnGrp.Margin = new Padding(0, 30, 0, 0);
            btnGrp.WrapContents = false;

            var btnSimpan = new Button();
            var btnBack = new Button();

            btnSimpan.Text = "Simpan";
            btnSimpan.Size = new Size((int)(btnGrp.Width * 0.48) - 4, btnGrp.Height - 8);

            btnBack.Text = "Kembali";
            btnBack.Size = new Size((int)(btnGrp.Width * 0.5) - 4, btnGrp.Height - 8);

            if(currentState == ManajemenMode.Tambah)
            {
                btnSimpan.Click += btnSimpan_Click;
            }
            else if (currentState == ManajemenMode.Edit)
            {
                btnSimpan.Click += btnEdit_Click;
            }

            btnBack.Click += btnBack_Click;


            btnGrp.Controls.Add(btnBack);
            btnGrp.Controls.Add(btnSimpan);

            FormPanel.Controls.Add(btnGrp);

            return FormPanel;
        }
        #endregion

        #endregion

        #region Btn event handler

        private void ToFormAction()
        {
            ContainerSide.Controls.Clear();
            ContainerSide.Controls.Add(FormBarang(ContainerSide));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ContainerSide.Controls.Clear();
            ContainerSide.Controls.Add(MenuBtnPanels(ContainerSide));

            currentState = ManajemenMode.None;
        }

        private void btnToForm_Click(object sender, EventArgs e)
        {
            if(currentState == ManajemenMode.Edit && TabelBarang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih barang yang ingin diedit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ToFormAction();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            var id = int.Parse(IdText.Text);
            var name = NameText.Text;
            var price = int.Parse(PriceText.Text);
            var stock = int.Parse(StockText.Text);

            var result = Core.ManajemenBarang.IdValidation(id);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var barang = new Core.Barang
            {
                id = id,
                nama = name,
                harga = price,
                stok = stock
            };

            var tambahResult = Core.ManajemenBarang.TambahBarang(barang);
            if (!tambahResult.IsSuccess)
            {
                MessageBox.Show(tambahResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Core.ManajemenBarang.SaveDataBarang();
            MessageBox.Show("Barang berhasil ditambahkan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            IdText.Text = "";
            NameText.Text = "";
            PriceText.Text = "";
            StockText.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = int.Parse(IdText.Text);
            var name = NameText.Text;
            var price = int.Parse(PriceText.Text);
            var stock = int.Parse(StockText.Text);


            var barang = new Core.Barang
            {
                id = id,
                nama = name,
                harga = price,
                stok = stock
            };

            var editResult = Core.ManajemenBarang.EditBarang(id, barang);
            if (!editResult.IsSuccess)
            {
                MessageBox.Show(editResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Core.ManajemenBarang.SaveDataBarang();
            MessageBox.Show("Barang berhasil diperbarui", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (TabelBarang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih barang yang ingin dihapus", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                var selectedRow = TabelBarang.SelectedRows[0];
                var selectedBarang = (Core.Barang)selectedRow.DataBoundItem;
                var confirmResult = MessageBox.Show($"Apakah Anda yakin ingin menghapus barang '{selectedBarang.nama}'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    Core.ManajemenBarang.daftarBarang.Remove(selectedBarang);
                    Core.ManajemenBarang.SaveDataBarang();
                    MessageBox.Show("Barang berhasil dihapus", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

    }
}
