using System;
using System.Collections.Generic;
using System.Text;

namespace SaglikNetLib
{
    
    public enum HastaTuru
    {        
        Normal,
        YeniDogan        
    }

    public enum MesajTuru
    {
        Yok,
        Yenikayit,
        Guncelle,
        Iptal,
        Sorgulama
    }

    internal interface IMesaj
    {
        void YeniKayit();
        void Guncelle();
        void Iptal();
        void Sorgula();
        void Gonder();
        void XMLKaydet(string DosyaAdi);
        string XMLString();
    }

    public class BaseMesaj
    {
        public string ServiceURL;
        public string ServiceUsername;
        public string ServicePassword;
        public string ServiceSertifikaYol;

        public string MesajGonderenYazilim;
        public string DokumanGUID;
        public string DokumanYazariTCKimlikNo;
        public string DokumaniOlusturanKurum;
        public bool DokumanTekGUIDKullan;
        public DateTime DokumanIslemZamani;
        public MesajTuru SonMesajTuru;
        public HastaTuru HastaTuru;

        /*
        public VatandasYabanciHastaKayitMSVS VatandasYabanciKayit;
        public YenidoganKayitMSVS YenidoganKayit;
        public List<TetkikSonucuMSVS> TetkikSonuclari;
        public HastaKabulMSVS HastaKabul;
        public HastaCikisMSVS HastaCikis;
        public List<ReceteMSVS> Recete;
        public MuayeneMSVS Muayene;
        */
        public BaseMesaj()
        {
            MesajGonderenYazilim = "SAGLIKNETLIB";
            DokumanIslemZamani = DateTime.Now;
            SonMesajTuru = MesajTuru.Yok;
            ServiceURL = "";
            DokumanTekGUIDKullan = false;
        }

        public string UUID
        {
            get { return (DokumanTekGUIDKullan ? DokumanGUID : System.Guid.NewGuid().ToString()); }
        }
    }
}
