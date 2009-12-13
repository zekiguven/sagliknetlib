using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSDiyabet;

namespace SaglikNetLib
{
    public class DiyabetMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public DiyabetMSVS Diyabet;

        public DiyabetMesaji()
        {
            Diyabet = new DiyabetMSVS();
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            TetkikSonuclari = new List<TetkikSonucuMSVS>();
            Recete = new List<ReceteMSVS>();
            HastaKabul = new HastaKabulMSVS();
            YenidoganKayit = new YenidoganKayitMSVS();
            Muayene = new MuayeneMSVS();
            HastaCikis = new HastaCikisMSVS();

        }

        public void DiabetesDatasetDoldur(object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);

            //component5.diabetesDataset = new POCD_MT000026TR01DiabetesDataset();
            object oId = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4", UUID);
            object oCode = CreateAndSetCodeProperty(o, "DIYABET", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Diyabet Veriseti");
            object oText = CreateAndSetTextProperty(o, "");
            object oDiabetesDatasetComponent1 = CreateAndSetParent(o, "component1");
            object oAdditionalDiseaseWithDiabetesSection = CreateAndSetParent(oDiabetesDatasetComponent1, "additionalDiseaseWithDiabetesSection");
            object oAdditionalDiseaseWithDiabetesSectionId = CreateAndSetIDProperty(oAdditionalDiseaseWithDiabetesSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oAdditionalDiseaseWithDiabetesSectionCode = CreateAndSetCodeProperty(oAdditionalDiseaseWithDiabetesSection, "BIRLIKTESIKGORULENEKHASTALIKLAR", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Birlikte Sýk Görülen Ek Hastalýklar Bilgisinin Olduðu Bölüm");
            object oAdditionalDiseaseWithDiabetesSectionText = CreateAndSetTextProperty(oAdditionalDiseaseWithDiabetesSection, "");

            string oAdditionalDiseaseWithDiabetesSectionComponentName = GetPropertyTypeName(oAdditionalDiseaseWithDiabetesSection, "component");
            object oAdditionalDiseaseWithDiabetesSectionComponentArray = Array.CreateInstance(Type.GetType(oAdditionalDiseaseWithDiabetesSectionComponentName),Diyabet.BirlikteSikGorulenEkHastaliklar.Count);
            SetProperty(oAdditionalDiseaseWithDiabetesSection, "component", oAdditionalDiseaseWithDiabetesSectionComponentArray);
            object oAdditionalDiseaseWithDiabetesSectionComponent = null;

            for (int i = 0; i < Diyabet.BirlikteSikGorulenEkHastaliklar.Count; i++)
			{
                oAdditionalDiseaseWithDiabetesSectionComponent = CreateObject(oAdditionalDiseaseWithDiabetesSectionComponentName);
                ((Array)oAdditionalDiseaseWithDiabetesSectionComponentArray).SetValue(oAdditionalDiseaseWithDiabetesSectionComponent, i);

                Object oAdditionalDiseaseWithDiabetes = CreateAndSetParent(oAdditionalDiseaseWithDiabetesSectionComponent, "additionalDiseaseWithDiabetes");
                Object oAdditionalDiseaseWithDiabetesCode = CreateAndSetCodeProperty(oAdditionalDiseaseWithDiabetes, Diyabet.BirlikteSikGorulenEkHastaliklar[i].Code, "2.16.840.1.113883.3.129.1.2.57", "Birlikte sýk görülen ek hastalýklar", "1.0", Diyabet.BirlikteSikGorulenEkHastaliklar[i].DisplayName);
			}

            object oDiabetesDatasetComponent2 = CreateAndSetParent(o, "component2");
            object oThyroidExaminationSection = CreateAndSetParent(oDiabetesDatasetComponent2, "thyroidExaminationSection");                               
            object oThyroidExaminationSectionId = CreateAndSetIDProperty(oThyroidExaminationSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oThyroidExaminationSectionCode = CreateAndSetCodeProperty(oThyroidExaminationSection, "TIROIDMUAYENESI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Troid Muayenesi Bilgisinin Olduðu Bölüm");
            object oThyroidExaminationSectionText = CreateAndSetTextProperty(oThyroidExaminationSection, "");
            object oThyroidExaminationSectionComponent = CreateAndSetParent(oThyroidExaminationSection, "component");
            object oThyroidExamination = CreateAndSetParent(oThyroidExaminationSectionComponent, "thyroidExamination");
            object oThyroidExaminationCode = CreateAndSetCodeProperty(oThyroidExamination, Diyabet.TiroidMuayenesi.Code, "2.16.840.1.113883.3.129.1.2.56","Troid Muayenesi","1.0",Diyabet.TiroidMuayenesi.DisplayName);


            object oDiabetesDatasetComponent3 = CreateAndSetParent(o, "component3");
            object oWaistCircumferenceSection = CreateAndSetParent(oDiabetesDatasetComponent3, "waistCircumferenceSection");
            object oWaistCircumferenceSectionId = CreateAndSetIDProperty(oWaistCircumferenceSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oWaistCircumferenceSectionCode = CreateAndSetCodeProperty(oWaistCircumferenceSection, "BELCEVRESI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Bel Çevresi Bilgisinin Olduðu Bölüm");            
            object oWaistCircumferenceSectionText = CreateAndSetTextProperty(oWaistCircumferenceSection, "");
            object oWaistCircumferenceSectionComponent = CreateAndSetParent(oWaistCircumferenceSection, "component");
            object oWaistCircumference = CreateAndSetParent(oWaistCircumferenceSectionComponent, "waistCircumference");
            object oWaistCircumferenceValue = CreateAndSetINTValue(oWaistCircumference, Diyabet.BelCevresi);


            object oDiabetesDatasetComponent4 = CreateAndSetParent(o, "component4");
            object oBloodPressureSection = CreateAndSetParent(oDiabetesDatasetComponent4, "bloodPressureSection");
            object oBloodPressureSectionId = CreateAndSetIDProperty(oBloodPressureSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oBloodPressureSectionCode = CreateAndSetCodeProperty(oBloodPressureSection, "KANBASINCI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Kan Basýncý Bilgisinin Olduðu Bölüm");
            object oBloodPressureSectionText = CreateAndSetTextProperty(oBloodPressureSection, "");
            object oBloodPressureSectionComponent1 = CreateAndSetParent(oBloodPressureSection, "component1");
            object oDiastolicBloodPressure = CreateAndSetParent(oBloodPressureSectionComponent1, "diastolicBloodPressure");
            object oDiastolicBloodPressureValue = CreateAndSetINTValue(oDiastolicBloodPressure, Diyabet.DiastolikKanBasinci);
            object oBloodPressureSectionComponent2 = CreateAndSetParent(oBloodPressureSection, "component2");
            object oSystolicBloodPressure = CreateAndSetParent(oBloodPressureSectionComponent2, "systolicBloodPressure");
            object oSystolicBloodPressureValue = CreateAndSetINTValue(oSystolicBloodPressure, Diyabet.SistolikKanBasinci);

            object oDiabetesDatasetComponent5 = CreateAndSetParent(o, "component5");
            object oExerciseSection = CreateAndSetParent(oDiabetesDatasetComponent5, "exerciseSection");
            object oExerciseSectionId = CreateAndSetIDProperty(oExerciseSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oExerciseSectionCode = CreateAndSetCodeProperty(oExerciseSection, "EGZERSIZ", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Egzersiz Bilgisinin Olduðu Bölüm");
            object oExerciseSectionText = CreateAndSetTextProperty(oExerciseSection, "");
            object oExerciseSectionComponent = CreateAndSetParent(oExerciseSection, "component");
            object oExercise = CreateAndSetParent(oExerciseSectionComponent, "exercise");            
            object oExerciseCode  = CreateAndSetCodeProperty(oExercise, Diyabet.Egzersiz.Code,"2.16.840.1.113883.3.129.1.2.58","Egzersiz","1.0",Diyabet.Egzersiz.DisplayName);

            object oDiabetesDatasetComponent6 = CreateAndSetParent(o, "component6");
            object oMedicalNutritionAdaptationSection = CreateAndSetParent(oDiabetesDatasetComponent6, "medicalNutritionAdaptationSection");
            object oMedicalNutritionAdaptationSectionId = CreateAndSetIDProperty(oMedicalNutritionAdaptationSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oMedicalNutritionAdaptationSectionCode = CreateAndSetCodeProperty(oMedicalNutritionAdaptationSection, "TIBBIBESLENMETEDAVISINEUYUM", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Týbbi Beslenme Tedavisini Uyum Bilgisinin Olduðu Bölüm");
            object oMedicalNutritionAdaptationSectionText = CreateAndSetTextProperty(oMedicalNutritionAdaptationSection, "");
            object oMedicalNutritionAdaptationSectionComponent = CreateAndSetParent(oMedicalNutritionAdaptationSection, "component");
            object oMedicalNutritionAdaptation = CreateAndSetParent(oMedicalNutritionAdaptationSectionComponent, "medicalNutritionAdaptation");
            object oMedicalNutritionAdaptationCode = CreateAndSetCodeProperty(oMedicalNutritionAdaptation, Diyabet.TibbiBeslenmeTedavisineUyum.Code, "2.16.840.1.113883.3.129.1.2.55", "Týbbi Beslenme Tedavisine Uyum", "1.0", Diyabet.TibbiBeslenmeTedavisineUyum.DisplayName);

            object oDiabetesDatasetComponent7 = CreateAndSetParent(o, "component7");
            object oLengthSection = CreateAndSetParent(oDiabetesDatasetComponent7, "lengthSection");
            object oLengthSectionId = CreateAndSetIDProperty(oLengthSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oLengthSectionCode = CreateAndSetCodeProperty(oLengthSection, "BOY", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Boy Bilgisinin Olduðu Bölüm");
            object oLengthSectionText = CreateAndSetTextProperty(oLengthSection, "");
            object oLengthSectionComponent = CreateAndSetParent(oLengthSection, "component");
            object oLength = CreateAndSetParent(oLengthSectionComponent, "length");
            object oLengthValue = CreateAndSetINTValue(oLength, Diyabet.Boy);

            object oDiabetesDatasetComponent8 = CreateAndSetParent(o, "component8");
            object oWeightSection = CreateAndSetParent(oDiabetesDatasetComponent8, "weightSection");
            object oWeightSectionId = CreateAndSetIDProperty(oWeightSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oWeightSectionCode = CreateAndSetCodeProperty(oWeightSection, "AGIRLIK", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Aðýrlýk  Bilgilerinin Olduðu Bölüm");
            object oWeightSectionText = CreateAndSetTextProperty(oWeightSection, "");
            object oWeightSectionComponent = CreateAndSetParent(oWeightSection, "component");
            object oWeight = CreateAndSetParent(oWeightSectionComponent, "weight");
            object oWeightValue = CreateAndSetINTValue(oWeight, Diyabet.Agirlik);


            object oDiabetesDatasetComponent9 = CreateAndSetParent(o, "component9");
            object oFirstDiagnosisDateSection = CreateAndSetParent(oDiabetesDatasetComponent9, "firstDiagnosisDateSection");
            object oFirstDiagnosisDateSectionId = CreateAndSetIDProperty(oFirstDiagnosisDateSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oFirstDiagnosisDateSectionCode = CreateAndSetCodeProperty(oFirstDiagnosisDateSection, "ILKTANITARIHI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Ýlk Taný Tarihi Bilgisinin Olduðu Bölüm");
            object oFirstDiagnosisDateSectionText = CreateAndSetTextProperty(oFirstDiagnosisDateSection, "");
            object oFirstDiagnosisDateSectionComponent = CreateAndSetParent(oFirstDiagnosisDateSection, "component");
            object oFirstDiagnosisDate = CreateAndSetParent(oFirstDiagnosisDateSectionComponent, "firstDiagnosisDate");
            object oEffectiveTime = CreateAndSetParent(oFirstDiagnosisDate, "effectiveTime");
            SetProperty(oEffectiveTime, "value", Diyabet.IlkTaniTarihi.ToString("yyyyMMdd"));

            SonMesajTuru = MesajTuru.Yenikayit;
        }


        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            MesajBilgileriniDoldur(mesaj_yeni);
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();
            POCD_MT000026TR01Diabetes Diabetes = new POCD_MT000026TR01Diabetes();
            mesaj_yeni.controlActEvent.subject.diabetes = Diabetes;
            DokumanBilgileriniDoldur(Diabetes);

            Diabetes.code.code = "DIYABET-YENIDOGAN";
            Diabetes.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            Diabetes.code.codeSystemName = "Döküman Tipi";
            Diabetes.code.codeSystemVersion = "1.0";
            Diabetes.code.displayName = "Diyabet MSVS (Yenidoðan)";

            POCD_MT000026TR01RecordTarget RecordTarget = new POCD_MT000026TR01RecordTarget();
            Diabetes.recordTarget = RecordTarget;
            POCD_MT000026TR01BabyPatientRole BabyPatientRole = new POCD_MT000026TR01BabyPatientRole();
            RecordTarget.Item = BabyPatientRole;
            BabyPatientRoleDoldur(BabyPatientRole);
            
            Diabetes.component = new POCD_MT000026TR01Component1();
            POCD_MT000026TR01StructuredBody StructuredBody = new POCD_MT000026TR01StructuredBody();
            mesaj_yeni.controlActEvent.subject.diabetes.component.structuredBody = StructuredBody;
            
            POCD_MT000026TR01Component18[] Component18 = null;            
            if (TetkikSonuclari.Count > 0)
            {
                Component18 = new POCD_MT000026TR01Component18[TetkikSonuclari.Count];
                TestResultDatasetDoldur(Component18);
            }
            StructuredBody.component1 = Component18;

            POCD_MT000026TR01Component2 component2 = new POCD_MT000026TR01Component2(); 
            StructuredBody.component2= component2;            
            POCD_MT000026TR01DischargeDataset DischargeDataset = new POCD_MT000026TR01DischargeDataset();
            component2.dischargeDataset = DischargeDataset;
            DischargeDatasetDoldur(DischargeDataset);

            
            POCD_MT000026TR01Component22 component3 = new POCD_MT000026TR01Component22();
            StructuredBody.component3 = component3;
            POCD_MT000026TR01ExaminationDataset ExaminationDataset = new POCD_MT000026TR01ExaminationDataset();
            component3.examinationDataset = ExaminationDataset;
            ExaminationDatasetDoldur(ExaminationDataset);


            POCD_MT000026TR01Component38 component4 = new POCD_MT000026TR01Component38();
            StructuredBody.component4 = component4;
            POCD_MT000026TR01ReceptionDataset ReceptionDataset = new POCD_MT000026TR01ReceptionDataset();
            component4.receptionDataset = ReceptionDataset;
            ReceptionDatasetDoldur(ReceptionDataset);

           
            POCD_MT000026TR01Component47 component5 = new POCD_MT000026TR01Component47();
            StructuredBody.component5 = component5;
            POCD_MT000026TR01DiabetesDataset DiabetesDataset = new POCD_MT000026TR01DiabetesDataset();
            component5.diabetesDataset = DiabetesDataset;
            DiabetesDatasetDoldur(DiabetesDataset);
            
            

            POCD_MT000026TR01Component7[] Component7 = null;            
            if (Recete.Count > 0)
            {
                Component7 = new POCD_MT000026TR01Component7[Recete.Count];
                PrescriptionDatasetDoldur(Component7);                
            }
            StructuredBody.component6 = Component7;

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
