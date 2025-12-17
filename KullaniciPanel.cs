using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    public partial class KullaniciPanel : Form
    {
        public KullaniciPanel()
        {
            InitializeComponent();
        }

        private void KullaniciPanel_Load(object sender, EventArgs e)
        {
            // DataGridView font ve encoding ayarlarý
            dgvTrenler.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dgvBiletlerim.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            
            TrenleriYukle();
            BiletleriYukle();
        }

        private void TrenleriYukle()
        {
            dgvTrenler.DataSource = null;
            dgvTrenler.DataSource = VeriYoneticisi.TrenleriGetir().OrderBy(t => t.Tarih).ThenBy(t => t.Saat).ToList();
        }

        private void BiletleriYukle()
        {
            dgvBiletlerim.DataSource = null;
            if (Session.AktifKullanici != null && !string.IsNullOrEmpty(Session.AktifKullanici.TC))
            {
                dgvBiletlerim.DataSource = VeriYoneticisi.KullaniciBiletleriGetir(Session.AktifKullanici.TC).OrderBy(b => b.Tarih).ToList();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string nereden = txtNereden.Text.Trim();
            string nereye = txtNereye.Text.Trim();
            // Tarih kontrolünü düzeltiyoruz - boþ string yerine null gönderiyoruz
            DateTime? tarih = string.IsNullOrEmpty(nereden) && string.IsNullOrEmpty(nereye) ? (DateTime?)null : dtpTarih.Value.Date;

            List<Tren> sonuc = VeriYoneticisi.TrenAra(nereden, nereye, tarih);
            dgvTrenler.DataSource = null;
            dgvTrenler.DataSource = sonuc.OrderBy(t => t.Tarih).ThenBy(t => t.Saat).ToList();

            if (sonuc.Count == 0)
            {
                MessageBox.Show("Arama kriterlerine uygun tren bulunamadý.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBiletAl_Click(object sender, EventArgs e)
        {
            if (dgvTrenler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir tren seçin!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tren seciliTren = (Tren)dgvTrenler.SelectedRows[0].DataBoundItem;

            if (seciliTren.BosKoltuk <= 0)
            {
                MessageBox.Show("Bu tren için boþ koltuk bulunmamaktadýr.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BiletAlForm form = new BiletAlForm(seciliTren);
            if (form.ShowDialog() == DialogResult.OK)
            {
                TrenleriYukle();
                BiletleriYukle();
                MessageBox.Show("Biletiniz baþarýyla oluþturuldu!\nBilet No: " + form.BiletNo, "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIptalEt_Click(object sender, EventArgs e)
        {
            string biletNo = txtBiletNo.Text.Trim();

            if (string.IsNullOrEmpty(biletNo))
            {
                MessageBox.Show("Lütfen bilet numarasý girin!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var bilet = VeriYoneticisi.BiletBul(biletNo);
            if (bilet == null)
            {
                MessageBox.Show("Bilet bulunamadý!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult sonuc = MessageBox.Show("Bu bileti iptal etmek istediðinize emin misiniz?\n\nBilet No: " + bilet.BiletNo + 
                                                 "\nTren: " + bilet.TrenNo + "\nGüzergah: " + bilet.Nereden + " - " + bilet.Nereye,
                                                 "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                if (VeriYoneticisi.BiletIptal(biletNo))
                {
                    MessageBox.Show("Bilet baþarýyla iptal edildi.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TrenleriYukle();
                    BiletleriYukle();
                    txtBiletNo.Clear();
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 giris = new Form1();
            giris.Show();
        }
    }
}
