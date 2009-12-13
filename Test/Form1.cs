using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SaglikNetLib;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dtDokumanIslemZamani.Value = DateTime.Now;
            tbDokumanGuid.Text = System.Guid.NewGuid().ToString();
            dtVatandasDogumTarihi.Value = DateTime.Today;
        }

        public VatandasYabanciHastaKayitMSVS VatandasYabanciHastaKayitMSVSAta (VatandasYabanciHastaKayitMSVS m)
        {            
            m.Ad = tbVatandasAdi.Text;
            m.Soyad = tbVatandasSoyadi.Text;
            m.DogumTarihi = dtVatandasDogumTarihi.Value;
            m.HastaTCKimlikNumarasi = tbVatandasTCKimlikNo.Text;
            m.Uyruk.Code = tbVatandasUyrukKodu.Text;
            m.Uyruk.DisplayName = tbVatandasUyrukAciklama.Text;
            m.Cinsiyet.Code = tbVatandasCinsiyetKodu.Text;
            m.Cinsiyet.DisplayName = tbVatandasCinsiyetAciklama.Text;
            
            return m;
        }

        public HastaKabulMSVS HastaKabulMSVSAta (HastaKabulMSVS m)
        {            
            m.KabulSekli.Code = "";
            m.KabulSekli.DisplayName="";
            m.KabulZamani= DateTime.Now;
            m.SevkTarihi= DateTime.Now;
            m.SGKTakipNumarasi="";
            m.VakaTuru.Code="";
            m.VakaTuru.DisplayName="";
            m.GeldigiPoliklinik.Code="";
            m.GeldigiPoliklinik.DisplayName="";
            m.SevkTanisi.Add(new CodeDisplayName("",""));
            
            return m;
        }


        public HastaCikisMSVS HastaCikisMSVSAta (HastaCikisMSVS m)
        {            
            m.CikisSekli.Code = "";
            m.CikisSekli.DisplayName="";
            m.CikisZamani= DateTime.Now;           
            m.SevkEdilenPoliklinik.Code="";
            m.SevkEdilenPoliklinik.DisplayName="";
            m.SevkTanisi.Code="";
            m.SevkTanisi.DisplayName="";
            
            return m;
        }


        public MuayeneMSVS MuayeneMSVSAta (MuayeneMSVS m)
        {            
            m.HekimKimlikNumarasi = "";
            m.Hikayesi="";
            m.Sikayeti="";
            m.Bulgu="";
            m.AnaTani.Code="";
            m.AnaTani.DisplayName="";
            m.EkTani.Add(new CodeDisplayName("",""));
            m.MuayeneBaslangicZamani= DateTime.Now;
            m.MuayeneBitisZamani= DateTime.Now;
            m.MuayeneYapilanPoliklinik.Code="";
            m.MuayeneYapilanPoliklinik.DisplayName="";
            m.ProtokolNumarasi="";
            //m.Rapor.Add
            //m.Tetkik.Add
            
            
            return m;
        }

        private void bXMLOlustur_Click(object sender, EventArgs e)
        {
            BaseMesaj m=null;


            switch (cbMesajListesi.SelectedIndex)
            {
                case 0: 
                    m = new VatandasYabanciHastaKayitMesaji();                   
                    m.VatandasYabanciKayit=VatandasYabanciHastaKayitMSVSAta(m.VatandasYabanciKayit);
                    break;
                case 1: 
                    m = new MuayeneMesaji();                   
                    m.VatandasYabanciKayit=VatandasYabanciHastaKayitMSVSAta(m.VatandasYabanciKayit);
                    m.HastaKabul=HastaKabulMSVSAta(m.HastaKabul);
                    m.HastaCikis=HastaCikisMSVSAta(m.HastaCikis);
                    m.Muayene=MuayeneMSVSAta(m.Muayene);
                    //m.YenidoganKayit
                    //m.TetkikSonuclari.Add(
                    //m.Recete.Add(                    
                    
                    break;

            }
            
                
            m.DokumanGUID=tbDokumanGuid.Text;
            m.DokumaniOlusturanKurum = tbDokumanOlusturanKurum.Text;
            m.DokumanIslemZamani = dtDokumanIslemZamani.Value;             
            m.DokumanYazariTCKimlikNo = tbDokumanYazarTCKimlikNo.Text;

            switch (cbIslem.SelectedIndex)
            {
                case 0: m.YeniKayit(); break;
                case 1: m.Guncelle(); break;
                case 2: m.Sorgula(); break;
                case 3: m.Iptal(); break;                
            }
            

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