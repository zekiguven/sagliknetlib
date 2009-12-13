namespace Test
{
    partial class Form1
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
            this.tpDokumanBilgileri = new System.Windows.Forms.TabPage();
            this.tbDokumanYazarTCKimlikNo = new System.Windows.Forms.TextBox();
            this.dtDokumanIslemZamani = new System.Windows.Forms.DateTimePicker();
            this.tbDokumanOlusturanKurum = new System.Windows.Forms.TextBox();
            this.tbDokumanGuid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tpVatandasYabanciHastaKayit = new System.Windows.Forms.TabPage();
            this.dtVatandasDogumTarihi = new System.Windows.Forms.DateTimePicker();
            this.tbVatandasCinsiyetAciklama = new System.Windows.Forms.TextBox();
            this.tbVatandasCinsiyetKodu = new System.Windows.Forms.TextBox();
            this.tbVatandasUyrukAciklama = new System.Windows.Forms.TextBox();
            this.tbVatandasUyrukKodu = new System.Windows.Forms.TextBox();
            this.tbVatandasSoyadi = new System.Windows.Forms.TextBox();
            this.tbVatandasAdi = new System.Windows.Forms.TextBox();
            this.tbVatandasTCKimlikNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bXMLOlustur = new System.Windows.Forms.Button();
            this.tbXML = new System.Windows.Forms.TextBox();
            this.cbMesajListesi = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbIslem = new System.Windows.Forms.ComboBox();
            this.tcMesajlar.SuspendLayout();
            this.tpDokumanBilgileri.SuspendLayout();
            this.tpVatandasYabanciHastaKayit.SuspendLayout();
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
            this.tcMesajlar.Size = new System.Drawing.Size(740, 245);
            this.tcMesajlar.TabIndex = 1;
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
            this.tpDokumanBilgileri.Size = new System.Drawing.Size(732, 219);
            this.tpDokumanBilgileri.TabIndex = 1;
            this.tpDokumanBilgileri.Text = "Döküman Bilgileri";
            this.tpDokumanBilgileri.UseVisualStyleBackColor = true;
            // 
            // tbDokumanYazarTCKimlikNo
            // 
            this.tbDokumanYazarTCKimlikNo.Location = new System.Drawing.Point(119, 91);
            this.tbDokumanYazarTCKimlikNo.Name = "tbDokumanYazarTCKimlikNo";
            this.tbDokumanYazarTCKimlikNo.Size = new System.Drawing.Size(100, 20);
            this.tbDokumanYazarTCKimlikNo.TabIndex = 7;
            this.tbDokumanYazarTCKimlikNo.Text = "98765432109";
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
            // tbDokumanOlusturanKurum
            // 
            this.tbDokumanOlusturanKurum.Location = new System.Drawing.Point(119, 39);
            this.tbDokumanOlusturanKurum.Name = "tbDokumanOlusturanKurum";
            this.tbDokumanOlusturanKurum.Size = new System.Drawing.Size(161, 20);
            this.tbDokumanOlusturanKurum.TabIndex = 3;
            this.tbDokumanOlusturanKurum.Text = "00000";

            // 
            // tbDokumanGuid
            // 
            this.tbDokumanGuid.Location = new System.Drawing.Point(119, 10);
            this.tbDokumanGuid.Name = "tbDokumanGuid";
            this.tbDokumanGuid.Size = new System.Drawing.Size(247, 20);
            this.tbDokumanGuid.TabIndex = 1;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ýþlem zamaný";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Guid";
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
            this.tpVatandasYabanciHastaKayit.Size = new System.Drawing.Size(732, 219);
            this.tpVatandasYabanciHastaKayit.TabIndex = 0;
            this.tpVatandasYabanciHastaKayit.Text = "Vatandaþ, Yabancý Hasta Kayýt MSVS";
            this.tpVatandasYabanciHastaKayit.UseVisualStyleBackColor = true;
            // 
            // dtVatandasDogumTarihi
            // 
            this.dtVatandasDogumTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVatandasDogumTarihi.Location = new System.Drawing.Point(79, 133);
            this.dtVatandasDogumTarihi.Name = "dtVatandasDogumTarihi";
            this.dtVatandasDogumTarihi.Size = new System.Drawing.Size(100, 20);
            this.dtVatandasDogumTarihi.TabIndex = 13;
            // 
            // tbVatandasCinsiyetAciklama
            // 
            this.tbVatandasCinsiyetAciklama.Location = new System.Drawing.Point(120, 107);
            this.tbVatandasCinsiyetAciklama.Name = "tbVatandasCinsiyetAciklama";
            this.tbVatandasCinsiyetAciklama.Size = new System.Drawing.Size(160, 20);
            this.tbVatandasCinsiyetAciklama.TabIndex = 12;
            this.tbVatandasCinsiyetAciklama.Text = "Erkek";
            // 
            // tbVatandasCinsiyetKodu
            // 
            this.tbVatandasCinsiyetKodu.Location = new System.Drawing.Point(79, 107);
            this.tbVatandasCinsiyetKodu.Name = "tbVatandasCinsiyetKodu";
            this.tbVatandasCinsiyetKodu.Size = new System.Drawing.Size(35, 20);
            this.tbVatandasCinsiyetKodu.TabIndex = 11;
            this.tbVatandasCinsiyetKodu.Text = "1";
            // 
            // tbVatandasUyrukAciklama
            // 
            this.tbVatandasUyrukAciklama.Location = new System.Drawing.Point(120, 79);
            this.tbVatandasUyrukAciklama.Name = "tbVatandasUyrukAciklama";
            this.tbVatandasUyrukAciklama.Size = new System.Drawing.Size(160, 20);
            this.tbVatandasUyrukAciklama.TabIndex = 10;
            this.tbVatandasUyrukAciklama.Text = "Türkiye";
            // 
            // tbVatandasUyrukKodu
            // 
            this.tbVatandasUyrukKodu.Location = new System.Drawing.Point(79, 79);
            this.tbVatandasUyrukKodu.Name = "tbVatandasUyrukKodu";
            this.tbVatandasUyrukKodu.Size = new System.Drawing.Size(35, 20);
            this.tbVatandasUyrukKodu.TabIndex = 9;
            this.tbVatandasUyrukKodu.Text = "TR";
            // 
            // tbVatandasSoyadi
            // 
            this.tbVatandasSoyadi.Location = new System.Drawing.Point(79, 54);
            this.tbVatandasSoyadi.Name = "tbVatandasSoyadi";
            this.tbVatandasSoyadi.Size = new System.Drawing.Size(100, 20);
            this.tbVatandasSoyadi.TabIndex = 8;
            this.tbVatandasSoyadi.Text = "Vatandaþ";
            // 
            // tbVatandasAdi
            // 
            this.tbVatandasAdi.Location = new System.Drawing.Point(79, 31);
            this.tbVatandasAdi.Name = "tbVatandasAdi";
            this.tbVatandasAdi.Size = new System.Drawing.Size(100, 20);
            this.tbVatandasAdi.TabIndex = 7;
            this.tbVatandasAdi.Text = "Kayýt";
            // 
            // tbVatandasTCKimlikNo
            // 
            this.tbVatandasTCKimlikNo.Location = new System.Drawing.Point(79, 5);
            this.tbVatandasTCKimlikNo.Name = "tbVatandasTCKimlikNo";
            this.tbVatandasTCKimlikNo.Size = new System.Drawing.Size(100, 20);
            this.tbVatandasTCKimlikNo.TabIndex = 6;
            this.tbVatandasTCKimlikNo.Text = "12345678901";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cinsiyet";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Soyadý";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TCKimlik No";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbIslem);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cbMesajListesi);
            this.panel1.Controls.Add(this.bXMLOlustur);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 38);
            this.panel1.TabIndex = 4;
            // 
            // bXMLOlustur
            // 
            this.bXMLOlustur.Location = new System.Drawing.Point(563, 5);
            this.bXMLOlustur.Name = "bXMLOlustur";
            this.bXMLOlustur.Size = new System.Drawing.Size(126, 23);
            this.bXMLOlustur.TabIndex = 0;
            this.bXMLOlustur.Text = "XML oluþtur";
            this.bXMLOlustur.UseVisualStyleBackColor = true;
            this.bXMLOlustur.Click += new System.EventHandler(this.bXMLOlustur_Click);
            // 
            // tbXML
            // 
            this.tbXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbXML.Location = new System.Drawing.Point(0, 283);
            this.tbXML.Multiline = true;
            this.tbXML.Name = "tbXML";
            this.tbXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbXML.Size = new System.Drawing.Size(740, 129);
            this.tbXML.TabIndex = 5;
            this.tbXML.WordWrap = false;
            // 
            // cbMesajListesi
            // 
            this.cbMesajListesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMesajListesi.FormattingEnabled = true;
            this.cbMesajListesi.Items.AddRange(new object[] {
            "Vatandaþ, Yabancý Hasta Kayýt Mesajý",
            "Muayene Mesajý"});
            this.cbMesajListesi.Location = new System.Drawing.Point(51, 7);
            this.cbMesajListesi.Name = "cbMesajListesi";
            this.cbMesajListesi.Size = new System.Drawing.Size(322, 21);
            this.cbMesajListesi.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Mesaj";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(379, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Ýþlem";
            // 
            // cbIslem
            // 
            this.cbIslem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIslem.FormattingEnabled = true;
            this.cbIslem.Items.AddRange(new object[] {
            "Yeni kayýt",
            "Guncelleme",
            "Sorgulama",
            "Ýptal"});
            this.cbIslem.Location = new System.Drawing.Point(416, 7);
            this.cbIslem.Name = "cbIslem";
            this.cbIslem.Size = new System.Drawing.Size(121, 21);
            this.cbIslem.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 507);
            this.Controls.Add(this.tbXML);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcMesajlar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tcMesajlar.ResumeLayout(false);
            this.tpDokumanBilgileri.ResumeLayout(false);
            this.tpDokumanBilgileri.PerformLayout();
            this.tpVatandasYabanciHastaKayit.ResumeLayout(false);
            this.tpVatandasYabanciHastaKayit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMesajlar;
        private System.Windows.Forms.TabPage tpDokumanBilgileri;
        private System.Windows.Forms.TextBox tbDokumanYazarTCKimlikNo;
        private System.Windows.Forms.DateTimePicker dtDokumanIslemZamani;
        private System.Windows.Forms.TextBox tbDokumanOlusturanKurum;
        private System.Windows.Forms.TextBox tbDokumanGuid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tpVatandasYabanciHastaKayit;
        private System.Windows.Forms.DateTimePicker dtVatandasDogumTarihi;
        private System.Windows.Forms.TextBox tbVatandasCinsiyetAciklama;
        private System.Windows.Forms.TextBox tbVatandasCinsiyetKodu;
        private System.Windows.Forms.TextBox tbVatandasUyrukAciklama;
        private System.Windows.Forms.TextBox tbVatandasUyrukKodu;
        private System.Windows.Forms.TextBox tbVatandasSoyadi;
        private System.Windows.Forms.TextBox tbVatandasAdi;
        private System.Windows.Forms.TextBox tbVatandasTCKimlikNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bXMLOlustur;
        private System.Windows.Forms.TextBox tbXML;
        private System.Windows.Forms.ComboBox cbMesajListesi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbIslem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bMesajOlustur;

    }
}

