using System;
using System.Collections.Generic;
using System.Text;

namespace BasicProgramming58
{
    class Peminjaman : Perpustakaan
    {
        private int lamaPinjam;
        private static List<Peminjaman> listPinjam = new List<Peminjaman>();

        public static void PeminjamanBuku()
        {
            DaftarBuku();
            try
            {
                Console.Write("Pilih nomor buku yang dipinjam : ");
                int no = int.Parse(Console.ReadLine());
                var index = listBuku.FindIndex(c => c.indeksBuku == no);
                Console.Write("Masukkan perkiraan lama hari : ");
                int lama = int.Parse(Console.ReadLine());

                if (index >= 0)
                {
                    listPinjam.Add(new Peminjaman { indeksBuku = listBuku[index].indeksBuku, judulBuku = listBuku[index].judulBuku, penulis = listBuku[index].penulis, tahunTerbit = listBuku[index].tahunTerbit, nomorRak = listBuku[index].nomorRak, statusBuku = (listBuku[index].statusBuku = "Sudah dipinjam"), lamaPinjam = lama });
                    Console.WriteLine();
                    LihatPinjaman();
                }
                else
                {
                    Console.WriteLine("Buku tidak ditemukan");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Input yang Anda masukkan salah");
            }
            
        }

        public static void LihatPinjaman()
        {
            Console.Clear();
            Console.WriteLine("===Daftar Buku Yang Dipinjam===");

            foreach (var pinjam in listPinjam)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"No              : {pinjam.indeksBuku}");
                Console.WriteLine($"Judul Buku      : {pinjam.judulBuku}");
                Console.WriteLine($"Penulis         : {pinjam.penulis}");
                Console.WriteLine($"Tahun Terbit    : {pinjam.tahunTerbit}");
                Console.WriteLine($"Nomor Rak       : {pinjam.nomorRak}");
                Console.WriteLine($"Status          : {pinjam.statusBuku}");
                Console.WriteLine($"Lama Hari       : {pinjam.lamaPinjam} hari");
                Console.WriteLine("------------------------------------");
            }
        }

        public static void Pengembalian()
        {
            LihatPinjaman();
            try
            {
                Console.Write("Pilih nomor buku yang dikembalikan : ");
                int no = int.Parse(Console.ReadLine());
                var index = listPinjam.FindIndex(c => c.indeksBuku == no);
                var indexBuku = listBuku.FindIndex(c => c.indeksBuku == no);
                Console.Write("Masukkan total hari peminjaman : ");
                int lama = int.Parse(Console.ReadLine());

                if (index >= 0)
                {
                    if (lama > listPinjam[index].lamaPinjam)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Anda mendapatkan denda sebesar Rp. 3000 per hari");
                        int selisihHari = lama - listPinjam[index].lamaPinjam;
                        float total = Denda(selisihHari);
                        Console.WriteLine($"Total Biaya : Rp. {total}");
                        listPinjam.RemoveAt(index);
                        listBuku[indexBuku].statusBuku = "Tersedia";
                        Console.WriteLine("Buku telah dikembalikan");
                    }
                    else
                    {
                        Console.WriteLine();
                        listPinjam.RemoveAt(index);
                        listBuku[indexBuku].statusBuku = "Tersedia";
                        Console.WriteLine("Buku telah dikembalikan");
                    }
                }
                else
                {
                    Console.WriteLine("Buku tidak ditemukan");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Input yang Anda masukkan salah");
            }
            
        }

        public static float Denda(int lama)
        {
            float total = lama * 3000;
            return total;
        }
    }
}
