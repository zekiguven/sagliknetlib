using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSLohusaIzlem;

namespace SaglikNetLib
{
    public class LohusaIzlemMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public LohusaIzlemMSVS LohusaIzlem;

        public LohusaIzlemMesaji()
        {
            servis = new MCCI_AR000001TR_Service();
            ws = new MCCI_AR000001TR_ServiceWse();

            LohusaIzlem = new LohusaIzlemMSVS();
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
        }

        public void PuerperantObservationDatasetDoldur(object o)
        {
            object Id = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4", UUID);
            object Code = CreateAndSetCodeProperty(o,"LOHUSAIZLEM","2.16.840.1.113883.3.129.2.2.2","Veriseti","1.0","Lohusa Ýzlem Veriseti");
            object Author =CreateAndSetParent(o,"author");
            object Time = CreateAndSetParent(Author,"time");
SetProperty(Time,"value",LohusaIzlem.IslemZamani.ToString("yyyyMMddhhmm"));
            object Doctor = CreateAndSetParent(Author,"doctor");
            object DoctorIdArray =Array.CreateInstance(Type.GetType(GetPropertyTypeName(Doctor,"id")),2);


            //TODO: Buraya bakýlacak
                /*
                <author typeCode="AUT" contextControlCode="OP">
                  <time value="20080522 1021" />
                  <doctor classCode="ROL">
                    <id root="2.16.840.1.113883.3.129.1.1.1" extension="12345678905" />
                    <id root="2.16.840.1.113883.3.129.1.1.1" extension="12345678905" />
                  </doctor>
                </author>
                 

            PuerperantObservationDataset.component1 = new POCD_MT000011TR01Component11();
            PuerperantObservationDataset.component1.lastMenstruationDateSection = new POCD_MT000011TR01LastMenstruationDateSection();
            PuerperantObservationDataset.component1.lastMenstruationDateSection.id = new POCD_MT000011TR01LastMenstruationDateSectionID();
            PuerperantObservationDataset.component1.lastMenstruationDateSection.code = new POCD_MT000011TR01LastMenstruationDateSectionCode();
            PuerperantObservationDataset.component1.lastMenstruationDateSection.text = new StrucDocText();
            PuerperantObservationDataset.component1.lastMenstruationDateSection.component = new POCD_MT000011TR01Component12();
            PuerperantObservationDataset.component1.lastMenstruationDateSection.component.lastMenstruationDate = new POCD_MT000011TR01LastMenstruationDate();
            PuerperantObservationDataset.component1.lastMenstruationDateSection.component.lastMenstruationDate.effectiveTime = new POCD_MT000011TR01LastMenstruationDateEffectiveTime();
            PuerperantObservationDataset.component1.lastMenstruationDateSection.component.lastMenstruationDate.effectiveTime.value = "";

            PuerperantObservationDataset.component2 = new POCD_MT000011TR01Component13();
            PuerperantObservationDataset.component2.pregnancyEndDateSection = new POCD_MT000011TR01PregnancyEndDateSection();
            PuerperantObservationDataset.component2.pregnancyEndDateSection.id = new POCD_MT000011TR01PregnancyEndDateSectionID();
            PuerperantObservationDataset.component2.pregnancyEndDateSection.code = new POCD_MT000011TR01PregnancyEndDateSectionCode();
            PuerperantObservationDataset.component2.pregnancyEndDateSection.text = new StrucDocText();
            PuerperantObservationDataset.component2.pregnancyEndDateSection.component = new POCD_MT000011TR01Component14();
            PuerperantObservationDataset.component2.pregnancyEndDateSection.component.pregnancyEndDate = new POCD_MT000011TR01PregnancyEndDate();
            PuerperantObservationDataset.component2.pregnancyEndDateSection.component.pregnancyEndDate.effectiveTime = new POCD_MT000011TR01PregnancyEndDateEffectiveTime();
            PuerperantObservationDataset.component2.pregnancyEndDateSection.component.pregnancyEndDate.effectiveTime.value = "";

            PuerperantObservationDataset.component3 = new POCD_MT000011TR01Component3();
            PuerperantObservationDataset.component3.diagnosisSection = new POCD_MT000011TR01DiagnosisSection();
            PuerperantObservationDataset.component3.diagnosisSection.id = new POCD_MT000011TR01DiagnosisSectionID();
            PuerperantObservationDataset.component3.diagnosisSection.code = new POCD_MT000011TR01DiagnosisSectionCode();
            PuerperantObservationDataset.component3.diagnosisSection.text = new StrucDocText();
            PuerperantObservationDataset.component3.diagnosisSection.component = new POCD_MT000011TR01Component4[1];
            PuerperantObservationDataset.component3.diagnosisSection.component[0] = new POCD_MT000011TR01Component4();
            PuerperantObservationDataset.component3.diagnosisSection.component[0].complicationDiagnosis = new POCD_MT000011TR01ComplicationDiagnosis();
            PuerperantObservationDataset.component3.diagnosisSection.component[0].complicationDiagnosis.code = new POCD_MT000011TR01ComplicationDiagnosisCode();
            PuerperantObservationDataset.component3.diagnosisSection.component[0].complicationDiagnosis.value = new POCD_MT000011TR01ComplicationDiagnosisValue();

            PuerperantObservationDataset.component4 = new POCD_MT000011TR01Component5();
            PuerperantObservationDataset.component4.hemoglobinSection = new POCD_MT000011TR01HemoglobinSection();
            PuerperantObservationDataset.component4.hemoglobinSection.id = new POCD_MT000011TR01HemoglobinSectionID();
            PuerperantObservationDataset.component4.hemoglobinSection.code = new POCD_MT000011TR01HemoglobinSectionCode();
            PuerperantObservationDataset.component4.hemoglobinSection.text = new StrucDocText();
            PuerperantObservationDataset.component4.hemoglobinSection.component = new POCD_MT000011TR01Component6();
            PuerperantObservationDataset.component4.hemoglobinSection.component.hemoglobin = new POCD_MT000011TR01Hemoglobin();
            PuerperantObservationDataset.component4.hemoglobinSection.component.hemoglobin.code = new POCD_MT000011TR01HemoglobinCode();

            PuerperantObservationDataset.component5 = new POCD_MT000011TR01Component7();
            PuerperantObservationDataset.component5.womanHealthActivitySection = new POCD_MT000011TR01WomanHealthActivitySection();
            PuerperantObservationDataset.component5.womanHealthActivitySection.id = new POCD_MT000011TR01WomanHealthActivitySectionID();
            PuerperantObservationDataset.component5.womanHealthActivitySection.code = new POCD_MT000011TR01WomanHealthActivitySectionCode();
            PuerperantObservationDataset.component5.womanHealthActivitySection.text = new StrucDocText();
            PuerperantObservationDataset.component5.womanHealthActivitySection.component = new POCD_MT000011TR01Component8[1];
            PuerperantObservationDataset.component5.womanHealthActivitySection.component[0].womanHealthActivity = new POCD_MT000011TR01WomanHealthActivity();
            PuerperantObservationDataset.component5.womanHealthActivitySection.component[0].womanHealthActivity.code = new POCD_MT000011TR01WomanHealthActivityCode();

            PuerperantObservationDataset.component6 = new POCD_MT000011TR01Component9();
            PuerperantObservationDataset.component6.pregnancyPuerperantDangerSection = new POCD_MT000011TR01PregnancyPuerperantDangerSection();
            PuerperantObservationDataset.component6.pregnancyPuerperantDangerSection.id = new POCD_MT000011TR01PregnancyPuerperantDangerSectionID();
            PuerperantObservationDataset.component6.pregnancyPuerperantDangerSection.code = new POCD_MT000011TR01PregnancyPuerperantDangerSectionCode();
            PuerperantObservationDataset.component6.pregnancyPuerperantDangerSection.text = new StrucDocText();
            PuerperantObservationDataset.component6.pregnancyPuerperantDangerSection.component = new POCD_MT000011TR01Component10[1];
            PuerperantObservationDataset.component6.pregnancyPuerperantDangerSection.component[0].pregnancyPuerperantDangerSign = new POCD_MT000011TR01PregnancyPuerperantDangerSign();
            PuerperantObservationDataset.component6.pregnancyPuerperantDangerSection.component[0].pregnancyPuerperantDangerSign.code = new POCD_MT000011TR01PregnancyPuerperantDangerSignCode();
            */
        }

        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            mesaj_cevap = new MCCI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_yeni);

            POCD_MT000011TR01PuerperantObservation PuerperantObservation = new POCD_MT000011TR01PuerperantObservation();
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();
            mesaj_yeni.controlActEvent.subject.puerperantObservation = PuerperantObservation;

            DokumanBilgileriniDoldur(PuerperantObservation);

            PuerperantObservation.code.code = "LOHUSAIZLEM";
            PuerperantObservation.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            PuerperantObservation.code.codeSystemName = "Döküman Tipi";
            PuerperantObservation.code.codeSystemVersion = "1.0";
            PuerperantObservation.code.displayName = "Lohusa Ýzlem MSVS (Vatandaþ/Yabancý)";


            POCD_MT000011TR01RecordTarget RecordTarget = new POCD_MT000011TR01RecordTarget();
            PuerperantObservation.recordTarget = RecordTarget;

            POCD_MT000011TR01PatientRole PatientRole = new POCD_MT000011TR01PatientRole();
            //TODO: Buraya bakýlýacak
            //RecordTarget.Item = PatientRole;
            PatientRoleDoldur(PatientRole);

            POCD_MT000011TR01Component1 Component1 = new POCD_MT000011TR01Component1();
            //Examination.component = Component1;
            
            POCD_MT000011TR01StructuredBody StructuredBody = new POCD_MT000011TR01StructuredBody();
            Component1.structuredBody = StructuredBody;
            POCD_MT000011TR01Component2 Component2 = new POCD_MT000011TR01Component2();
            StructuredBody.component = new POCD_MT000011TR01Component2();
            POCD_MT000011TR01PuerperantObservationDataset PuerperantObservationDataset = new POCD_MT000011TR01PuerperantObservationDataset();
            PuerperantObservationDatasetDoldur(PuerperantObservationDataset);
            StructuredBody.component.puerperantObservationDataset = PuerperantObservationDataset;







            SonMesajTuru = MesajTuru.Yenikayit;


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
