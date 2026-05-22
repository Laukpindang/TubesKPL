using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Forms;
using Tubes.Core;

namespace Tubes.Gui
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ComponentPlacing();
            this.CenterToScreen();
            txtPassword.UseSystemPasswordChar = true;
        }


        #region Component Placing
        private void ComponentPlacing()
        {
            var FormPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };


            this.Controls.Add(FormPanel);

            var centerPanel = CenteredPanel();
            FormPanel.Controls.Add(centerPanel);
            GuiUtil.CenterChildPanel(FormPanel, FormPanel.Controls[0] as Panel);

            centerPanel.Controls.Add(RowFormBox("Username", "text"));
            centerPanel.Controls.Add(RowFormBox("Password", "password"));
            centerPanel.Controls.Add(RowButtonBox());

        }
        private void RowBoxProp(Panel panel)
        {
            panel.Width = 300 - 8;
            panel.Height = 50;

            switch (panel)
            {
                case FlowLayoutPanel flowPanel:
                    flowPanel.FlowDirection = FlowDirection.LeftToRight;
                    break;

                case TableLayoutPanel tablePanel:
                    tablePanel.ColumnCount = 2;
                    break;
            }
        }

        private Panel CenteredPanel()
        {
            var centeredPanel = new FlowLayoutPanel();
            centeredPanel.Width = 300;
            centeredPanel.Height = 200;
            centeredPanel.FlowDirection = FlowDirection.TopDown;
            return centeredPanel;
        }


        private Panel RowFormBox(string labelText, string type)
        {
            var ltPanel = new FlowLayoutPanel();
            RowBoxProp(ltPanel);

            if(type == "text") {
                ltPanel.Controls.Add(label1);
                ltPanel.Controls.Add(txtUsername);
                return ltPanel;
            }
            else if (type == "password")
            {
                ltPanel.Controls.Add(label2);
                ltPanel.Controls.Add(txtPassword);
                return ltPanel;
            }

            return ltPanel;
        }

        private Panel RowButtonBox()
        {
            var btnPanel = new Panel();
            RowBoxProp(btnPanel);

            btnPanel.Controls.Add(button1);
            GuiUtil.CenterChildPanel(btnPanel, btnPanel.Controls[0] as Button);
            return btnPanel;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            AuthService authService = new AuthService();

            OperationResult result = authService.Login(
                txtUsername.Text,
                txtPassword.Text
            );

            if (result.IsSuccess)
            {
                MessageBox.Show(
                    $"Login berhasil, {Session.CurrentUser.Username}", 
                    "Sukses", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
                
                MainForm mainForm = new MainForm();
                mainForm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    $"Login gagal: {result.ErrorMessage}", 
                    "Gagal", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
