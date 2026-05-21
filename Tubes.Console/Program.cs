using Tubes.Core;
using BenchmarkDotNet.Running;

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


        static async Task MenuTransaksi(Cart cart, TransaksiStateMachine sm, PaymentMethod pt)
        {
            sm.StartBelanja();
            pt.StartBelanja();

            bool transaksiSelesai = false;
            string paymentType = string.Empty;
            while (!transaksiSelesai) 
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"{new string(' ', 2)} Transaksi | Status: {sm.CurrentState}");
                Console.WriteLine(new string('=', 50));

                foreach (var item in cart.GetBarang())
                {
                    Console.WriteLine($"{item.barang.nama} - {item.jumlah} x {item.barang.harga} = {item.jumlah * item.barang.harga}");
                }

                Console.WriteLine(new string('\n', 2));
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"{new string(' ', 2)} Metode Pembayaran: {pt.CurrentState}");
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
                        if(sm.CurrentState == TransaksiState.MenungguBayar)
                        {
                            sm.tambahBarangLagi();
                        }
                        TambahBarang(cart);
                        break;
                    case 2:
                        sm.Checkout();
                        paymentType = await MenuPembayaran(pt);
                        break;
                    case 3:
                        sm.Bayar();
                        Transaksi.TambahTransaksi(cart, paymentType);
                        cart.ClearCart();
                        sm.reset();
                        Console.WriteLine("Transaksi berhasil.");
                        transaksiSelesai = true;
                        break;
                    case 4:
                        sm.Batal();
                        sm.reset();
                        cart.ClearCart();
                        Console.WriteLine("Transaksi dibatalkan.");
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

        private static async Task<string> MenuPembayaran(PaymentMethod pt)
        {
            int count = 1;

            Console.WriteLine("Jenis Pembayaran:");
            string[] paymentTypes = pt.getPaymentType();
            foreach (var paymentType in paymentTypes)
            {
                Console.WriteLine($"{count}. {paymentType}");
                count++;
            }
            Console.Write("Metode Pembayaran: ");
            int.TryParse(Console.ReadLine(), out int pilihanPayment);

            return pt.Payment(pilihanPayment);
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
                Console.WriteLine($"Metode Pembayaran: {transaksi.Value.jenis_pembayaran}");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"Total Belanja: {transaksi.Value.total}");
                Console.WriteLine(new string('=', 50));

                Console.WriteLine('\n');
            }

            ContinueMessage();
        }

        static void FilterTransaksiByTanggal()
        {
            Console.Write("Masukkan tanggal (yyyyMMdd): ");
            string tanggal = Console.ReadLine();

            var hasil = Transaksi.FilterTransaksi(
                t => t.tanggal == tanggal
            );
            Console.Clear();

            if (!hasil.Any())
            {
                Console.WriteLine("Transaksi tidak ditemukan.");
            }
            else
            {
                foreach (var transaksi in hasil)
                {
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine($"Kode Transaksi: {transaksi.Key}");
                    Console.WriteLine($"Tanggal: {transaksi.Value.tanggal}");
                    Console.WriteLine($"Waktu: {transaksi.Value.waktu}");

                    Console.WriteLine("Barang:");

                    foreach (var item in transaksi.Value.barang)
                    {
                        Console.WriteLine(
                            $"{item.barang.nama} - " +
                            $"{item.jumlah} x {item.barang.harga} = " +
                            $"{item.jumlah * item.barang.harga}"
                        );
                    }

                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine($"Total Belanja: {transaksi.Value.total}");
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine();
                }
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
            TransaksiStateMachine sm = new TransaksiStateMachine();
            PaymentMethod pt = new PaymentMethod();
            Katalog.LoadData();

            // TEST BENCHMARK DISINI
            // NOTE: UNTUK TEST, MASUK KE PROJECT CONSOLE `cd Tubes.Console`, LALU JALANKAN `dotnet run -c Release`
            // UNTUK CONTOH TEST LIHAT CLASS `KatalogBenchmark.cs`
            var katalogSummary = BenchmarkRunner.Run<KatalogBenchmark>();
            var transaksiSummary = BenchmarkRunner.Run<TransaksiBenchmark>();

            int pilihan = 0;
            while (pilihan != 4)
            {
                Transaksi.LoadTransaksi();
                Console.Clear();

                Console.WriteLine("Menu:");
                Console.WriteLine("0. Lihat Semua Barang");
                Console.WriteLine("1. Transaksi");
                Console.WriteLine("2. Log Transaksi");
                Console.WriteLine("3. Filter Transaksi");
                Console.WriteLine("4. Keluar");
                Console.Write("Pilih menu: ");
                pilihan = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (pilihan)
                {
                    case 0:
                        LihatSemuaBarang();
                        break;
                    case 1:
                        await MenuTransaksi(cart, sm, pt);
                        break;
                    case 2:
                        PrintLogTransaksi();
                        break;
                    case 3:
                        FilterTransaksiByTanggal();
                        break;
                    case 4:
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