using Tubes.Core;

namespace Tubes.ConsoleApp
{
    internal class Program
    {
        static void ContinueMessage() 
        { 
            Console.WriteLine();
            Console.WriteLine("Tekan Enter untuk melanjutkan...");
            Console.ReadLine();
        }

        static void LihatSemuaBarang() 
        {
            Console.WriteLine("Daftar Barang:");
            foreach (Barang barang in Katalog.GetAllBarang())
            {
                Console.WriteLine($"{barang.nama} - {barang.harga}");
            }

            ContinueMessage();
        }

        static void TambahBarang(Cart cart) 
        {
            Console.Write("Masukkan nama barang: ");
            string namaBarang = Console.ReadLine();

            Barang barang = Katalog.cariBarang(namaBarang);
            if (barang == null) 
            {
                Console.WriteLine("Barang tidak ditemukan.");
                return;
            }

            Console.Write("Masukkan jumlah barang: ");
            int jumlahBarang = int.Parse(Console.ReadLine());
            if (jumlahBarang <= 0)
            {
                Console.WriteLine("Jumlah yang dibeli harus lebih dari 0");
                return;
            }

            cart.TambahBarang(barang, jumlahBarang);
            Console.WriteLine("Barang berhasil ditambahkan ke keranjang.");

            ContinueMessage();

        }
        static void TampilkanKeranjang(Cart cart) 
        {
            Console.WriteLine("Isi keranjang:");
            foreach (var item in cart.GetBarang())
            {
                Console.WriteLine($"{item.barang.nama} - {item.jumlah}");
            }

            ContinueMessage();
        }

        static void Main(string[] args)
        {
            Cart cart = new Cart();
            Katalog.LoadData();

            int pilihan = 0;
            while (pilihan != 3)
            {
                Console.Clear();

                Console.WriteLine("Menu:");
                Console.WriteLine("0. Lihat Semua Barang");
                Console.WriteLine("1. Tambah Barang");
                Console.WriteLine("2. Tampilkan Keranjang");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu: ");
                pilihan = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (pilihan)
                {
                    case 0:
                        LihatSemuaBarang();
                        break;
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