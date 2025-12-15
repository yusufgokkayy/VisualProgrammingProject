using System;

namespace VisualProgrammingProject
{
    public class Tren
    {
        public string TrenNo { get; set; }
        public string Nereden { get; set; }
        public string Nereye { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public decimal Fiyat { get; set; }
        public int BosKoltuk { get; set; }

        public Tren(string trenNo, string nereden, string nereye, DateTime tarih, string saat, decimal fiyat, int bosKoltuk)
        {
            TrenNo = trenNo;
            Nereden = nereden;
            Nereye = nereye;
            Tarih = tarih;
            Saat = saat;
            Fiyat = fiyat;
            BosKoltuk = bosKoltuk;
        }
    }
}
