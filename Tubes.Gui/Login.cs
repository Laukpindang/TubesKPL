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
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthService authService = new AuthService();

            var result = authService.Login(
                txtUsername.Text,
                txtPassword.Text
            );

            MessageBox.Show("Login berhasil");

            if (result.IsSuccess)
            {
                Kasir kasirForm = new Kasir();
                kasirForm.Show();

                this.Hide();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
