using System;
using System.Collections.Generic;
using System.Text;

namespace BasicProgramming58
{
    class Perpustakaan
    {
        public string judulBuku;
        public string penulis;
        public string tahunTerbit;
        public string nomorRak;
        public string statusBuku;
        public int indeksBuku;
        public static int i = 1;
        public static List<Perpustakaan> listBuku = new List<Perpustakaan>();

        public static void TambahDataBuku()
        {
            string judul, penulis, tahun, rak, status;
            int indeks;
            bool isLanjutkan = true;
            Console.Clear();

            while (isLanjutkan)
            {
                Console.WriteLine("\t===Tambah Buku===");
                Console.Write("Judul Buku   : ");
                judul = Console.ReadLine();
                Console.Write("Pengarang    : ");
                penulis = Console.ReadLine();
                Console.Write("Tahun terbit : ");
                tahun = Console.ReadLine();
                Console.Write("Nomor Rak    : ");
                rak = Console.ReadLine();

                if (judul == "" || penulis == "" || tahun == "" || rak == "")
                {
                    Console.WriteLine("Harap isi informasi buku");
                }
                else
                {
                    indeks = i++;
                    status = "Tersedia";
                    listBuku.Add(new Perpustakaan { indeksBuku = indeks, judulBuku = judul, penulis = penulis, tahunTerbit = tahun, nomorRak = rak, statusBuku = status });
                }

                isLanjutkan = Program.GetYesorNo("Apakah Anda ingin menambahkan data baru");
                Console.WriteLine();
            }

        }

        public static void DaftarBuku()
        {
            Console.Clear();
            Console.WriteLine("===Daftar Buku===");

            foreach (var buku in listBuku)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"No              : {buku.indeksBuku}");
                Console.WriteLine($"Judul Buku      : {buku.judulBuku}");
                Console.WriteLine($"Penulis         : {buku.penulis}");
                Console.WriteLine($"Tahun Terbit    : {buku.tahunTerbit}");
                Console.WriteLine($"Nomor Rak       : {buku.nomorRak}");
                Console.WriteLine($"Status          : {buku.statusBuku}");
                Console.WriteLine("------------------------------------");
            }
        }

        public static void UbahBuku()
        {
            string judul, penulis, tahun, rak;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\tDaftar Buku Saat Ini");
            Console.WriteLine("\t\t------------------------------------");
            DaftarBuku();
            try
            {
                Console.WriteLine();
                Console.Write("Pilih nomor buku yang ingin diubah : ");
                int no = int.Parse(Console.ReadLine());
                var index = listBuku.FindIndex(c => c.indeksBuku == no);

                if (index >= 0)
                {
                    Console.WriteLine("Masukkan Informasi Baru Buku");
                    Console.WriteLine("----------------------------");
                    Console.Write("Judul Buku   : ");
                    judul = Console.ReadLine();
                    Console.Write("Pengarang    : ");
                    penulis = Console.ReadLine();
                    Console.Write("Tahun terbit : ");
                    tahun = Console.ReadLine();
                    Console.Write("Nomor Rak    : ");
                    rak = Console.ReadLine();

                    listBuku[index].judulBuku = judul;
                    listBuku[index].penulis = penulis;
                    listBuku[index].tahunTerbit = tahun;
                    listBuku[index].nomorRak = rak;

                    Console.WriteLine("Data berhasil dirubah");
                }
                else
                {
                    Console.WriteLine("Buku tidak ditemukan");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Harap pilih nomor buku");
            }
           
        }

        public static void HapusBuku()
        {
            Console.Clear();
            Console.WriteLine("\t\tDaftar Buku Saat Ini");
            Console.WriteLine("------------------------------------");
            DaftarBuku();
            try
            {
                Console.WriteLine();
                Console.Write("Pilih nomor buku yang dihapus : ");
                int no = int.Parse(Console.ReadLine());
                var index = listBuku.FindIndex(c => c.indeksBuku == no);

                if (index >= 0)
                {
                    listBuku.RemoveAt(index);
                    Console.WriteLine("Data telah dihapus.");
                }
                else
                {
                    Console.WriteLine("Buku tidak ditemukan");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Harap pilih nomor buku");
            }
            
        }
    }
}
