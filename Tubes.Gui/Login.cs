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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

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
