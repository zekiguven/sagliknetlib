using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSVatandasYabanciHastaKayit;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Web.Services3.Security.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace SaglikNetLib
{
    public class VatandasYabanciHastaKayitMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;                
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;


        public VatandasYabanciHastaKayitMesaji()
        {
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            ws = new MCCI_AR000001TR_ServiceWse();
        }
        
        

        public override void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            mesaj_cevap = new MCCI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_yeni);
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();

            POCD_MT000001TR01PatientAdmission PatientAdmission = new POCD_MT000001TR01PatientAdmission();
            mesaj_yeni.controlActEvent.subject.patientAdmission = PatientAdmission;
            DokumanBilgileriniDoldur(PatientAdmission);

            PatientAdmission.code.code = "VATANDAS";
            PatientAdmission.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            PatientAdmission.code.codeSystemName = "Döküman Tipi";
            PatientAdmission.code.codeSystemVersion = "1.0";
            PatientAdmission.code.displayName = "Vatandaþ/Yabancý Kayýt MSVS";

            POCD_MT000001TR01RecordTarget RecordTarget = new POCD_MT000001TR01RecordTarget();
            PatientAdmission.recordTarget = RecordTarget;

            POCD_MT000001TR01PatientRole PatientRole = new POCD_MT000001TR01PatientRole();
            RecordTarget.patientRole = PatientRole;

            PatientRoleDoldur(PatientRole);

            POCD_MT000001TR01Component Component = new POCD_MT000001TR01Component();
            PatientAdmission.component = Component;

            POCD_MT000001TR01NonXMLBody NonXMLBody = new POCD_MT000001TR01NonXMLBody();
            Component.nonXMLBody = NonXMLBody;
            NonXMLBody.text = new ST();
            NonXMLBody.text.Text = new string[] { "" };

            SonMesajTuru = MesajTuru.Yenikayit;
        }

        public void Guncelle()
        {
            mesaj_guncelle = new MCCI_IN000003TR01Message();
            mesaj_cevap = new MCCI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_guncelle);
            mesaj_guncelle.controlActEvent.subject = new MCCI_IN000003TR01Subject();           

            POCD_MT000201TR01PatientAdmission PatientAdmission = new POCD_MT000201TR01PatientAdmission();
            mesaj_guncelle.controlActEvent.subject.patientAdmission = PatientAdmission;
            DokumanBilgileriniDoldur(PatientAdmission);

            PatientAdmission.code.code = "VATANDAS";
            PatientAdmission.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            PatientAdmission.code.codeSystemName = "Döküman Tipi";
            PatientAdmission.code.codeSystemVersion = "1.0";
            PatientAdmission.code.displayName = "Vatandaþ/Yabancý Kayýt MSVS";

            POCD_MT000201TR01RecordTarget RecordTarget = new POCD_MT000201TR01RecordTarget();
            PatientAdmission.recordTarget = RecordTarget;

            POCD_MT000201TR01PatientRole PatientRole = new POCD_MT000201TR01PatientRole();
            RecordTarget.patientRole = PatientRole;

            PatientRoleDoldur(PatientRole);

            POCD_MT000201TR01Component Component = new POCD_MT000201TR01Component();
            PatientAdmission.component = Component;

            POCD_MT000201TR01NonXMLBody NonXMLBody = new POCD_MT000201TR01NonXMLBody();
            Component.nonXMLBody = NonXMLBody;
            NonXMLBody.text = new ST();
            NonXMLBody.text.Text = new string[] { "" };
            
            Object oReplacementOf = CreateAndSetParent(PatientAdmission,"replacementOf");
            Object oParentDocument = CreateAndSetParent(oReplacementOf,"parentDocument");
            Object oParentDocumentId =CreateAndSetIDProperty(oParentDocument,"2.16.840.1.113883.3.129.2.1.3",DokumanGUID);
            Object oParentDocumentCode = CreateAndSetCodeProperty(oParentDocument,"VATANDAS","2.16.840.1.113883.3.129.2.2.1","Döküman Tipi","1.0","Vatandaþ/Yabancý Kayýt MSVS");
            Object oVersionNumber = CreateAndSetParent(oParentDocument, "versionNumber");
            SetProperty(oVersionNumber, "value", "1");

            SonMesajTuru = MesajTuru.Guncelleme;
        }

        public void Iptal()
        {
            throw new Exception("Ýptal iþlemi bulunmamakta.");
        }

        public void Sorgula()
        {
            mesaj_sorgu = new QUQI_IN000001TR01Message();
            mesaj_sorgu_cevap = new QUQI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_sorgu);
            mesaj_sorgu.controlActEvent.queryByParameter = new QUQI_IN000001TR01QueryByParameter();
            mesaj_sorgu.controlActEvent.queryByParameter.statusCode = new QUQI_IN000001TR01QueryByParameterStatusCode();
            mesaj_sorgu.controlActEvent.queryByParameter.statusCode.code = "new";
            mesaj_sorgu.controlActEvent.queryByParameter.clinicalDocumentId = new QUQI_IN000001TR01ClinicalDocumentId();
            mesaj_sorgu.controlActEvent.queryByParameter.clinicalDocumentId.value = new QUQI_IN000001TR01ClinicalDocumentIdValue();
            mesaj_sorgu.controlActEvent.queryByParameter.clinicalDocumentId.value.root = "2.16.840.1.113883.3.129.2.1.3";
            mesaj_sorgu.controlActEvent.queryByParameter.clinicalDocumentId.value.extension = DokumanGUID;            

            SonMesajTuru = MesajTuru.Sorgula;            
        }

        
        public string Gonder()
        {
            UsernameToken token = new UsernameToken(ServiceUsername, ServicePassword, PasswordOption.SendPlainText);
            MCCI_AR000001TR_ServiceWse ws = new MCCI_AR000001TR_ServiceWse();
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
                case MesajTuru.Sorgula:
                    mesaj_sorgu_cevap = ws.MCCI_AR000001TR_QUQI_IN000001TR(mesaj_sorgu);
                    acknowledgementcode = mesaj_sorgu_cevap.acknowledgement.typeCode.code;
                    break;
                default:
                    break;
            }

            return acknowledgementcode;
        }


    }
}
