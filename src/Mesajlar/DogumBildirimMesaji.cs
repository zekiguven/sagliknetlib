using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSDogumBildirim;

namespace SaglikNetLib
{
    public class DogumBildirimMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public DogumBildirimMSVS DogumBildirim;

        public DogumBildirimMesaji()
        {
            DogumBildirim = new DogumBildirimMSVS();
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            YenidoganKayit = new YenidoganKayitMSVS();
        }

        public void BirthNotificationDatasetDoldur(Object o)
        {
            object id = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4",UUID);
            object code = CreateAndSetCodeProperty(o, "DOGUMBILDIRIM", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Doðum Bildirim Veriseti");

            object author = CreateAndSetParent(o, "author");
            object doctor = CreateAndSetParent(author, "doctor");
            object doctorid = CreateAndSetIDProperty(doctor, "2.16.840.1.113883.3.129.1.1.1", DogumBildirim.HekimKimlikNumarasi);

            object time = CreateAndSetParent(author, "time");
            SetProperty(time,"value",DogumBildirim.IslemZamani.ToString("yyyyMMdd"));

            object component1 = CreateAndSetParent(o, "component1");
            object BirthMethodSection = CreateAndSetParent(component1, "birthMethodSection");
            object BirthMethodSectionId = CreateAndSetIDProperty(BirthMethodSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object BirthMethodSectionCode = CreateAndSetCodeProperty(BirthMethodSection,"DOGUMBILDIRIMDOGUMYONTEMI","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý", "1.0", "Doðum Bildirim Doðum Yöntemi Bilgisinin Olduðu Bölüm");
            object BirthMethodSectionText = CreateAndSetTextProperty(BirthMethodSection, "");

            object BirthMethodSectionComponent = CreateAndSetParent(BirthMethodSection, "component");
            object BirthMethod = CreateAndSetParent(BirthMethodSectionComponent, "birthMethod");
            object BirthMethodCode = CreateAndSetCodeProperty(BirthMethod, DogumBildirim.DogumYontemi.Code, "2.16.840.1.113883.3.129.1.2.34", "Doðum Yöntemi", "1.0", DogumBildirim.DogumYontemi.DisplayName);


            object component2 = CreateAndSetParent(o, "component2");
            object HeadCircumferenceSection = CreateAndSetParent(component2, "headCircumferenceSection");
            object HeadCircumferenceSectionId = CreateAndSetIDProperty(HeadCircumferenceSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object HeadCircumferenceSectionCode = CreateAndSetCodeProperty(HeadCircumferenceSection, "BASCEVRESI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Bebek Baþ Çevresi  Bilgilerinin Olduðu Bölüm");
            object HeadCircumferenceSectionText = CreateAndSetTextProperty(HeadCircumferenceSection, "");

            object HeadCircumferenceSectionComponent = CreateAndSetParent(HeadCircumferenceSection, "component");
            object BabyHeadCircumference = CreateAndSetParent(HeadCircumferenceSectionComponent, "babyHeadCircumference");
            object BabyHeadCircumferenceValue = CreateAndSetINTValue(BabyHeadCircumference, DogumBildirim.BasCevresi);


            object component3 = CreateAndSetParent(o, "component3");
            object WeightSection = CreateAndSetParent(component3, "weightSection");
            object WeightSectionId = CreateAndSetIDProperty(WeightSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object WeightSectionCode = CreateAndSetCodeProperty(WeightSection, "AGIRLIK", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Aðýrlýk  Bilgilerinin Olduðu Bölüm");
            object WeightSectionText = CreateAndSetTextProperty(WeightSection, "");

            object WeightSectionComponent = CreateAndSetParent(WeightSection, "component");
            object BabyWeight = CreateAndSetParent(WeightSectionComponent, "babyWeight");
            object BabyWeightValue = CreateAndSetINTValue(BabyWeight, DogumBildirim.Agirlik);

            
            if (DogumBildirim.KomplikasyonTanisi.Count > 0)
            {
                object component4 = CreateAndSetParent(o, "component4");
                object DiagnosisSection = CreateAndSetParent(component4, "diagnosisSection");
                object DiagnosisSectionId = CreateAndSetIDProperty(DiagnosisSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                object DiagnosisSectionCode = CreateAndSetCodeProperty(DiagnosisSection, "TANI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Taný Verisinin Olduðu Bölüm");
                object DiagnosisSectionText = CreateAndSetTextProperty(DiagnosisSection, "");

                object DiagnosisSectionComponentArray = Array.CreateInstance(Type.GetType(GetPropertyTypeName(DiagnosisSection, "component")), DogumBildirim.KomplikasyonTanisi.Count);
                SetProperty(DiagnosisSection, "component", DiagnosisSectionComponentArray);        
                
                for (int i = 0; i < DogumBildirim.KomplikasyonTanisi.Count; i++)
                {
                    object DiagnosisSectionComponent = CreateObject(GetPropertyTypeName(DiagnosisSection, "component"));
                    ((Array)DiagnosisSectionComponentArray).SetValue(DiagnosisSectionComponent, i);
                    object ComplicationDiagnosis = CreateAndSetParent(DiagnosisSectionComponent, "complicationDiagnosis");
                    object ComplicationDiagnosisCode = CreateAndSetCodeProperty(ComplicationDiagnosis, "KOMPLIKASYONTANISI", "2.16.840.1.113883.3.129.2.2.6", "Taný Tipi", "1.0", "Komplikasyon Tanýsý");
                    object ComplicationDiagnosisValue = CreateAndSetParent(ComplicationDiagnosis, "value");
                    SetProperty(ComplicationDiagnosisValue, "code", DogumBildirim.KomplikasyonTanisi[i].Code);
                    SetProperty(ComplicationDiagnosisValue, "codeSystem", "2.16.840.1.113883.6.3");
                    SetProperty(ComplicationDiagnosisValue, "codeSystemName", "ICD-10");
                    SetProperty(ComplicationDiagnosisValue, "codeSystemVersion", "1.0");
                    SetProperty(ComplicationDiagnosisValue, "displayName", DogumBildirim.KomplikasyonTanisi[i].DisplayName);
                }
            }
            

            if (DogumBildirim.BebekSagligiIslemleri.Count > 0)
            {

                object component5 = CreateAndSetParent(o, "component5");
                object BabyHealthOpSection = CreateAndSetParent(component5, "babyHealthOpSection");
                object BabyHealthOpSectionId = CreateAndSetIDProperty(BabyHealthOpSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                object BabyHealthOpSectionCode = CreateAndSetCodeProperty(BabyHealthOpSection, "BEBEKSAGLIGIISLEMLERI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Bebek Saðlýðý Ýþlem Bilgilerinin Olduðu Bölüm");
                object BabyHealthOpSectionText = CreateAndSetTextProperty(BabyHealthOpSection, "");

                object BabyHealthOpSectionComponentArray = Array.CreateInstance(Type.GetType(GetPropertyTypeName(BabyHealthOpSection, "component")), DogumBildirim.BebekSagligiIslemleri.Count);
                SetProperty(BabyHealthOpSection, "component", BabyHealthOpSectionComponentArray);

                for (int i = 0; i < DogumBildirim.BebekSagligiIslemleri.Count; i++)
                {
                    object BabyHealthOpSectionComponent = CreateObject(GetPropertyTypeName(BabyHealthOpSection, "component"));
                    ((Array)BabyHealthOpSectionComponentArray).SetValue(BabyHealthOpSectionComponent, i);
                    object BabyHealthOperation = CreateAndSetParent(BabyHealthOpSectionComponent, "babyHealthOperation");
                    object BabyHealthOperationCode = CreateAndSetCodeProperty(BabyHealthOperation,DogumBildirim.BebekSagligiIslemleri[i].Code,"2.16.840.1.113883.3.129.1.2.27","Bebek Saðlýðý Ýþlemleri","1.0",DogumBildirim.BebekSagligiIslemleri[i].DisplayName);                    
                }
               
            }


            if ((DogumBildirim.APGAR5.Code != null) && (DogumBildirim.APGAR1.Code != null))
            {

                object component6 = CreateAndSetParent(o, "component6");
                object APGARSection = CreateAndSetParent(component6, "aPGARSection");
                object APGARSectionId = CreateAndSetIDProperty(APGARSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                object APGARSectionCode = CreateAndSetCodeProperty(APGARSection, "APGAR", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "APGAR  Bilgilerinin Olduðu Bölüm");
                object APGARSectionText = CreateAndSetTextProperty(APGARSection, "");


                object APGARSectionComponent1 = CreateAndSetParent(APGARSection, "component1");
                object Apgar5 = CreateAndSetParent(APGARSectionComponent1, "aPGAR");
                object Apgar5Code = CreateAndSetCodeProperty(Apgar5, DogumBildirim.APGAR5.Code, "2.16.840.1.113883.3.129.1.2.26", "APGAR 5", "1.0", DogumBildirim.APGAR5.DisplayName);

                object APGARSectionComponent2 = CreateAndSetParent(APGARSection, "component2");
                object Apgar1 = CreateAndSetParent(APGARSectionComponent2, "aPGAR");
                object Apgar1Code = CreateAndSetCodeProperty(Apgar1, DogumBildirim.APGAR1.Code, "2.16.840.1.113883.3.129.1.2.25", "APGAR 1", "1.0", DogumBildirim.APGAR1.DisplayName);
            }

        }

        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            MesajBilgileriniDoldur(mesaj_yeni);
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();

            POCD_MT000012TR01BirthNotification BirthNotification = new POCD_MT000012TR01BirthNotification();
            mesaj_yeni.controlActEvent.subject.birthNotification = BirthNotification;
            DokumanBilgileriniDoldur(BirthNotification);

            BirthNotification.code.code = "DIYABET-YENIDOGAN";
            BirthNotification.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            BirthNotification.code.codeSystemName = "Döküman Tipi";
            BirthNotification.code.codeSystemVersion = "1.0";
            BirthNotification.code.displayName = "Diyabet MSVS (Yenidoðan)";


            POCD_MT000012TR01RecordTarget RecordTarget = new POCD_MT000012TR01RecordTarget();
            BirthNotification.recordTarget = RecordTarget;
            POCD_MT000012TR01BabyPatientRole BabyPatientRole = new POCD_MT000012TR01BabyPatientRole();
            RecordTarget.Item = BabyPatientRole;
            BabyPatientRoleDoldur(BabyPatientRole);

            BirthNotification.component = new POCD_MT000012TR01Component1();            
            POCD_MT000012TR01StructuredBody StructuredBody = new POCD_MT000012TR01StructuredBody();
            BirthNotification.component.structuredBody = StructuredBody;
            mesaj_yeni.controlActEvent.subject.birthNotification.component.structuredBody = StructuredBody;

            StructuredBody.component = new POCD_MT000012TR01Component2();            
            POCD_MT000012TR01BirthNotificationDataset BirthNotificationDataset = new POCD_MT000012TR01BirthNotificationDataset();
            BirthNotificationDatasetDoldur(BirthNotificationDataset);
            StructuredBody.component.birthNotificationDataset = BirthNotificationDataset;
                
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
