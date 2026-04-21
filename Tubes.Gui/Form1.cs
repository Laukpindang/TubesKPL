using Tubes.Core;

namespace Tubes.Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            label2.Text = test.greet();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
