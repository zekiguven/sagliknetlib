using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SaglikNetLib.Mesajlar;


namespace Test
{
    public partial class frmMesajTestEkraný : Form
    {
        public frmMesajTestEkraný()
        {
            InitializeComponent();
            dtDokumanIslemZamani.Value = DateTime.Now;
            tbDokumanGuid.Text = System.Guid.NewGuid().ToString();
            dtVatandasDogumTarihi.Value = DateTime.Today;
        }

        private void bXMLOlustur_Click(object sender, EventArgs e)
        {
            VatandasYabanciHastaKayitMesaji m = new VatandasYabanciHastaKayitMesaji();

            m.DokumanGUID=tbDokumanGuid.Text;
            m.DokumaniOlusturanKurum = tbDokumanOlusturanKurum.Text;
            m.DokumanIslemZamani = dtDokumanIslemZamani.Value;             
            m.DokumanYazariTCKimlikNo = tbDokumanYazarTCKimlikNo.Text;

            m. VatandasYabanciKayit.Ad = tbVatandasAdi.Text;
            m.VatandasYabanciKayit.Soyad = tbVatandasSoyadi.Text;
            m.VatandasYabanciKayit.DogumTarihi = dtVatandasDogumTarihi.Value;
            m.VatandasYabanciKayit.HastaTCKimlikNumarasi = tbVatandasTCKimlikNo.Text;
            m.VatandasYabanciKayit.Uyruk.Code = tbVatandasUyrukKodu.Text;
            m.VatandasYabanciKayit.Uyruk.DisplayName = tbVatandasUyrukAciklama.Text;
            m.VatandasYabanciKayit.Cinsiyet.Code = tbVatandasCinsiyetKodu.Text;
            m.VatandasYabanciKayit.Cinsiyet.DisplayName = tbVatandasCinsiyetAciklama.Text;
            m.YeniKayit();

            tbXML.Text = m.XMLString();

            /*
            
            m.ServiceURL = "http://212.175.169.50:6072";
            m.ServiceUsername = "sagliknetlib";
            m.ServicePassword = "sagliknetlib";
            m.Kaydet("C:\\vatandasguncelle.xml");
             */
        }
    }
}