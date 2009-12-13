using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSGebeIzlem;

namespace SaglikNetLib
{
    public class GebeIzlemMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public GebeIzlemMSVS GebeIzlem;

        public GebeIzlemMesaji()
        {
            servis = new MCCI_AR000001TR_Service();
            ws = new MCCI_AR000001TR_ServiceWse();

            GebeIzlem = new GebeIzlemMSVS();
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();            
        }

        public void PregnancyObservationDatasetDoldur(object o)
        {
            object Id = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4", UUID);
            object Code = CreateAndSetCodeProperty(o, "GEBEIZLEM", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Gebe Ýzlem Veriseti");
            object Text = CreateAndSetTextProperty(o, "");
            object Author = CreateAndSetParent(o, "author");
            object Time = CreateAndSetParent(Author, "time");
            SetProperty(Time, "value", GebeIzlem.IslemZamani.ToString("yyyyMMdd"));
            object Doctor = CreateAndSetParent(Author,"doctor");
            object DoctorIdArray = Array.CreateInstance(Type.GetType(GetPropertyTypeName(Doctor, "id")), 2);
            object DoctorId;
            DoctorId  = CreateObject(GetPropertyTypeName(Doctor, "id"));
            SetProperty(DoctorId, "root", "2.16.840.1.113883.3.129.1.1.1");
            SetProperty(DoctorId, "extension", GebeIzlem.HekimKimlikNumarasi);
            ((Array)DoctorIdArray).SetValue(DoctorId, 0);

            DoctorId = CreateObject(GetPropertyTypeName(Doctor, "id"));
            SetProperty(DoctorId, "root", "2.16.840.1.113883.3.129.1.1.1");
            SetProperty(DoctorId, "extension", GebeIzlem.HekimKimlikNumarasi);
            ((Array)DoctorIdArray).SetValue(DoctorId, 1);

            object component1 = CreateAndSetParent(o, "component1");
            object FoetusHeartSoundSection = CreateAndSetParent(component1, "foetusHeartSoundSection");
            object FoetusHeartSoundSectionId = CreateAndSetIDProperty(FoetusHeartSoundSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object FoetusHeartSoundSectionCode = CreateAndSetCodeProperty(FoetusHeartSoundSection, "FETUSKALPSESI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Fetus Kalp Sesi Bilgisinin Olduðu Bölüm");
            object FoetusHeartSoundSectionText = CreateAndSetTextProperty(FoetusHeartSoundSection, "");
            object FoetusHeartSoundSectionComponent = CreateAndSetParent(FoetusHeartSoundSection, "component");
            object FoetusHeartSound = CreateAndSetParent(FoetusHeartSoundSectionComponent, "foetusHeartSound");
            object FoetusHeartSoundCode = CreateAndSetCodeProperty(FoetusHeartSound, GebeIzlem.FetusKalpSesi.Code, "2.16.840.1.113883.3.129.1.2.37", "Fetus Kalp Sesi", "1.0", GebeIzlem.FetusKalpSesi.DisplayName);

            
            object component2 = CreateAndSetParent(o, "component2");
            object BloodPressureSection = CreateAndSetParent(component2, "bloodPressureSection");
            object BloodPressureSectionId = CreateAndSetIDProperty(BloodPressureSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object BloodPressureSectionCode = CreateAndSetCodeProperty(BloodPressureSection, "KANBASINCI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Kan Basýncý Bilgisinin Olduðu Bölüm");
            object BloodPressureSectionText = CreateAndSetTextProperty(BloodPressureSection, "");
            object BloodPressureSectionComponent1 = CreateAndSetParent(BloodPressureSection, "component1");
            object DiastolicBloodPressure = CreateAndSetParent(BloodPressureSectionComponent1, "diastolicBloodPressure");
            object DiastolicBloodPressureValue = CreateAndSetINTValue(DiastolicBloodPressure, GebeIzlem.DiastolikKanBasinci);
            object BloodPressureSectionComponent2 = CreateAndSetParent(BloodPressureSection, "component2");
            object SystolicBloodPressure = CreateAndSetParent(BloodPressureSectionComponent2, "systolicBloodPressure");
            object SystolicBloodPressureValue = CreateAndSetINTValue(SystolicBloodPressure, GebeIzlem.SistolikKanBasinci);


            object component3 = CreateAndSetParent(o, "component3");
            object ProteinAtUrineSection = CreateAndSetParent(component3, "proteinAtUrineSection");
            object ProteinAtUrineSectionId = CreateAndSetIDProperty(ProteinAtUrineSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object ProteinAtUrineSectionCode = CreateAndSetCodeProperty(ProteinAtUrineSection, "IDRARDAPROTEIN", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Ýdrarda Protein Bilgisinin Olduðu Bölüm");
            object ProteinAtUrineSectionText = CreateAndSetTextProperty(ProteinAtUrineSection, "");
            object ProteinAtUrineSectionComponent = CreateAndSetParent(ProteinAtUrineSection, "component");
            object ProteinAtUrine = CreateAndSetParent(ProteinAtUrineSectionComponent, "proteinAtUrine");
            object ProteinAtUrineCode = CreateAndSetCodeProperty(ProteinAtUrine, GebeIzlem.IdrardaProtein.Code, "2.16.840.1.113883.3.129.1.2.36", "Ýdrarda Protein", "1.0", GebeIzlem.IdrardaProtein.DisplayName);


            object component4 = CreateAndSetParent(o, "component4");
            object LastMenstruationDateSection = CreateAndSetParent(component4, "lastMenstruationDateSection");
            object LastMenstruationDateSectionId = CreateAndSetIDProperty(LastMenstruationDateSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object LastMenstruationDateSectionCode = CreateAndSetCodeProperty(LastMenstruationDateSection, "SONADETTARIHI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Son Adet Tarihi Bilgisinin Olduðu Bölüm");
            object LastMenstruationDateSectionText = CreateAndSetTextProperty(LastMenstruationDateSection, "");
            object LastMenstruationDateSectionComponent = CreateAndSetParent(LastMenstruationDateSection, "component");
            object LastMenstruationDate = CreateAndSetParent(LastMenstruationDateSectionComponent, "lastMenstruationDate");
            object LastMenstruationDateEffectiveTime = CreateAndSetParent(LastMenstruationDate, "effectiveTime");
            SetProperty(LastMenstruationDateEffectiveTime, "value", GebeIzlem.SonAdetTarihi.ToString("yyyyMMdd"));


            object component5 = CreateAndSetParent(o, "component5");
            object WeightSection = CreateAndSetParent(component5, "weightSection");
            object WeightSectionId = CreateAndSetIDProperty(WeightSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object WeightSectionCode = CreateAndSetCodeProperty(WeightSection, "AGIRLIK", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Aðýrlýk  Bilgilerinin Olduðu Bölüm");
            object WeightSectionText = CreateAndSetTextProperty(WeightSection, "");
            object WeightSectionComponent = CreateAndSetParent(WeightSection, "component");
            object Weight = CreateAndSetParent(WeightSectionComponent, "weight");
            object WeightValue = CreateAndSetINTValue(Weight, GebeIzlem.Agirlik);

            object component6 = CreateAndSetParent(o, "component6");
            object PulseSection = CreateAndSetParent(component6, "pulseSection");
            object PulseSectionId = CreateAndSetIDProperty(PulseSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object PulseSectionCode = CreateAndSetCodeProperty(PulseSection, "NABIZ", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Nabýz Bilgisinin Olduðu Bölüm");
            object PulseSectionText = CreateAndSetTextProperty(PulseSection, "");
            object PulseSectionComponent = CreateAndSetParent(PulseSection, "component");
            object Pulse = CreateAndSetParent(PulseSectionComponent, "pulse");
            object PulseValue = CreateAndSetINTValue(Weight, GebeIzlem.Nabiz);


            if (GebeIzlem.GebelikteRiskFaktorleri.Count > 0)
            {
                object component7 = CreateAndSetParent(o, "component7");
                object RiskFactorAtPregnancySection = CreateAndSetParent(component7, "riskFactorAtPregnancySection");
                object RiskFactorAtPregnancySectionId = CreateAndSetIDProperty(RiskFactorAtPregnancySection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                object RiskFactorAtPregnancySectionCode = CreateAndSetCodeProperty(RiskFactorAtPregnancySection, "GEBELIKTERISKFAKTORU", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Gebelik Risk Faktörü Bilgisinin Olduðu Bölüm");
                object RiskFactorAtPregnancySectionText = CreateAndSetTextProperty(RiskFactorAtPregnancySection, "");
                object RiskFactorAtPregnancySectionArray = Array.CreateInstance(Type.GetType(GetPropertyTypeName(RiskFactorAtPregnancySection, "component")), GebeIzlem.GebelikteRiskFaktorleri.Count);
                SetProperty(RiskFactorAtPregnancySection, "component", RiskFactorAtPregnancySectionArray);
                object RiskFactorAtPregnancySectionComponent;


                for (int i = 0; i < GebeIzlem.GebelikteRiskFaktorleri.Count; i++)
                {
                    RiskFactorAtPregnancySectionComponent = CreateObject(GetPropertyTypeName(RiskFactorAtPregnancySection, "component"));
                    ((Array)RiskFactorAtPregnancySectionArray).SetValue(RiskFactorAtPregnancySectionComponent, i);
                    object RiskFactorAtPregnancy = CreateAndSetParent(RiskFactorAtPregnancySectionComponent, "riskFactorAtPregnancy");
                    object RiskFactorAtPregnancyCode = CreateAndSetCodeProperty(RiskFactorAtPregnancy, GebeIzlem.GebelikteRiskFaktorleri[i].Code, "2.16.840.1.113883.3.129.1.2.38", "Gebelikte Risk Faktörü", "1.0", GebeIzlem.GebelikteRiskFaktorleri[i].DisplayName);
                }
            }

            object component8 = CreateAndSetParent(o, "component8");
            object HemoglobinSection = CreateAndSetParent(component8, "hemoglobinSection");
            object HemoglobinSectionId = CreateAndSetIDProperty(HemoglobinSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object HemoglobinSectionCode = CreateAndSetCodeProperty(HemoglobinSection, "HEMOGLOBIN", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Hemoglobin Bilgilerinin Olduðu Bölüm");
            object HemoglobinSectionText = CreateAndSetTextProperty(HemoglobinSection, "");
            object HemoglobinSectionComponent = CreateAndSetParent(HemoglobinSection, "component");
            object Hemoglobin = CreateAndSetParent(HemoglobinSectionComponent, "hemoglobin");
            object HemoglobinCode = CreateAndSetCodeProperty(Hemoglobin, GebeIzlem.Hemoglobin.Code, "2.16.840.1.113883.3.129.1.2.30", "Hemoglobin", "1.0", GebeIzlem.Hemoglobin.DisplayName);




            if (GebeIzlem.GebelikTehlikeIsareti.Count > 0)
            {
                object component9 = CreateAndSetParent(o, "component9");
                object PregnancyPuerperantDangerSection = CreateAndSetParent(component9, "pregnancyPuerperantDangerSection");
                object PregnancyPuerperantDangerSectionId = CreateAndSetIDProperty(PregnancyPuerperantDangerSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                object PregnancyPuerperantDangerSectionCode = CreateAndSetCodeProperty(PregnancyPuerperantDangerSection, "TEHLIKEISARETI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Gebelik/Lohusalýk Seyrinde Tehlike Ýþareti Bilgisinin Olduðu Bölüm");
                object PregnancyPuerperantDangerSectionText = CreateAndSetTextProperty(PregnancyPuerperantDangerSection, "");
                object PregnancyPuerperantDangerSectionArray = Array.CreateInstance(Type.GetType(GetPropertyTypeName(PregnancyPuerperantDangerSection, "component")), GebeIzlem.GebelikTehlikeIsareti.Count);
                SetProperty(PregnancyPuerperantDangerSection, "component", PregnancyPuerperantDangerSectionArray);
                object PregnancyPuerperantDangerSectionComponent;


                for (int i = 0; i < GebeIzlem.GebelikTehlikeIsareti.Count; i++)
                {
                    PregnancyPuerperantDangerSectionComponent = CreateObject(GetPropertyTypeName(PregnancyPuerperantDangerSection, "component"));
                    ((Array)PregnancyPuerperantDangerSectionArray).SetValue(PregnancyPuerperantDangerSectionComponent, i);
                    object PregnancyPuerperantDangerSign = CreateAndSetParent(PregnancyPuerperantDangerSectionComponent, "pregnancyPuerperantDangerSign");
                    object PregnancyPuerperantDangerSignCode = CreateAndSetCodeProperty(PregnancyPuerperantDangerSign, GebeIzlem.GebelikTehlikeIsareti[i].Code, "2.16.840.1.113883.3.129.1.2.38", "Gebelikte Risk Faktörü", "1.0", GebeIzlem.GebelikTehlikeIsareti[i].DisplayName);
                }
            }            

            
        }

        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            mesaj_cevap = new MCCI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_yeni);

            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();
            POCD_MT000008TR01PregnancyObservation PregnancyObservation = new POCD_MT000008TR01PregnancyObservation();
            mesaj_yeni.controlActEvent.subject.pregnancyObservation = PregnancyObservation;
            DokumanBilgileriniDoldur(PregnancyObservation);

            PregnancyObservation.code.code = "GEBEIZLEM";
            PregnancyObservation.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            PregnancyObservation.code.codeSystemName = "Döküman Tipi";
            PregnancyObservation.code.codeSystemVersion = "1.0";
            PregnancyObservation.code.displayName = "Gebe Ýzlem MSVS (Vatandaþ/Yabancý)";

            PregnancyObservation.recordTarget = new POCD_MT000008TR01RecordTarget();
            POCD_MT000008TR01PatientRole PatientRole = new POCD_MT000008TR01PatientRole();
            PregnancyObservation.recordTarget.patientRole = PatientRole;
            PatientRoleDoldur(PatientRole);

            PregnancyObservation.component = new POCD_MT000008TR01Component1();
            PregnancyObservation.component.structuredBody = new POCD_MT000008TR01StructuredBody();
            PregnancyObservation.component.structuredBody.component = new POCD_MT000008TR01Component2();
            POCD_MT000008TR01PregnancyObservationDataset PregnancyObservationDataset = new POCD_MT000008TR01PregnancyObservationDataset();
            PregnancyObservation.component.structuredBody.component.pregnancyObservationDataset = PregnancyObservationDataset;
            PregnancyObservationDatasetDoldur(PregnancyObservationDataset);

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
