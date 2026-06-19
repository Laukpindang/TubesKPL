using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tubes.Gui
{
    public partial class Kartu : Form
    {
        public Kartu(string title)
        {
            InitializeComponent();
            Text = title;
        }

        public static DialogResult Show()
        {
            using (var msgBox = new Kartu("Kartu"))
            {
                return msgBox.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int result))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid whole number.");
                textBox1.Text = string.Empty;
            }
        }
    }
}
