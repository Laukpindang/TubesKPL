using Tubes.Core;

namespace Tubes.Gui
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Katalog.LoadData();
            // TODO: GANTI KE LOGIN FORM KETIKA SUDAH SELESAI
            Application.Run(new Form1());
        }
    }
}