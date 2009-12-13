using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSMuayene;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Web.Services3.Security.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace SaglikNetLib
{
    public class MuayeneMesaji : BaseMesaj
    {
        MCCI_AR000001TR_Service servis;
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;


        public MuayeneMesaji()
        {
            servis = new MCCI_AR000001TR_Service();
            ws = new MCCI_AR000001TR_ServiceWse();

            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            TetkikSonuclari = new List<TetkikSonucuMSVS>();
            Recete = new List<ReceteMSVS>();
            HastaKabul = new HastaKabulMSVS();


            YenidoganKayit = new YenidoganKayitMSVS();
            Muayene = new MuayeneMSVS();
            HastaCikis = new HastaCikisMSVS();
            mesaj_yeni= new MCCI_IN000001TR01Message();
            mesaj_cevap= new MCCI_IN000002TR01Message();

        }

        public void YeniKayit()
        {

            MesajBilgileriniDoldur(mesaj_yeni);

            #region Examination
            POCD_MT000005TR01Examination Examination = new POCD_MT000005TR01Examination();
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();
            mesaj_yeni.controlActEvent.subject.examination =  Examination;

            DokumanBilgileriniDoldur(Examination);

            Examination.code.code = "MUAYENE";
            Examination.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            Examination.code.codeSystemName = "Döküman Tipi";
            Examination.code.codeSystemVersion = "1.0";
            Examination.code.displayName = "Muayene MSVS (Vatandaþ/Yabancý)";


            #region RecordTarget
            POCD_MT000005TR01RecordTarget RecordTarget = new POCD_MT000005TR01RecordTarget();
            Examination.recordTarget = RecordTarget;
            #region PatientRole
            POCD_MT000005TR01PatientRole PatientRole = new POCD_MT000005TR01PatientRole();
            RecordTarget.Item = PatientRole;
            PatientRoleDoldur(PatientRole);

            #endregion

            #endregion

            #region Component1

            POCD_MT000005TR01Component1 Component1 = new POCD_MT000005TR01Component1();
            Examination.component = Component1;

            #region StructuredBody
            POCD_MT000005TR01StructuredBody StructuredBody = new POCD_MT000005TR01StructuredBody();
            Component1.structuredBody = StructuredBody;

            #region component1

            POCD_MT000005TR01Component18[] Component18 = null;
            StructuredBody.component1 = Component18;
            if (TetkikSonuclari.Count > 0)
            {
                Component18 = new POCD_MT000005TR01Component18[TetkikSonuclari.Count];
                TestResultDatasetDoldur(Component18);
            }

            #endregion

            #region component2
            POCD_MT000005TR01Component2 Component2 = new POCD_MT000005TR01Component2();
            StructuredBody.component2 = Component2;

            POCD_MT000005TR01DischargeDataset DischargeDataset = new POCD_MT000005TR01DischargeDataset();
            Component2.dischargeDataset = DischargeDataset;

            DischargeDatasetDoldur(DischargeDataset);

            #endregion

            #region component3

            POCD_MT000005TR01Component22 Component22 = new POCD_MT000005TR01Component22();
            StructuredBody.component3 = Component22;

            POCD_MT000005TR01ExaminationDataset ExaminationDataset = new POCD_MT000005TR01ExaminationDataset();
            Component22.examinationDataset = ExaminationDataset;
            ExaminationDatasetDoldur(ExaminationDataset);

            #endregion

            #region component4

            POCD_MT000005TR01Component38 Component38 = new POCD_MT000005TR01Component38();
            StructuredBody.component4 = Component38;

            POCD_MT000005TR01ReceptionDataset ReceptionDataset = new POCD_MT000005TR01ReceptionDataset();
            Component38.receptionDataset = ReceptionDataset;
            ReceptionDatasetDoldur(ReceptionDataset);

            #endregion

            #region component5

            POCD_MT000005TR01Component7[] Component7 = null;
            StructuredBody.component5 = Component7;

            if (Recete.Count > 0)
            {
                Component7 = new POCD_MT000005TR01Component7[Recete.Count];
                PrescriptionDatasetDoldur(Component7);
            }

            #endregion
            #endregion
            #endregion
            #endregion

            SonMesajTuru = MesajTuru.Yenikayit;


        }

        public void Guncelle()
        {
            SonMesajTuru = MesajTuru.Guncelleme;
        }

        public void Iptal()
        {
            SonMesajTuru = MesajTuru.Iptal;
        }

        public void Sorgula()
        {
            SonMesajTuru = MesajTuru.Guncelleme;
        }


        /*
        public string Gonder()
        {
            UsernameToken token = new UsernameToken(ServiceUsername, ServicePassword, PasswordOption.SendPlainText);            
            ws.Url = ServiceURL;
            ws.RequestSoapContext.Security.Tokens.Add(token);
            ws.RequestSoapContext.Security.MustUnderstand = false;

            //X509Certificate X509 = new X509Certificate(ServiceSertifikaYol);
            //ws.ClientCertificates.Add(X509);
            //ServicePointManager.CertificatePolicy = new MyPolicy();

            string acknowledgementcode = null;

            switch (SonMesajTuru)
            {

                case MesajTuru.Yok:
                    break;

                case MesajTuru.Yenikayit:
                    mesaj_cevap = ws.MCCI_AR000001TR_MCCI_IN000001TR(mesaj_yeni);
                    acknowledgementcode = mesaj_cevap.acknowledgement.typeCode.code;
                    break;

                case MesajTuru.Guncelleme:
                    mesaj_cevap = ws.MCCI_AR000001TR_MCCI_IN000003TR(mesaj_guncelle);
                    acknowledgementcode = mesaj_cevap.acknowledgement.typeCode.code;
                    break;
                case MesajTuru.Iptal:

                    break;
                case MesajTuru.Sorgulama:
                    mesaj_sorgu_cevap = ws.MCCI_AR000001TR_QUQI_IN000001TR(mesaj_sorgu);
                    acknowledgementcode = mesaj_sorgu_cevap.acknowledgement.typeCode.code;
                    break;
                default:
                    break;
            }

            return acknowledgementcode;
        }

        */
    }
}
