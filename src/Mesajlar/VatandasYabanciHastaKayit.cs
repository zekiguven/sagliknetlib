using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Web.Services3.Security.Tokens;
using SaglikNetLib.WebReference_VatandasYabanciHastaKayit;

namespace SaglikNetLib.Mesajlar
{
    class VatandasYabanciHastaKayit : BaseMesaj,IMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        VatandasYabanciHastaKayitMSVS VatandasYabanciKayit;

        public VatandasYabanciHastaKayit()
        {
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
        }
        
        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();

            #region Mesaj baslik bilgileri
            mesaj_yeni.id = new MCCI_IN000001TR01MessageID();
            mesaj_yeni.id.root = "2.16.840.1.113883.3.129.2.1.2";
            mesaj_yeni.id.extension = DokumanGUID;
            mesaj_yeni.creationTime = new MCCI_IN000001TR01MessageCreationTime();
            mesaj_yeni.creationTime.value = DokumanIslemZamani.ToString("yyyyMMddhhmmss");

            mesaj_yeni.responseModeCode = new MCCI_IN000001TR01MessageResponseModeCode();
            mesaj_yeni.responseModeCode.code = "Q";

            mesaj_yeni.interactionId = new MCCI_IN000001TR01MessageInteractionId();
            mesaj_yeni.interactionId.root = "2.16.840.1.113883.3.129.2.1.1";
            mesaj_yeni.interactionId.extension = "MCCI_IN000001TR01";

            
            mesaj_yeni.processingCode = new MCCI_IN000001TR01MessageProcessingCode();
            mesaj_yeni.processingCode.code = "P";

            mesaj_yeni.processingModeCode = new MCCI_IN000001TR01MessageProcessingModeCode();
            mesaj_yeni.processingModeCode.code = "T";

            mesaj_yeni.acceptAckCode = new MCCI_IN000001TR01MessageAcceptAckCode();
            mesaj_yeni.acceptAckCode.code = "AL";

            mesaj_yeni.receiver = new MCCI_IN000001TR01Receiver();
            mesaj_yeni.receiver.device = new MCCI_IN000001TR01Device2();
            mesaj_yeni.receiver.device.id = new MCCI_IN000001TR01Device2ID();
            mesaj_yeni.receiver.device.id.root = "2.16.840.1.113883.3.129.1.1.5";
            mesaj_yeni.receiver.device.id.extension = "USBS";

            mesaj_yeni.sender = new MCCI_IN000001TR01Sender();
            mesaj_yeni.sender.device = new MCCI_IN000001TR01Device();
            mesaj_yeni.sender.device.id = new MCCI_IN000001TR01DeviceID();
            mesaj_yeni.sender.device.id.root = "2.16.840.1.113883.3.129.1.1.5";
            mesaj_yeni.sender.device.id.extension = MesajGonderenYazilim;

            mesaj_yeni.controlActEvent = new MCCI_IN000001TR01ControlActEvent();
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();
            #endregion

            POCD_MT000001TR01PatientAdmission Dokuman = new POCD_MT000001TR01PatientAdmission();
            mesaj_yeni.controlActEvent.subject.patientAdmission = Dokuman;
           

            #region Dokuman bilgileri

            Dokuman.id = new POCD_MT000001TR01PatientAdmissionID();
            Dokuman.id.root = "2.16.840.1.113883.3.129.2.1.3";
            Dokuman.id.extension=DokumanGUID;

            Dokuman.code = new POCD_MT000001TR01PatientAdmissionCode();
            Dokuman.code.code = "VATANDAS";
            Dokuman.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            Dokuman.code.codeSystemName = "Döküman Tipi";
            Dokuman.code.codeSystemVersion = "1.0";
            Dokuman.code.displayName = "Vatandaþ/Yabancý Kayýt MSVS";                       

            Dokuman.effectiveTime = new POCD_MT000001TR01PatientAdmissionEffectiveTime();
            Dokuman.effectiveTime.value = DokumanIslemZamani.ToString("yyyyMMddhhmmss");

            Dokuman.confidentialityCode = new POCD_MT000001TR01PatientAdmissionConfidentialityCode();
            Dokuman.confidentialityCode.code = "1";
            Dokuman.confidentialityCode.codeSystem = "2.16.840.1.113883.3.129.1.2.77";
            Dokuman.confidentialityCode.codeSystemName = "Gizlilik";
            Dokuman.confidentialityCode.codeSystemVersion = "1.0";
            Dokuman.confidentialityCode.displayName = "Normal";


            Dokuman.languageCode = new POCD_MT000001TR01PatientAdmissionLanguageCode();
            Dokuman.languageCode.code = "tr-TR";
            
            Dokuman.versionNumber = new POCD_MT000001TR01PatientAdmissionVersionNumber();
            Dokuman.versionNumber.value = "1";

            Dokuman.author = new POCD_MT000001TR01Author1();
            Dokuman.author.time = new POCD_MT000001TR01Author1Time();
            Dokuman.author.time.value = DokumanIslemZamani.ToString("yyyyMMddhhmmss");

            Dokuman.author.assignedAuthor = new POCD_MT000001TR01AssignedAuthor();
            Dokuman.author.assignedAuthor.id = new POCD_MT000001TR01AssignedAuthorID();
            Dokuman.author.assignedAuthor.id.root = "2.16.840.1.113883.3.129.1.1.1";
            Dokuman.author.assignedAuthor.id.extension = DokumanYazariTCKimlikNo;

            Dokuman.custodian = new POCD_MT000001TR01Custodian();
            Dokuman.custodian.assignedCustodian = new POCD_MT000001TR01AssignedCustodian();
            Dokuman.custodian.assignedCustodian.representedHealthcareOrganization = new POCD_MT000001TR01HealthcareOrganization();
            Dokuman.custodian.assignedCustodian.representedHealthcareOrganization.id = new POCD_MT000001TR01HealthcareOrganizationID();
            Dokuman.custodian.assignedCustodian.representedHealthcareOrganization.id.root = "2.16.840.1.113883.3.129.1.1.6";
            Dokuman.custodian.assignedCustodian.representedHealthcareOrganization.id.extension = DokumaniOlusturanKurum;

            Dokuman.primaryInformationRecipient = new POCD_MT000001TR01PrimaryInformationRecipient();
            Dokuman.primaryInformationRecipient.recipient = new POCD_MT000001TR01Recipient();
            Dokuman.primaryInformationRecipient.recipient.representedMinisteryOfHealth = new POCD_MT000001TR01MinisteryOfHealth();
            Dokuman.primaryInformationRecipient.recipient.representedMinisteryOfHealth.id.root = "2.16.840.1.113883.3.129.1.1.6";
            Dokuman.primaryInformationRecipient.recipient.representedMinisteryOfHealth.id.extension = "5881";

            

            POCD_MT000001TR01RecordTarget RecordTarget = new POCD_MT000001TR01RecordTarget();
            Dokuman.recordTarget = RecordTarget;

            if (HastaTuru == HastaTuru.Normal)
            {

                #region PatientRole
                
                POCD_MT000001TR01PatientRole PatientRole = new POCD_MT000001TR01PatientRole();
                RecordTarget.patientRole = PatientRole;
                PatientRole.id = new POCD_MT000001TR01PatientRoleID();
                PatientRole.id.root = "2.16.840.1.113883.3.129.1.1.1";
                PatientRole.id.extension = VatandasYabanciKayit.HastaTCKimlikNumarasi;
                POCD_MT000001TR01Patient Patient = new POCD_MT000001TR01Patient();
                PatientRole.patient = Patient;
                Patient.name = new POCD_MT000001TR01PatientName();
                Patient.name.Items = new ENXP[2];

                Patient.name.Items[0] = new engiven();
                Patient.name.Items[0].Text = new string[] { VatandasYabanciKayit.Ad };

                Patient.name.Items[1] = new enfamily();
                Patient.name.Items[1].Text = new string[] { VatandasYabanciKayit.Soyad };

                Patient.administrativeGenderCode = new POCD_MT000001TR01PatientAdministrativeGenderCode();
                Patient.administrativeGenderCode.code = VatandasYabanciKayit.Cinsiyet.Code;
                Patient.administrativeGenderCode.codeSystem = "2.16.840.1.113883.3.129.1.2.21";
                Patient.administrativeGenderCode.codeSystemName = "Cinsiyet";
                Patient.administrativeGenderCode.codeSystemVersion = "1.0";
                Patient.administrativeGenderCode.displayName = VatandasYabanciKayit.Cinsiyet.DisplayName;

                Patient.birthTime = new POCD_MT000001TR01PatientBirthTime();
                Patient.birthTime.value = VatandasYabanciKayit.DogumTarihi.ToString("yyyyMMdd");

                Patient.raceCode = new POCD_MT000001TR01PatientRaceCode();
                Patient.raceCode.code = VatandasYabanciKayit.Uyruk.Code;
                Patient.raceCode.codeSystem = "2.16.840.1.113883.3.129.1.2.52";
                Patient.raceCode.codeSystemName = "Uyruk";
                Patient.raceCode.codeSystemVersion = "1.0";
                Patient.raceCode.displayName = VatandasYabanciKayit.Uyruk.DisplayName;

                #endregion

            }
            else if (HastaTuru == HastaTuru.YeniDogan)
            {
                new Exception("Yenidoðan kaydý bu mesaj ile yapýlamaz");                
            }

            #endregion

            POCD_MT000001TR01Component Component = new POCD_MT000001TR01Component();
            Dokuman.component = Component;

            POCD_MT000001TR01NonXMLBody NonXMLBody = new POCD_MT000001TR01NonXMLBody();
            Component.nonXMLBody = NonXMLBody;
            NonXMLBody.text = new ST();
            NonXMLBody.text.Text = new string[] { "" };

            SonMesajTuru = MesajTuru.Yenikayit;

        }
        
        public void Guncelle()
        {
        }

        public void Iptal()
        {
        }
        
        public void Sorgula()
        {
        }
        
        public void Gonder()
        {
        }
        
        public void XMLKaydet(string DosyaAdi){
        }
        
        public string XMLString(){
            return null;
        }
        

    }
}
