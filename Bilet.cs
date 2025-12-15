using System;

namespace VisualProgrammingProject
{
    public class Bilet
    {
        public string BiletNo { get; set; }
        public string TrenNo { get; set; }
        public string Nereden { get; set; }
        public string Nereye { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public string YolcuAd { get; set; }
        public string YolcuSoyad { get; set; }
        public string TC { get; set; }
        public decimal Fiyat { get; set; }
        public string KoltukNo { get; set; }

        public Bilet(string biletNo, string trenNo, string nereden, string nereye, DateTime tarih, string saat, 
                     string yolcuAd, string yolcuSoyad, string tc, decimal fiyat, string koltukNo)
        {
            BiletNo = biletNo;
            TrenNo = trenNo;
            Nereden = nereden;
            Nereye = nereye;
            Tarih = tarih;
            Saat = saat;
            YolcuAd = yolcuAd;
            YolcuSoyad = yolcuSoyad;
            TC = tc;
            Fiyat = fiyat;
            KoltukNo = koltukNo;
        }
    }
}
