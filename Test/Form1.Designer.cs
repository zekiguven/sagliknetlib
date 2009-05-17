namespace Test
{
    partial class frmMesajTestEkraný
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcMesajlar = new System.Windows.Forms.TabControl();
            this.tpVatandasYabanciHastaKayit = new System.Windows.Forms.TabPage();
            this.tpDokumanBilgileri = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVatandasTCKimlikNo = new System.Windows.Forms.TextBox();
            this.tbVatandasAdi = new System.Windows.Forms.TextBox();
            this.tbVatandasSoyadi = new System.Windows.Forms.TextBox();
            this.tbVatandasUyrukKodu = new System.Windows.Forms.TextBox();
            this.tbVatandasUyrukAciklama = new System.Windows.Forms.TextBox();
            this.tbVatandasCinsiyetKodu = new System.Windows.Forms.TextBox();
            this.tbVatandasCinsiyetAciklama = new System.Windows.Forms.TextBox();
            this.dtVatandasDogumTarihi = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bXMLOlustur = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDokumanGuid = new System.Windows.Forms.TextBox();
            this.tbDokumanOlusturanKurum = new System.Windows.Forms.TextBox();
            this.dtDokumanIslemZamani = new System.Windows.Forms.DateTimePicker();
            this.tbDokumanYazarTCKimlikNo = new System.Windows.Forms.TextBox();
            this.tbXML = new System.Windows.Forms.TextBox();
            this.tcMesajlar.SuspendLayout();
            this.tpVatandasYabanciHastaKayit.SuspendLayout();
            this.tpDokumanBilgileri.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMesajlar
            // 
            this.tcMesajlar.Controls.Add(this.tpDokumanBilgileri);
            this.tcMesajlar.Controls.Add(this.tpVatandasYabanciHastaKayit);
            this.tcMesajlar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcMesajlar.Location = new System.Drawing.Point(0, 0);
            this.tcMesajlar.Name = "tcMesajlar";
            this.tcMesajlar.SelectedIndex = 0;
            this.tcMesajlar.Size = new System.Drawing.Size(540, 245);
            this.tcMesajlar.TabIndex = 0;
            // 
            // tpVatandasYabanciHastaKayit
            // 
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.dtVatandasDogumTarihi);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.tbVatandasCinsiyetAciklama);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.tbVatandasCinsiyetKodu);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.tbVatandasUyrukAciklama);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.tbVatandasUyrukKodu);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.tbVatandasSoyadi);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.tbVatandasAdi);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.tbVatandasTCKimlikNo);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.label6);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.label5);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.label4);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.label3);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.label2);
            this.tpVatandasYabanciHastaKayit.Controls.Add(this.label1);
            this.tpVatandasYabanciHastaKayit.Location = new System.Drawing.Point(4, 22);
            this.tpVatandasYabanciHastaKayit.Name = "tpVatandasYabanciHastaKayit";
            this.tpVatandasYabanciHastaKayit.Padding = new System.Windows.Forms.Padding(3);
            this.tpVatandasYabanciHastaKayit.Size = new System.Drawing.Size(532, 176);
            this.tpVatandasYabanciHastaKayit.TabIndex = 0;
            this.tpVatandasYabanciHastaKayit.Text = "Vatandaþ, Yabancý Hasta Kayýt";
            this.tpVatandasYabanciHastaKayit.UseVisualStyleBackColor = true;
            // 
            // tpDokumanBilgileri
            // 
            this.tpDokumanBilgileri.Controls.Add(this.tbDokumanYazarTCKimlikNo);
            this.tpDokumanBilgileri.Controls.Add(this.dtDokumanIslemZamani);
            this.tpDokumanBilgileri.Controls.Add(this.tbDokumanOlusturanKurum);
            this.tpDokumanBilgileri.Controls.Add(this.tbDokumanGuid);
            this.tpDokumanBilgileri.Controls.Add(this.label10);
            this.tpDokumanBilgileri.Controls.Add(this.label9);
            this.tpDokumanBilgileri.Controls.Add(this.label8);
            this.tpDokumanBilgileri.Controls.Add(this.label7);
            this.tpDokumanBilgileri.Location = new System.Drawing.Point(4, 22);
            this.tpDokumanBilgileri.Name = "tpDokumanBilgileri";
            this.tpDokumanBilgileri.Padding = new System.Windows.Forms.Padding(3);
            this.tpDokumanBilgileri.Size = new System.Drawing.Size(532, 219);
            this.tpDokumanBilgileri.TabIndex = 1;
            this.tpDokumanBilgileri.Text = "Döküman Bilgileri";
            this.tpDokumanBilgileri.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TCKimlik No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adý";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Soyadý";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Uyruk";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cinsiyet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Doðum Tarihi";
            // 
            // tbVatandasTCKimlikNo
            // 
            this.tbVatandasTCKimlikNo.Location = new System.Drawing.Point(79, 5);
            this.tbVatandasTCKimlikNo.Name = "tbVatandasTCKimlikNo";
            this.tbVatandasTCKimlikNo.Size = new System.Drawing.Size(100, 20);
            this.tbVatandasTCKimlikNo.TabIndex = 6;
            this.tbVatandasTCKimlikNo.Text = "12345678901";
            // 
            // tbVatandasAdi
            // 
            this.tbVatandasAdi.Location = new System.Drawing.Point(79, 31);
            this.tbVatandasAdi.Name = "tbVatandasAdi";
            this.tbVatandasAdi.Size = new System.Drawing.Size(100, 20);
            this.tbVatandasAdi.TabIndex = 7;
            this.tbVatandasAdi.Text = "Kayýt";
            // 
            // tbVatandasSoyadi
            // 
            this.tbVatandasSoyadi.Location = new System.Drawing.Point(79, 54);
            this.tbVatandasSoyadi.Name = "tbVatandasSoyadi";
            this.tbVatandasSoyadi.Size = new System.Drawing.Size(100, 20);
            this.tbVatandasSoyadi.TabIndex = 8;
            this.tbVatandasSoyadi.Text = "Vatandaþ";
            // 
            // tbVatandasUyrukKodu
            // 
            this.tbVatandasUyrukKodu.Location = new System.Drawing.Point(79, 79);
            this.tbVatandasUyrukKodu.Name = "tbVatandasUyrukKodu";
            this.tbVatandasUyrukKodu.Size = new System.Drawing.Size(35, 20);
            this.tbVatandasUyrukKodu.TabIndex = 9;
            this.tbVatandasUyrukKodu.Text = "TR";
            // 
            // tbVatandasUyrukAciklama
            // 
            this.tbVatandasUyrukAciklama.Location = new System.Drawing.Point(120, 79);
            this.tbVatandasUyrukAciklama.Name = "tbVatandasUyrukAciklama";
            this.tbVatandasUyrukAciklama.Size = new System.Drawing.Size(160, 20);
            this.tbVatandasUyrukAciklama.TabIndex = 10;
            this.tbVatandasUyrukAciklama.Text = "Türkiye";
            // 
            // tbVatandasCinsiyetKodu
            // 
            this.tbVatandasCinsiyetKodu.Location = new System.Drawing.Point(79, 107);
            this.tbVatandasCinsiyetKodu.Name = "tbVatandasCinsiyetKodu";
            this.tbVatandasCinsiyetKodu.Size = new System.Drawing.Size(35, 20);
            this.tbVatandasCinsiyetKodu.TabIndex = 11;
            this.tbVatandasCinsiyetKodu.Text = "1";
            // 
            // tbVatandasCinsiyetAciklama
            // 
            this.tbVatandasCinsiyetAciklama.Location = new System.Drawing.Point(120, 107);
            this.tbVatandasCinsiyetAciklama.Name = "tbVatandasCinsiyetAciklama";
            this.tbVatandasCinsiyetAciklama.Size = new System.Drawing.Size(160, 20);
            this.tbVatandasCinsiyetAciklama.TabIndex = 12;
            this.tbVatandasCinsiyetAciklama.Text = "Erkek";
            // 
            // dtVatandasDogumTarihi
            // 
            this.dtVatandasDogumTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVatandasDogumTarihi.Location = new System.Drawing.Point(79, 133);
            this.dtVatandasDogumTarihi.Name = "dtVatandasDogumTarihi";
            this.dtVatandasDogumTarihi.Size = new System.Drawing.Size(100, 20);
            this.dtVatandasDogumTarihi.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bXMLOlustur);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 38);
            this.panel1.TabIndex = 3;
            // 
            // bXMLOlustur
            // 
            this.bXMLOlustur.Location = new System.Drawing.Point(12, 9);
            this.bXMLOlustur.Name = "bXMLOlustur";
            this.bXMLOlustur.Size = new System.Drawing.Size(126, 23);
            this.bXMLOlustur.TabIndex = 0;
            this.bXMLOlustur.Text = "XML oluþtur";
            this.bXMLOlustur.UseVisualStyleBackColor = true;
            this.bXMLOlustur.Click += new System.EventHandler(this.bXMLOlustur_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Guid";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Oluþturan Kurum";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ýþlem zamaný";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Yazar TC KimlikNo";
            // 
            // tbDokumanGuid
            // 
            this.tbDokumanGuid.Location = new System.Drawing.Point(119, 10);
            this.tbDokumanGuid.Name = "tbDokumanGuid";
            this.tbDokumanGuid.Size = new System.Drawing.Size(247, 20);
            this.tbDokumanGuid.TabIndex = 1;
            // 
            // tbDokumanOlusturanKurum
            // 
            this.tbDokumanOlusturanKurum.Location = new System.Drawing.Point(119, 39);
            this.tbDokumanOlusturanKurum.Name = "tbDokumanOlusturanKurum";
            this.tbDokumanOlusturanKurum.Size = new System.Drawing.Size(161, 20);
            this.tbDokumanOlusturanKurum.TabIndex = 3;
            this.tbDokumanOlusturanKurum.Text = "00000";
            // 
            // dtDokumanIslemZamani
            // 
            this.dtDokumanIslemZamani.CustomFormat = "dd/mm/yyyy hh:MM:ss";
            this.dtDokumanIslemZamani.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDokumanIslemZamani.Location = new System.Drawing.Point(119, 65);
            this.dtDokumanIslemZamani.Name = "dtDokumanIslemZamani";
            this.dtDokumanIslemZamani.Size = new System.Drawing.Size(200, 20);
            this.dtDokumanIslemZamani.TabIndex = 5;
            // 
            // tbDokumanYazarTCKimlikNo
            // 
            this.tbDokumanYazarTCKimlikNo.Location = new System.Drawing.Point(119, 91);
            this.tbDokumanYazarTCKimlikNo.Name = "tbDokumanYazarTCKimlikNo";
            this.tbDokumanYazarTCKimlikNo.Size = new System.Drawing.Size(100, 20);
            this.tbDokumanYazarTCKimlikNo.TabIndex = 7;
            this.tbDokumanYazarTCKimlikNo.Text = "98765432109";
            // 
            // tbXML
            // 
            this.tbXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbXML.Location = new System.Drawing.Point(0, 283);
            this.tbXML.Multiline = true;
            this.tbXML.Name = "tbXML";
            this.tbXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbXML.Size = new System.Drawing.Size(540, 110);
            this.tbXML.TabIndex = 4;
            // 
            // frmMesajTestEkraný
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 393);
            this.Controls.Add(this.tbXML);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcMesajlar);
            this.Name = "frmMesajTestEkraný";
            this.Text = "Mesaj Test Ekraný";
            this.tcMesajlar.ResumeLayout(false);
            this.tpVatandasYabanciHastaKayit.ResumeLayout(false);
            this.tpVatandasYabanciHastaKayit.PerformLayout();
            this.tpDokumanBilgileri.ResumeLayout(false);
            this.tpDokumanBilgileri.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMesajlar;
        private System.Windows.Forms.TabPage tpVatandasYabanciHastaKayit;
        private System.Windows.Forms.TabPage tpDokumanBilgileri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVatandasCinsiyetAciklama;
        private System.Windows.Forms.TextBox tbVatandasCinsiyetKodu;
        private System.Windows.Forms.TextBox tbVatandasUyrukAciklama;
        private System.Windows.Forms.TextBox tbVatandasUyrukKodu;
        private System.Windows.Forms.TextBox tbVatandasSoyadi;
        private System.Windows.Forms.TextBox tbVatandasAdi;
        private System.Windows.Forms.TextBox tbVatandasTCKimlikNo;
        private System.Windows.Forms.DateTimePicker dtVatandasDogumTarihi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bXMLOlustur;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDokumanGuid;
        private System.Windows.Forms.DateTimePicker dtDokumanIslemZamani;
        private System.Windows.Forms.TextBox tbDokumanOlusturanKurum;
        private System.Windows.Forms.TextBox tbDokumanYazarTCKimlikNo;
        private System.Windows.Forms.TextBox tbXML;
    }
}

