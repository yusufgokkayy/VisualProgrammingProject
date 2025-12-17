using System;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    public partial class BiletAlForm : Form
    {
        private Tren seciliTren;
        public string BiletNo { get; private set; }

        public BiletAlForm(Tren tren)
        {
            InitializeComponent();
            seciliTren = tren;
            
            lblBilgiler.Text = "Tren No: " + tren.TrenNo + "\n" +
                              "Güzergah: " + tren.Nereden + " - " + tren.Nereye + "\n" +
                              "Tarih: " + tren.Tarih.ToShortDateString() + "\n" +
                              "Saat: " + tren.Saat + "\n" +
                              "Fiyat: " + tren.Fiyat.ToString("C") + "\n" +
                              "Boþ Koltuk: " + tren.BosKoltuk;
            
            // Kullanýcý bilgilerini boþ býrak - kullanýcý manuel girecek
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTC.Text = "";
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string tc = txtTC.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(tc))
            {
                MessageBox.Show("Lütfen tüm alanlarý doldurun!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tc.Length != 11)
            {
                MessageBox.Show("TC Kimlik No 11 haneli olmalýdýr!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long tcNo;
            if (!long.TryParse(tc, out tcNo))
            {
                MessageBox.Show("TC Kimlik No sadece rakam içermelidir!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BiletNo = VeriYoneticisi.BiletOlustur(seciliTren, ad, soyad, tc);
            
            if (!string.IsNullOrEmpty(BiletNo))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Bilet oluþturulurken bir hata oluþtu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
