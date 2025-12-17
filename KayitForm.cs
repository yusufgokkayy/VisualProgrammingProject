using System;
using System.Linq;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    public partial class KayitForm : Form
    {
        public KayitForm()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string sifreTekrar = txtSifreTekrar.Text.Trim();
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefon = txtTelefon.Text.Trim();
            string tc = txtTC.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || 
                string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad))
            {
                MessageBox.Show("Kullanýcý adý, þifre, ad ve soyad alanlarý zorunludur!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kullaniciAdi.Length < 3)
            {
                MessageBox.Show("Kullanýcý adý en az 3 karakter olmalýdýr!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sifre.Length < 3)
            {
                MessageBox.Show("Þifre en az 3 karakter olmalýdýr!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Þifreler eþleþmiyor!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(tc) && tc.Length != 11)
            {
                MessageBox.Show("TC Kimlik No 11 haneli olmalýdýr!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(tc) && !tc.All(char.IsDigit))
            {
                MessageBox.Show("TC Kimlik No sadece rakam içermelidir!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (VeriYoneticisi.KullaniciVarMi(kullaniciAdi))
            {
                MessageBox.Show("Bu kullanýcý adý zaten kullanýlýyor!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sonuc = VeriYoneticisi.KullaniciKaydet(kullaniciAdi, sifre, ad, soyad, email, telefon, tc);

            if (sonuc)
            {
                MessageBox.Show("Kayýt baþarýlý! Þimdi giriþ yapabilirsiniz.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Kayýt sýrasýnda bir hata oluþtu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
