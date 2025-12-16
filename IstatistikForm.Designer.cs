namespace VisualProgrammingProject
{
    partial class IstatistikForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSehirler = new System.Windows.Forms.Panel();
            this.panelGunluk = new System.Windows.Forms.Panel();
            this.panelTrenler = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKapat = new System.Windows.Forms.Button();
            this.lblToplamBilet = new System.Windows.Forms.Label();
            this.lblToplamGelir = new System.Windows.Forms.Label();
            this.lblOrtalamaFiyat = new System.Windows.Forms.Label();
            this.panelLegendSehir = new System.Windows.Forms.Panel();
            this.panelLegendGun = new System.Windows.Forms.Panel();
            this.panelLegendTren = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelSehirler
            // 
            this.panelSehirler.BackColor = System.Drawing.Color.White;
            this.panelSehirler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSehirler.Location = new System.Drawing.Point(20, 60);
            this.panelSehirler.Name = "panelSehirler";
            this.panelSehirler.Size = new System.Drawing.Size(340, 260);
            this.panelSehirler.TabIndex = 0;
            this.panelSehirler.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSehirler_Paint);
            // 
            // panelGunluk
            // 
            this.panelGunluk.BackColor = System.Drawing.Color.White;
            this.panelGunluk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGunluk.Location = new System.Drawing.Point(380, 60);
            this.panelGunluk.Name = "panelGunluk";
            this.panelGunluk.Size = new System.Drawing.Size(340, 260);
            this.panelGunluk.TabIndex = 1;
            this.panelGunluk.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGunluk_Paint);
            // 
            // panelTrenler
            // 
            this.panelTrenler.BackColor = System.Drawing.Color.White;
            this.panelTrenler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTrenler.Location = new System.Drawing.Point(740, 60);
            this.panelTrenler.Name = "panelTrenler";
            this.panelTrenler.Size = new System.Drawing.Size(340, 260);
            this.panelTrenler.TabIndex = 2;
            this.panelTrenler.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTrenler_Paint);
            // 
            // panelLegendSehir
            // 
            this.panelLegendSehir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLegendSehir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLegendSehir.Location = new System.Drawing.Point(20, 325);
            this.panelLegendSehir.Name = "panelLegendSehir";
            this.panelLegendSehir.Size = new System.Drawing.Size(340, 80);
            this.panelLegendSehir.TabIndex = 10;
            // 
            // panelLegendGun
            // 
            this.panelLegendGun.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLegendGun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLegendGun.Location = new System.Drawing.Point(380, 325);
            this.panelLegendGun.Name = "panelLegendGun";
            this.panelLegendGun.Size = new System.Drawing.Size(340, 80);
            this.panelLegendGun.TabIndex = 11;
            // 
            // panelLegendTren
            // 
            this.panelLegendTren.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLegendTren.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLegendTren.Location = new System.Drawing.Point(740, 325);
            this.panelLegendTren.Name = "panelLegendTren";
            this.panelLegendTren.Size = new System.Drawing.Size(340, 80);
            this.panelLegendTren.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(90, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Varýþ Þehrine Göre Satýþlar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(440, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Günlük Bilet Satýþ Daðýlýmý";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(820, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trenlere Göre Gelir (?)";
            // 
            // btnKapat
            // 
            this.btnKapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnKapat.Location = new System.Drawing.Point(960, 470);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(120, 35);
            this.btnKapat.TabIndex = 6;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // lblToplamBilet
            // 
            this.lblToplamBilet.AutoSize = true;
            this.lblToplamBilet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplamBilet.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblToplamBilet.Location = new System.Drawing.Point(30, 425);
            this.lblToplamBilet.Name = "lblToplamBilet";
            this.lblToplamBilet.Size = new System.Drawing.Size(143, 20);
            this.lblToplamBilet.TabIndex = 7;
            this.lblToplamBilet.Text = "Toplam Bilet: 0";
            // 
            // lblToplamGelir
            // 
            this.lblToplamGelir.AutoSize = true;
            this.lblToplamGelir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplamGelir.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblToplamGelir.Location = new System.Drawing.Point(30, 455);
            this.lblToplamGelir.Name = "lblToplamGelir";
            this.lblToplamGelir.Size = new System.Drawing.Size(175, 20);
            this.lblToplamGelir.TabIndex = 8;
            this.lblToplamGelir.Text = "Toplam Gelir: 0.00 ?";
            // 
            // lblOrtalamaFiyat
            // 
            this.lblOrtalamaFiyat.AutoSize = true;
            this.lblOrtalamaFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrtalamaFiyat.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrtalamaFiyat.Location = new System.Drawing.Point(30, 485);
            this.lblOrtalamaFiyat.Name = "lblOrtalamaFiyat";
            this.lblOrtalamaFiyat.Size = new System.Drawing.Size(207, 20);
            this.lblOrtalamaFiyat.TabIndex = 9;
            this.lblOrtalamaFiyat.Text = "Ortalama Fiyat: 0.00 ?";
            // 
            // IstatistikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 520);
            this.Controls.Add(this.panelLegendTren);
            this.Controls.Add(this.panelLegendGun);
            this.Controls.Add(this.panelLegendSehir);
            this.Controls.Add(this.lblOrtalamaFiyat);
            this.Controls.Add(this.lblToplamGelir);
            this.Controls.Add(this.lblToplamBilet);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelTrenler);
            this.Controls.Add(this.panelGunluk);
            this.Controls.Add(this.panelSehirler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "IstatistikForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ýstatistikler - Admin Panel";
            this.Load += new System.EventHandler(this.IstatistikForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSehirler;
        private System.Windows.Forms.Panel panelGunluk;
        private System.Windows.Forms.Panel panelTrenler;
        private System.Windows.Forms.Panel panelLegendSehir;
        private System.Windows.Forms.Panel panelLegendGun;
        private System.Windows.Forms.Panel panelLegendTren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Label lblToplamBilet;
        private System.Windows.Forms.Label lblToplamGelir;
        private System.Windows.Forms.Label lblOrtalamaFiyat;
    }
}
