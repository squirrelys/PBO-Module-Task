using System;
using System.Collections.Generic;

namespace Zoo
{
    
    public class Hewan
    {
        public string Nama { get; set; }
        public int Umur { get; set; }

        public Hewan(string nama, int umur)
        {
            Nama = nama;
            Umur = umur;
        }

        public virtual string Suara()
        {
            return "Hewan ini bersuara.";
        }

        public virtual string InfoHewan()
        {
            return $"Nama: {Nama}, Umur: {Umur} tahun.";
        }
    }

    public class Mamalia : Hewan
    {
        public int JumlahKaki { get; set; }

        public Mamalia(string nama, int umur, int jumlahKaki)
            : base(nama, umur)
        {
            JumlahKaki = jumlahKaki;
        }

        public override string InfoHewan()
        {
            return base.InfoHewan() + $" Jumlah Kaki: {JumlahKaki}.";
        }
    }

    public class Reptil : Hewan
    {
        public double PanjangTubuh { get; set; }

        public Reptil(string nama, int umur, double panjangTubuh)
            : base(nama, umur)
        {
            PanjangTubuh = panjangTubuh;
        }

        public override string InfoHewan()
        {
            return base.InfoHewan() + $" Panjang Tubuh: {PanjangTubuh} meter.";
        }
    }

    public class Singa : Mamalia
    {
        public Singa(string nama, int umur)
            : base(nama, umur, 4)
        {
        }

        public override string Suara()
        {
            return "Singa mengaum!";
        }

        public void Mengaum()
        {
            Console.WriteLine("Singa sedang mengaum dengan keras!");
        }
    }

    public class Gajah : Mamalia
    {
        public Gajah(string nama, int umur)
            : base(nama, umur, 4)
        {
        }

        public override string Suara()
        {
            return "Gajah menderum!";
        }
    }

    public class Ular : Reptil
    {
        public Ular(string nama, int umur, double panjangTubuh)
            : base(nama, umur, panjangTubuh)
        {
        }

        public override string Suara()
        {
            return "Ular mendesis!";
        }

        public void Merayap()
        {
            Console.WriteLine("Ular sedang merayap diam-diam.");
        }
    }

    public class Buaya : Reptil
    {
        public Buaya(string nama, int umur, double panjangTubuh)
            : base(nama, umur, panjangTubuh)
        {
        }

        public override string Suara()
        {
            return "Buaya menggeram!";
        }
    }

    public class KebunBinatang
    {
        private List<Hewan> koleksiHewan = new List<Hewan>();

        public void TambahHewan(Hewan hewan)
        {
            koleksiHewan.Add(hewan);
        }

        public void DaftarHewan()
        {
            Console.WriteLine("Daftar Hewan di Kebun Binatang:");
            foreach (var hewan in koleksiHewan)
            {
                Console.WriteLine(hewan.InfoHewan());
                Console.WriteLine(hewan.Suara());
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KebunBinatang kebunBinatang = new KebunBinatang();

            Singa singa = new Singa("Bimbi", 5);
            Gajah gajah = new Gajah("Dudu", 10);
            Ular ular = new Ular("Dino", 3, 2.5);
            Buaya buaya = new Buaya("Sapta", 8, 4.0);

            kebunBinatang.TambahHewan(singa);
            kebunBinatang.TambahHewan(gajah);
            kebunBinatang.TambahHewan(ular);
            kebunBinatang.TambahHewan(buaya);

            kebunBinatang.DaftarHewan();

            Console.WriteLine("Polymorphismnya:");
            Hewan[] hewanList = { singa, ular, buaya };
            foreach (Hewan hewan in hewanList)
            {
                Console.WriteLine(hewan.Suara());
            }

            Console.WriteLine("\nMemanggil Method Khusus:");
            singa.Mengaum();
            ular.Merayap();

            Console.ReadLine();
        }
    }
}
