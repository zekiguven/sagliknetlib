using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSYenidoganHastaKayit;

namespace SaglikNetLib
{
    public class YeniDoganKayitMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public YeniDoganKayitMesaji()
        {
        }
        
        public void YeniKayit()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Guncelle()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Iptal()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Sorgula()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Gonder()
        {
            throw new Exception("The method or operation is not implemented.");
        }


    }
}