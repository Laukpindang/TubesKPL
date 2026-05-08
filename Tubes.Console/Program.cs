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

        static async Task MenuTransaksi(Cart cart) 
        {

            bool transaksiSelesai = false;
            while (!transaksiSelesai) 
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"{new string(' ', 2)} Transaksi");
                Console.WriteLine(new string('=', 50));

                foreach (var item in cart.GetBarang())
                {
                    Console.WriteLine($"{item.barang.nama} - {item.jumlah} x {item.barang.harga} = {item.jumlah * item.barang.harga}");
                }

                Console.WriteLine(new string('\n', 2));
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"Total Belanja: {cart.TotalHarga()}");
                Console.WriteLine(new string('-', 50));

                Console.WriteLine();
                Console.WriteLine("[ 1. Tambah Barang || 2. Bayar || 3. Keluar dan Simpan || 4. Keluar tanpa Simpan ]");
                Console.Write("Menu Transaksi: ");
                int.TryParse(Console.ReadLine(), out int pilihanTransaksi);

                switch (pilihanTransaksi)
                {
                    case 1:
                        TambahBarang(cart);
                        break;
                    case 2:
                        await Transaksi.TambahTransaksi(cart);
                        cart.ClearCart();
                        Console.WriteLine("Transaksi Berhasil Dilakukan.");
                        ContinueMessage();
                        break;
                    case 3:
                        transaksiSelesai = true;
                        break;
                    case 4:
                        cart.ClearCart();
                        transaksiSelesai = true;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        ContinueMessage();
                        break;
                }

                Console.Clear();
            }

        }

        static void PrintLogTransaksi()
        {
            for (int i = 0; i < Transaksi.ListTransaksi.Count; i++)
            {
                var transaksi = Transaksi.ListTransaksi.ElementAt(i);
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"Kode Transaksi: {transaksi.Key}");
                Console.WriteLine($"Barang Transaksi: ");
                foreach (var item in transaksi.Value.barang)
                {
                    Console.WriteLine($"{item.barang.nama} - {item.jumlah} x {item.barang.harga} = {item.jumlah * item.barang.harga}");
                }
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"Total Belanja: {transaksi.Value.total}");
                Console.WriteLine(new string('=', 50));

                Console.WriteLine('\n');
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

        static async Task Main(string[] args)
        {
            Cart cart = new Cart();
            Katalog.LoadData();
            await Transaksi.LoadTransaksi();

            int pilihan = 0;
            while (pilihan != 3)
            {
                Console.Clear();

                Console.WriteLine("Menu:");
                Console.WriteLine("0. Lihat Semua Barang");
                Console.WriteLine("1. Transaksi");
                Console.WriteLine("2. Log Transaksi");
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
                        await MenuTransaksi(cart);
                        break;
                    case 2:
                        PrintLogTransaksi();
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