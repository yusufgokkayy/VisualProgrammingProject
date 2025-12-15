using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    partial class AdminPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvTrenler = new System.Windows.Forms.DataGridView();
            this.btnYenile1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvBiletler = new System.Windows.Forms.DataGridView();
            this.btnYenile2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnTrenEkle = new System.Windows.Forms.Button();
            this.txtBosKoltuk = new System.Windows.Forms.TextBox();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.txtSaat = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.txtNereye = new System.Windows.Forms.TextBox();
            this.txtNereden = new System.Windows.Forms.TextBox();
            this.txtTrenNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.lblToplamBilet = new System.Windows.Forms.Label();
            this.lblToplamGelir = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrenler)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiletler)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 450);
            this.tabControl1.TabIndex = 0;
            
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dgvTrenler);
            this.tabPage1.Controls.Add(this.btnYenile1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(852, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tren Listesi";
            
            this.dgvTrenler.AllowUserToAddRows = false;
            this.dgvTrenler.AllowUserToDeleteRows = false;
            this.dgvTrenler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrenler.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrenler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrenler.Location = new System.Drawing.Point(20, 20);
            this.dgvTrenler.Name = "dgvTrenler";
            this.dgvTrenler.ReadOnly = true;
            this.dgvTrenler.Size = new System.Drawing.Size(810, 340);
            this.dgvTrenler.TabIndex = 0;
            
            this.btnYenile1.Location = new System.Drawing.Point(710, 370);
            this.btnYenile1.Name = "btnYenile1";
            this.btnYenile1.Size = new System.Drawing.Size(120, 35);
            this.btnYenile1.TabIndex = 1;
            this.btnYenile1.Text = "Yenile";
            this.btnYenile1.UseVisualStyleBackColor = true;
            this.btnYenile1.Click += new System.EventHandler(this.btnYenile1_Click);
            
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.dgvBiletler);
            this.tabPage2.Controls.Add(this.btnYenile2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(852, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Satýlan Biletler";
            
            this.dgvBiletler.AllowUserToAddRows = false;
            this.dgvBiletler.AllowUserToDeleteRows = false;
            this.dgvBiletler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBiletler.BackgroundColor = System.Drawing.Color.White;
            this.dgvBiletler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBiletler.Location = new System.Drawing.Point(20, 20);
            this.dgvBiletler.Name = "dgvBiletler";
            this.dgvBiletler.ReadOnly = true;
            this.dgvBiletler.Size = new System.Drawing.Size(810, 340);
            this.dgvBiletler.TabIndex = 1;
            
            this.btnYenile2.Location = new System.Drawing.Point(710, 370);
            this.btnYenile2.Name = "btnYenile2";
            this.btnYenile2.Size = new System.Drawing.Size(120, 35);
            this.btnYenile2.TabIndex = 2;
            this.btnYenile2.Text = "Yenile";
            this.btnYenile2.UseVisualStyleBackColor = true;
            this.btnYenile2.Click += new System.EventHandler(this.btnYenile2_Click);
            
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.btnTrenEkle);
            this.tabPage3.Controls.Add(this.txtBosKoltuk);
            this.tabPage3.Controls.Add(this.txtFiyat);
            this.tabPage3.Controls.Add(this.txtSaat);
            this.tabPage3.Controls.Add(this.dtpTarih);
            this.tabPage3.Controls.Add(this.txtNereye);
            this.tabPage3.Controls.Add(this.txtNereden);
            this.tabPage3.Controls.Add(this.txtTrenNo);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(852, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tren Ekle";
            
            this.btnTrenEkle.Location = new System.Drawing.Point(200, 340);
            this.btnTrenEkle.Name = "btnTrenEkle";
            this.btnTrenEkle.Size = new System.Drawing.Size(200, 40);
            this.btnTrenEkle.TabIndex = 14;
            this.btnTrenEkle.Text = "Tren Ekle";
            this.btnTrenEkle.UseVisualStyleBackColor = true;
            this.btnTrenEkle.Click += new System.EventHandler(this.btnTrenEkle_Click);
            
            this.txtBosKoltuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtBosKoltuk.Location = new System.Drawing.Point(200, 290);
            this.txtBosKoltuk.Name = "txtBosKoltuk";
            this.txtBosKoltuk.Size = new System.Drawing.Size(200, 21);
            this.txtBosKoltuk.TabIndex = 13;
            
            this.txtFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtFiyat.Location = new System.Drawing.Point(200, 250);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(200, 21);
            this.txtFiyat.TabIndex = 12;
            
            this.txtSaat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSaat.Location = new System.Drawing.Point(200, 210);
            this.txtSaat.Name = "txtSaat";
            this.txtSaat.Size = new System.Drawing.Size(200, 21);
            this.txtSaat.TabIndex = 11;
            
            this.dtpTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpTarih.Location = new System.Drawing.Point(200, 170);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(200, 21);
            this.dtpTarih.TabIndex = 10;
            
            this.txtNereye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNereye.Location = new System.Drawing.Point(200, 130);
            this.txtNereye.Name = "txtNereye";
            this.txtNereye.Size = new System.Drawing.Size(200, 21);
            this.txtNereye.TabIndex = 9;
            
            this.txtNereden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNereden.Location = new System.Drawing.Point(200, 90);
            this.txtNereden.Name = "txtNereden";
            this.txtNereden.Size = new System.Drawing.Size(200, 21);
            this.txtNereden.TabIndex = 8;
            
            this.txtTrenNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTrenNo.Location = new System.Drawing.Point(200, 50);
            this.txtTrenNo.Name = "txtTrenNo";
            this.txtTrenNo.Size = new System.Drawing.Size(200, 21);
            this.txtTrenNo.TabIndex = 7;
            
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(100, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Boþ Koltuk:";
            
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(100, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fiyat:";
            
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(100, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Saat:";
            
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(100, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tarih:";
            
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(100, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nereye:";
            
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(100, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nereden:";
            
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(100, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tren No:";
            
            this.btnCikis.Location = new System.Drawing.Point(760, 510);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(110, 30);
            this.btnCikis.TabIndex = 1;
            this.btnCikis.Text = "Çýkýþ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            
            this.lblToplamBilet.AutoSize = true;
            this.lblToplamBilet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblToplamBilet.Location = new System.Drawing.Point(20, 475);
            this.lblToplamBilet.Name = "lblToplamBilet";
            this.lblToplamBilet.Size = new System.Drawing.Size(143, 17);
            this.lblToplamBilet.TabIndex = 2;
            this.lblToplamBilet.Text = "Toplam Bilet: 0";
            
            this.lblToplamGelir.AutoSize = true;
            this.lblToplamGelir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblToplamGelir.Location = new System.Drawing.Point(20, 505);
            this.lblToplamGelir.Name = "lblToplamGelir";
            this.lblToplamGelir.Size = new System.Drawing.Size(166, 17);
            this.lblToplamGelir.TabIndex = 3;
            this.lblToplamGelir.Text = "Toplam Gelir: 0.00 ?";
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 551);
            this.Controls.Add(this.lblToplamGelir);
            this.Controls.Add(this.lblToplamBilet);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Paneli";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrenler)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiletler)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvTrenler;
        private System.Windows.Forms.Button btnYenile1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvBiletler;
        private System.Windows.Forms.Button btnYenile2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTrenNo;
        private System.Windows.Forms.TextBox txtNereden;
        private System.Windows.Forms.TextBox txtNereye;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.TextBox txtSaat;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.TextBox txtBosKoltuk;
        private System.Windows.Forms.Button btnTrenEkle;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label lblToplamBilet;
        private System.Windows.Forms.Label lblToplamGelir;
    }
}
