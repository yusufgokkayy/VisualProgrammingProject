using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    partial class KullaniciPanel
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
            this.btnAra = new System.Windows.Forms.Button();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.txtNereye = new System.Windows.Forms.TextBox();
            this.txtNereden = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTrenler = new System.Windows.Forms.DataGridView();
            this.btnBiletAl = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnIptalEt = new System.Windows.Forms.Button();
            this.txtBiletNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvBiletlerim = new System.Windows.Forms.DataGridView();
            this.btnCikis = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrenler)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiletlerim)).BeginInit();
            this.SuspendLayout();
            
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 500);
            this.tabControl1.TabIndex = 0;
            
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnAra);
            this.tabPage1.Controls.Add(this.dtpTarih);
            this.tabPage1.Controls.Add(this.txtNereye);
            this.tabPage1.Controls.Add(this.txtNereden);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dgvTrenler);
            this.tabPage1.Controls.Add(this.btnBiletAl);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(852, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bilet Al";
            
            this.btnAra.Location = new System.Drawing.Point(660, 20);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(150, 30);
            this.btnAra.TabIndex = 8;
            this.btnAra.Text = "Tren Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            
            this.dtpTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpTarih.Location = new System.Drawing.Point(470, 25);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(160, 21);
            this.dtpTarih.TabIndex = 7;
            
            this.txtNereye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNereye.Location = new System.Drawing.Point(270, 25);
            this.txtNereye.Name = "txtNereye";
            this.txtNereye.Size = new System.Drawing.Size(130, 21);
            this.txtNereye.TabIndex = 6;
            
            this.txtNereden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNereden.Location = new System.Drawing.Point(80, 25);
            this.txtNereden.Name = "txtNereden";
            this.txtNereden.Size = new System.Drawing.Size(130, 21);
            this.txtNereden.TabIndex = 5;
            
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(420, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tarih:";
            
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(220, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nereye:";
            
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nereden:";
            
            this.dgvTrenler.AllowUserToAddRows = false;
            this.dgvTrenler.AllowUserToDeleteRows = false;
            this.dgvTrenler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrenler.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrenler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrenler.Location = new System.Drawing.Point(20, 70);
            this.dgvTrenler.MultiSelect = false;
            this.dgvTrenler.Name = "dgvTrenler";
            this.dgvTrenler.ReadOnly = true;
            this.dgvTrenler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrenler.Size = new System.Drawing.Size(810, 340);
            this.dgvTrenler.TabIndex = 1;
            
            this.btnBiletAl.Location = new System.Drawing.Point(680, 420);
            this.btnBiletAl.Name = "btnBiletAl";
            this.btnBiletAl.Size = new System.Drawing.Size(150, 35);
            this.btnBiletAl.TabIndex = 0;
            this.btnBiletAl.Text = "Bilet Al";
            this.btnBiletAl.UseVisualStyleBackColor = true;
            this.btnBiletAl.Click += new System.EventHandler(this.btnBiletAl_Click);
            
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.btnIptalEt);
            this.tabPage2.Controls.Add(this.txtBiletNo);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dgvBiletlerim);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(852, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Biletlerim";
            
            this.btnIptalEt.Location = new System.Drawing.Point(440, 20);
            this.btnIptalEt.Name = "btnIptalEt";
            this.btnIptalEt.Size = new System.Drawing.Size(120, 30);
            this.btnIptalEt.TabIndex = 3;
            this.btnIptalEt.Text = "Ýptal Et";
            this.btnIptalEt.UseVisualStyleBackColor = true;
            this.btnIptalEt.Click += new System.EventHandler(this.btnIptalEt_Click);
            
            this.txtBiletNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtBiletNo.Location = new System.Drawing.Point(100, 25);
            this.txtBiletNo.Name = "txtBiletNo";
            this.txtBiletNo.Size = new System.Drawing.Size(320, 21);
            this.txtBiletNo.TabIndex = 2;
            
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bilet No:";
            
            this.dgvBiletlerim.AllowUserToAddRows = false;
            this.dgvBiletlerim.AllowUserToDeleteRows = false;
            this.dgvBiletlerim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBiletlerim.BackgroundColor = System.Drawing.Color.White;
            this.dgvBiletlerim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBiletlerim.Location = new System.Drawing.Point(20, 70);
            this.dgvBiletlerim.MultiSelect = false;
            this.dgvBiletlerim.Name = "dgvBiletlerim";
            this.dgvBiletlerim.ReadOnly = true;
            this.dgvBiletlerim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBiletlerim.Size = new System.Drawing.Size(810, 385);
            this.dgvBiletlerim.TabIndex = 0;
            
            this.btnCikis.Location = new System.Drawing.Point(760, 520);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(110, 30);
            this.btnCikis.TabIndex = 1;
            this.btnCikis.Text = "Çýkýþ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "KullaniciPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanýcý Paneli";
            this.Load += new System.EventHandler(this.KullaniciPanel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrenler)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiletlerim)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvTrenler;
        private System.Windows.Forms.Button btnBiletAl;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.TextBox txtNereye;
        private System.Windows.Forms.TextBox txtNereden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.DataGridView dgvBiletlerim;
        private System.Windows.Forms.Button btnIptalEt;
        private System.Windows.Forms.TextBox txtBiletNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCikis;
    }
}
