using System;
using System.Collections.Generic;

namespace BasicProgramming58
{
    class Program
    {

        static void Main(string[] args)
        {
            bool isLanjutkan = true;

            while (isLanjutkan) {
                Console.Clear();
                Menu();
                int pil = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (pil)
                {
                    case 1:
                        Perpustakaan.DaftarBuku();
                        break;
                    case 2:
                        Perpustakaan.TambahDataBuku();
                        break;
                    case 3:
                        Perpustakaan.UbahBuku();
                        break;
                    case 4:
                        Perpustakaan.HapusBuku();
                        break;
                    case 5:
                        Peminjaman.PeminjamanBuku();
                        break;
                    case 6:
                        Peminjaman.Pengembalian();
                        break;
                    default:
                        Console.WriteLine("Input anda tidak ditemukan.");
                        Console.WriteLine("Silahkan pilih (1-6)");
                        break;
                }
                
                isLanjutkan = GetYesorNo("Apakah anda ingin melanjutkan");
            }

        }

        public static bool GetYesorNo(string message)
        {
            Console.WriteLine();
            Console.Write($"{message} (y/n)? ");
            string pilihanUser = Console.ReadLine();

            while(!pilihanUser.Equals("y", StringComparison.InvariantCultureIgnoreCase) && !pilihanUser.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Pilihan Anda bukan y atau n");
                Console.WriteLine();
                Console.Write($"{message} (y/n)? ");
                pilihanUser = Console.ReadLine();
            }

            return pilihanUser.Equals("y", StringComparison.InvariantCultureIgnoreCase);
        }

        
        public static void Menu()
        {
            Console.WriteLine("====Database Perpustakaan====");
            Console.WriteLine("1. Lihat Buku");
            Console.WriteLine("2. Tambah Buku");
            Console.WriteLine("3. Ubah Data Buku");
            Console.WriteLine("4. Hapus Data Buku");
            Console.WriteLine("5. Peminjaman Buku");
            Console.WriteLine("6. Pengembalian Buku");
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.Write("Pilihan menu : ");
        }
    }


}

