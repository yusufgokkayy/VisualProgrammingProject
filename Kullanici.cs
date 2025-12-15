using System;

namespace VisualProgrammingProject
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool IsAdmin { get; set; }

        public Kullanici()
        {
            KayitTarihi = DateTime.Now;
            IsAdmin = false;
        }

        public Kullanici(int id, string kullaniciAdi, string sifre, string ad, string soyad, string email, string telefon, DateTime kayitTarihi, bool isAdmin)
        {
            Id = id;
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            Ad = ad;
            Soyad = soyad;
            Email = email;
            Telefon = telefon;
            KayitTarihi = kayitTarihi;
            IsAdmin = isAdmin;
        }
    }
}
