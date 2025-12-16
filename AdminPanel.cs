using System;
using System.Linq;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            VeriYukle();
        }

        private void VeriYukle()
        {
            dgvTrenler.DataSource = null;
            dgvTrenler.DataSource = VeriYoneticisi.TrenleriGetir().OrderBy(t => t.Tarih).ThenBy(t => t.Saat).ToList();

            dgvBiletler.DataSource = null;
            dgvBiletler.DataSource = VeriYoneticisi.BiletleriGetir().OrderBy(b => b.Tarih).ToList();

            IstatistikleriGuncelle();
        }

        private void IstatistikleriGuncelle()
        {
            var biletler = VeriYoneticisi.BiletleriGetir();
            int toplamBilet = biletler.Count;
            decimal toplamGelir = biletler.Sum(b => b.Fiyat);

            lblToplamBilet.Text = "Toplam Bilet: " + toplamBilet;
            lblToplamGelir.Text = "Toplam Gelir: " + toplamGelir.ToString("N2") + " ₺";
        }

        private void btnYenile1_Click(object sender, EventArgs e)
        {
            VeriYukle();
        }

        private void btnYenile2_Click(object sender, EventArgs e)
        {
            VeriYukle();
        }

        private void btnTrenEkle_Click(object sender, EventArgs e)
        {
            string trenNo = txtTrenNo.Text.Trim();
            string nereden = txtNereden.Text.Trim();
            string nereye = txtNereye.Text.Trim();
            DateTime tarih = dtpTarih.Value;
            string saat = txtSaat.Text.Trim();
            string fiyatStr = txtFiyat.Text.Trim();
            string bosKoltukStr = txtBosKoltuk.Text.Trim();

            if (string.IsNullOrEmpty(trenNo) || string.IsNullOrEmpty(nereden) || 
                string.IsNullOrEmpty(nereye) || string.IsNullOrEmpty(saat) || 
                string.IsNullOrEmpty(fiyatStr) || string.IsNullOrEmpty(bosKoltukStr))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal fiyat;
            int bosKoltuk;

            if (!decimal.TryParse(fiyatStr, out fiyat))
            {
                MessageBox.Show("Geçerli bir fiyat girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(bosKoltukStr, out bosKoltuk))
            {
                MessageBox.Show("Geçerli bir koltuk sayısı girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (VeriYoneticisi.TrenVarMi(trenNo))
            {
                MessageBox.Show("Bu tren numarası zaten kullanılıyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tren yeniTren = new Tren(trenNo, nereden, nereye, tarih, saat, fiyat, bosKoltuk);
            VeriYoneticisi.TrenEkle(yeniTren);

            MessageBox.Show("Tren başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtTrenNo.Clear();
            txtNereden.Clear();
            txtNereye.Clear();
            txtSaat.Clear();
            txtFiyat.Clear();
            txtBosKoltuk.Clear();

            VeriYukle();
        }

        private void btnIstatistikler_Click(object sender, EventArgs e)
        {
            IstatistikForm istatistikForm = new IstatistikForm();
            istatistikForm.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 giris = new Form1();
            giris.Show();
        }
    }
}
