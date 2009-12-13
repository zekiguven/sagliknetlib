using System;
using System.Collections.Generic;
using System.Text;

namespace sagliknetlib
{
    public class IntiharGirisimiVeKrizMesaji : BaseMesaj, IMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        #region IMesaj Members

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

        public void Gonder()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
