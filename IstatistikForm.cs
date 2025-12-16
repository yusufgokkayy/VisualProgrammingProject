using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    public partial class IstatistikForm : Form
    {
        private List<PieSlice> sehirSlices = new List<PieSlice>();
        private List<PieSlice> gunlukSlices = new List<PieSlice>();
        private List<PieSlice> trenSlices = new List<PieSlice>();

        public IstatistikForm()
        {
            InitializeComponent();
        }

        private void IstatistikForm_Load(object sender, EventArgs e)
        {
            IstatistikleriYukle();
        }

        private void IstatistikleriYukle()
        {
            var biletler = VeriYoneticisi.BiletleriGetir();

            if (biletler.Count == 0)
            {
                MessageBox.Show("Henüz satýlmýþ bilet bulunmamaktadýr.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Genel istatistikler
            int toplamBilet = biletler.Count;
            decimal toplamGelir = biletler.Sum(b => b.Fiyat);
            decimal ortalamaFiyat = toplamGelir / toplamBilet;

            lblToplamBilet.Text = $"?? Toplam Bilet: {toplamBilet}";
            lblToplamGelir.Text = $"?? Toplam Gelir: {toplamGelir:N2} ?";
            lblOrtalamaFiyat.Text = $"?? Ortalama Fiyat: {ortalamaFiyat:N2} ?";

            // Renkler
            Color[] colors = new Color[]
            {
                Color.FromArgb(52, 152, 219),   // Mavi
                Color.FromArgb(46, 204, 113),   // Yeþil
                Color.FromArgb(155, 89, 182),   // Mor
                Color.FromArgb(241, 196, 15),   // Sarý
                Color.FromArgb(231, 76, 60),    // Kýrmýzý
                Color.FromArgb(230, 126, 34),   // Turuncu
                Color.FromArgb(26, 188, 156),   // Turkuaz
                Color.FromArgb(52, 73, 94)      // Gri-Mavi
            };

            // 1. Þehirlere göre satýþlar
            var sehirSatislari = biletler
                .GroupBy(b => b.Nereye)
                .Select(g => new { Sehir = g.Key, Adet = g.Count() })
                .OrderByDescending(x => x.Adet)
                .Take(5)
                .ToList();

            float totalSehir = sehirSatislari.Sum(x => x.Adet);
            sehirSlices.Clear();
            
            for (int i = 0; i < sehirSatislari.Count; i++)
            {
                float percentage = (sehirSatislari[i].Adet / totalSehir) * 100;
                sehirSlices.Add(new PieSlice
                {
                    Label = sehirSatislari[i].Sehir,
                    Value = sehirSatislari[i].Adet,
                    Percentage = percentage,
                    Color = colors[i % colors.Length]
                });
            }

            // 2. Günlük satýþlar
            var gunlukSatislar = biletler
                .GroupBy(b => b.Tarih.Date)
                .Select(g => new { Tarih = g.Key, Adet = g.Count() })
                .OrderBy(x => x.Tarih)
                .ToList();

            float totalGunluk = gunlukSatislar.Sum(x => x.Adet);
            gunlukSlices.Clear();

            for (int i = 0; i < gunlukSatislar.Count; i++)
            {
                float percentage = (gunlukSatislar[i].Adet / totalGunluk) * 100;
                gunlukSlices.Add(new PieSlice
                {
                    Label = gunlukSatislar[i].Tarih.ToString("dd/MM"),
                    Value = gunlukSatislar[i].Adet,
                    Percentage = percentage,
                    Color = colors[i % colors.Length]
                });
            }

            // 3. Trenlere göre gelir
            var trenGelir = biletler
                .GroupBy(b => b.TrenNo)
                .Select(g => new { TrenNo = g.Key, Gelir = g.Sum(b => b.Fiyat) })
                .OrderByDescending(x => x.Gelir)
                .Take(6)
                .ToList();

            float totalTren = (float)trenGelir.Sum(x => x.Gelir);
            trenSlices.Clear();

            for (int i = 0; i < trenGelir.Count; i++)
            {
                float percentage = ((float)trenGelir[i].Gelir / totalTren) * 100;
                trenSlices.Add(new PieSlice
                {
                    Label = trenGelir[i].TrenNo,
                    Value = (float)trenGelir[i].Gelir,
                    Percentage = percentage,
                    Color = colors[i % colors.Length]
                });
            }

            // Legend panellerini temizle ve doldur
            CreateLegend(panelLegendSehir, sehirSlices, false);
            CreateLegend(panelLegendGun, gunlukSlices, false);
            CreateLegend(panelLegendTren, trenSlices, true);

            // Panelleri yeniden çiz
            panelSehirler.Invalidate();
            panelGunluk.Invalidate();
            panelTrenler.Invalidate();
        }

        private void CreateLegend(Panel panel, List<PieSlice> slices, bool isCurrency)
        {
            panel.Controls.Clear();
            
            int x = 10;
            int y = 10;
            int itemWidth = 160;

            for (int i = 0; i < slices.Count; i++)
            {
                // Renk kutusu
                Panel colorBox = new Panel
                {
                    BackColor = slices[i].Color,
                    Size = new Size(15, 15),
                    Location = new Point(x, y)
                };
                panel.Controls.Add(colorBox);

                // Etiket
                string valueText = isCurrency ? $"{slices[i].Value:N0} ?" : $"{slices[i].Value}";
                Label label = new Label
                {
                    Text = $"{slices[i].Label}: {valueText} ({slices[i].Percentage:F1}%)",
                    Location = new Point(x + 20, y - 2),
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 8F)
                };
                panel.Controls.Add(label);

                x += itemWidth;
                if (x + itemWidth > panel.Width)
                {
                    x = 10;
                    y += 25;
                }
            }
        }

        private void panelSehirler_Paint(object sender, PaintEventArgs e)
        {
            DrawPieChart(e.Graphics, panelSehirler, sehirSlices);
        }

        private void panelGunluk_Paint(object sender, PaintEventArgs e)
        {
            DrawPieChart(e.Graphics, panelGunluk, gunlukSlices);
        }

        private void panelTrenler_Paint(object sender, PaintEventArgs e)
        {
            DrawPieChart(e.Graphics, panelTrenler, trenSlices);
        }

        private void DrawPieChart(Graphics g, Panel panel, List<PieSlice> slices)
        {
            if (slices.Count == 0) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int diameter = Math.Min(panel.Width, panel.Height) - 40;
            int x = (panel.Width - diameter) / 2;
            int y = (panel.Height - diameter) / 2;
            Rectangle rect = new Rectangle(x, y, diameter, diameter);

            float startAngle = 0;

            foreach (var slice in slices)
            {
                float sweepAngle = (slice.Percentage / 100f) * 360f;

                using (SolidBrush brush = new SolidBrush(slice.Color))
                {
                    g.FillPie(brush, rect, startAngle, sweepAngle);
                }

                // Çizgi çiz
                using (Pen pen = new Pen(Color.White, 2))
                {
                    g.DrawPie(pen, rect, startAngle, sweepAngle);
                }

                // Yüzde yazýsýný ortaya yakýn göster (sadece %5'ten büyük dilimler için)
                if (slice.Percentage > 5)
                {
                    float midAngle = startAngle + (sweepAngle / 2);
                    float radians = (float)(midAngle * Math.PI / 180);
                    
                    float labelRadius = diameter / 3.5f;
                    float labelX = x + (diameter / 2f) + (float)(Math.Cos(radians) * labelRadius);
                    float labelY = y + (diameter / 2f) + (float)(Math.Sin(radians) * labelRadius);

                    string percentText = $"{slice.Percentage:F1}%";
                    
                    using (Font font = new Font("Arial", 9, FontStyle.Bold))
                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        SizeF textSize = g.MeasureString(percentText, font);
                        g.DrawString(percentText, font, textBrush, 
                            labelX - textSize.Width / 2, 
                            labelY - textSize.Height / 2);
                    }
                }

                startAngle += sweepAngle;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class PieSlice
        {
            public string Label { get; set; }
            public float Value { get; set; }
            public float Percentage { get; set; }
            public Color Color { get; set; }
        }
    }
}
