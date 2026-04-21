using Tubes.Core;

namespace Tubes.ConsoleApp
{
    internal class Program
    {
        static void TambahBarang(Cart cart) 
        {
            Console.Write("Masukkan nama barang: ");
            string namaBarang = Console.ReadLine();
            Console.Write("Masukkan jumlah barang: ");
            int jumlahBarang = int.Parse(Console.ReadLine());

            Barang barang = new Barang(namaBarang);
            cart.TambahBarang(barang, jumlahBarang);
        }
        static void TampilkanKeranjang(Cart cart) 
        {
            Console.WriteLine("Isi keranjang:");
            foreach (var item in cart.GetBarang())
            {
                Console.WriteLine($"{item.barang.nama} - {item.Jumlah}");
            }
        }
        static void Main(string[] args)
        {
            Cart cart = new Cart();

            int pilihan = 0;
            while (pilihan != 3)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Tambah Barang");
                Console.WriteLine("2. Tampilkan Keranjang");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu: ");
                pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        TambahBarang(cart);
                        break;
                    case 2:
                        TampilkanKeranjang(cart);
                        break;
                    case 3:
                        Console.WriteLine("Terima kasih!");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }
    }
}