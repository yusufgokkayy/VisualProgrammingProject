using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    partial class KayitForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtSifreTekrar = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.btnKayit = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            // lblBaslik
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(120, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(160, 24);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kullanýcý Kaydý";
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(30, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanýcý Adý:";
            
            // txtKullaniciAdi
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtKullaniciAdi.Location = new System.Drawing.Point(150, 67);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(200, 21);
            this.txtKullaniciAdi.TabIndex = 2;
            
            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(30, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Þifre:";
            
            // txtSifre
            this.txtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSifre.Location = new System.Drawing.Point(150, 102);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(200, 21);
            this.txtSifre.TabIndex = 4;
            
            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(30, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Þifre Tekrar:";
            
            // txtSifreTekrar
            this.txtSifreTekrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSifreTekrar.Location = new System.Drawing.Point(150, 137);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.PasswordChar = '*';
            this.txtSifreTekrar.Size = new System.Drawing.Size(200, 21);
            this.txtSifreTekrar.TabIndex = 6;
            
            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(30, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ad:";
            
            // txtAd
            this.txtAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtAd.Location = new System.Drawing.Point(150, 172);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(200, 21);
            this.txtAd.TabIndex = 8;
            
            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(30, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Soyad:";
            
            // txtSoyad
            this.txtSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSoyad.Location = new System.Drawing.Point(150, 207);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(200, 21);
            this.txtSoyad.TabIndex = 10;
            
            // label6
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(30, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Email:";
            
            // txtEmail
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtEmail.Location = new System.Drawing.Point(150, 242);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 21);
            this.txtEmail.TabIndex = 12;
            
            // label7
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(30, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Telefon:";
            
            // txtTelefon
            this.txtTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTelefon.Location = new System.Drawing.Point(150, 277);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(200, 21);
            this.txtTelefon.TabIndex = 14;
            
            // btnKayit
            this.btnKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnKayit.Location = new System.Drawing.Point(150, 320);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new System.Drawing.Size(90, 30);
            this.btnKayit.TabIndex = 15;
            this.btnKayit.Text = "Kayýt Ol";
            this.btnKayit.UseVisualStyleBackColor = true;
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            
            // btnIptal
            this.btnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnIptal.Location = new System.Drawing.Point(260, 320);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(90, 30);
            this.btnIptal.TabIndex = 16;
            this.btnIptal.Text = "Ýptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            
            // KayitForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKayit);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSifreTekrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KayitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanýcý Kaydý";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtSifreTekrar;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Button btnKayit;
        private System.Windows.Forms.Button btnIptal;
    }
}
