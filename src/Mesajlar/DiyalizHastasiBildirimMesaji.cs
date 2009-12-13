using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSDiyalizBildirim;

namespace SaglikNetLib
{
    public class DiyalizHastasiBildirimMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public DiyalizHastasiBildirimMSVS DiyalizHastasiBildirim;

        public DiyalizHastasiBildirimMesaji()
        {
            DiyalizHastasiBildirim = new DiyalizHastasiBildirimMSVS();
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            YenidoganKayit = new YenidoganKayitMSVS();
            Muayene = new MuayeneMSVS();
            Recete = new List<ReceteMSVS>();
            TetkikSonuclari = new List<TetkikSonucuMSVS>();
            HastaKabul = new HastaKabulMSVS();
            HastaCikis = new HastaCikisMSVS();

        }

        public void DialysisDatasetDoldur(object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);

            //component5.diabetesDataset = new POCD_MT000026TR01DiabetesDataset();
            object oId = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4", UUID);
            object oCode = CreateAndSetCodeProperty(o, "DIYALIZBILDIRIM", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Diyaliz Bildirim Veriseti");
            object oText = CreateAndSetTextProperty(o, "");
            object oDialysisDatasetComponent1 = CreateAndSetParent(o, "component1");
            object oAlterHemodialysisTreatmentSection = CreateAndSetParent(oDialysisDatasetComponent1, "alterHemodialysisTreatmentSection");
            object oAlterHemodialysisTreatmentSectionId = CreateAndSetIDProperty(oAlterHemodialysisTreatmentSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oAlterHemodialysisTreatmentSectionCode = CreateAndSetCodeProperty(oAlterHemodialysisTreatmentSection, "ALTERNATIFHEMODIYALIZTEDAVISI", "Alternatif Hemodiyaliz Tedavisinin Bilgisinin Olduðu Bölüm", "1.0", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý");
            object oAlterHemodialysisTreatmentSectionText = CreateAndSetTextProperty(oAlterHemodialysisTreatmentSection, "");
            object oAlterHemodialysisTreatmentSectionComponent = CreateAndSetParent(oAlterHemodialysisTreatmentSection, "component");
            object oAlternativeHemodialysisTreatment = CreateAndSetParent(oAlterHemodialysisTreatmentSectionComponent, "alternativeHemodialysisTreatment");
            object oAlternativeHemodialysisTreatmentCode = CreateAndSetCodeProperty(oAlternativeHemodialysisTreatment, DiyalizHastasiBildirim.AlternatifHemodiyalizTedavisi.Code, "2.16.840.1.113883.3.129.1.2.79", "Alternatif Hemodiyaliz Tedavisi", "1.0", DiyalizHastasiBildirim.AlternatifHemodiyalizTedavisi.DisplayName);


            object oDialysisDatasetComponent2 = CreateAndSetParent(o, "component2");
            object oDialysisSection = CreateAndSetParent(oDialysisDatasetComponent2, "dialysisSection");
            object oDialysisSectionId = CreateAndSetIDProperty(oDialysisSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oDialysisSectionCode = CreateAndSetCodeProperty(oDialysisSection, "DIYALIZ", "Diyaliz Bilgisinin Olduðu Bölüm", "1.0", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý");
            object oDialysisSectionText = CreateAndSetTextProperty(oDialysisSection, "");
            object oDialysisSectionComponent1 = CreateAndSetParent(oDialysisSection, "component1");
            object oDialysisDiagnosis = CreateAndSetParent(oDialysisSectionComponent1, "dialysisDiagnosis");
            object oDialysisDiagnosisCode = CreateAndSetCodeProperty(oDialysisDiagnosis, "ANATANI", "2.16.840.1.113883.3.129.2.2.6", "Taný Tipi", "1.0", "Ana Taný");
            object oDialysisDiagnosisValue = CreateAndSetParent(oDialysisDiagnosis, "value");

            SetProperty(oDialysisDiagnosisValue, "code", DiyalizHastasiBildirim.AnaTani.Code);
            SetProperty(oDialysisDiagnosisValue, "codeSystem", "2.16.840.1.113883.6.3");
            SetProperty(oDialysisDiagnosisValue, "codeSystemName", "ICD-10");
            SetProperty(oDialysisDiagnosisValue, "codeSystemVersion", "1.0");
            SetProperty(oDialysisDiagnosisValue, "displayName", DiyalizHastasiBildirim.AnaTani.DisplayName);

            object oDialysisSectionComponent2 = CreateAndSetParent(oDialysisSection, "component2");
            object oDialysisTreatmentStartDate = CreateAndSetParent(oDialysisSectionComponent2, "dialysisTreatmentStartDate");
            object oEffectiveTime = CreateAndSetParent(oDialysisTreatmentStartDate, "effectiveTime");
            SetProperty(oEffectiveTime, "value", DiyalizHastasiBildirim.DiyalizTedavisineBaslamaTarihi.ToString("yyyyMMdd"));
            
        }

        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            MesajBilgileriniDoldur(mesaj_yeni);
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();
            
            POCD_MT000027TR01Dialysis Dialysis = new POCD_MT000027TR01Dialysis();
            mesaj_yeni.controlActEvent.subject.dialysis = Dialysis;
            DokumanBilgileriniDoldur(Dialysis);

            Dialysis.code.code = "DIYABET-YENIDOGAN";
            Dialysis.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            Dialysis.code.codeSystemName = "Döküman Tipi";
            Dialysis.code.codeSystemVersion = "1.0";
            Dialysis.code.displayName = "Diyabet MSVS (Yenidoðan)";

          

            POCD_MT000027TR01RecordTarget RecordTarget = new POCD_MT000027TR01RecordTarget();
            Dialysis.recordTarget = RecordTarget;
            POCD_MT000027TR01BabyPatientRole BabyPatientRole = new POCD_MT000027TR01BabyPatientRole();
            RecordTarget.Item = BabyPatientRole;
            BabyPatientRoleDoldur(BabyPatientRole);

            Dialysis.component = new  POCD_MT000027TR01Component1();
            POCD_MT000027TR01StructuredBody StructuredBody = new POCD_MT000027TR01StructuredBody();
            mesaj_yeni.controlActEvent.subject.dialysis.component.structuredBody = StructuredBody;

            StructuredBody.component1 = new POCD_MT000027TR01Component4();
            POCD_MT000027TR01DischargeDataset DischargeDataset = new POCD_MT000027TR01DischargeDataset();
            StructuredBody.component1.dischargeDataset = DischargeDataset;
            DischargeDatasetDoldur(DischargeDataset);

            StructuredBody.component2 = new POCD_MT000027TR01Component2();
            POCD_MT000027TR01DialysisDataset DialysisDataset = new POCD_MT000027TR01DialysisDataset();
            StructuredBody.component2.dialysisDataset = DialysisDataset;
            DialysisDatasetDoldur(DialysisDataset);

            


           
            POCD_MT000027TR01Component11[] Component11 = null;
            if (Recete.Count > 0)
            {
                Component11 = new POCD_MT000027TR01Component11[Recete.Count];
                PrescriptionDatasetDoldur(Component11);
            }
            StructuredBody.component3 = Component11;

            
            POCD_MT000027TR01Component23[] Component23 = null;                       
            if (TetkikSonuclari.Count > 0)
            {
                Component23 = new POCD_MT000027TR01Component23[TetkikSonuclari.Count];
                TestResultDatasetDoldur(Component23);
            }
            StructuredBody.component4 = Component23;


            StructuredBody.component5 = new POCD_MT000027TR01Component27();
            POCD_MT000027TR01ExaminationDataset ExaminationDataset = new POCD_MT000027TR01ExaminationDataset();
            StructuredBody.component5.examinationDataset = ExaminationDataset;
            ExaminationDatasetDoldur(ExaminationDataset);

            StructuredBody.component6 = new POCD_MT000027TR01Component44();
            POCD_MT000027TR01ReceptionDataset ReceptionDataset = new POCD_MT000027TR01ReceptionDataset();
            StructuredBody.component6.receptionDataset = ReceptionDataset;




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
