using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSDiyalizIzlem;

namespace SaglikNetLib
{
    public class DiyalizHastasiIzlemMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public DiyalizHastasiIzlemMSVS DiyalizHastasiIzlem;
 
        public DiyalizHastasiIzlemMesaji()
        {
            DiyalizHastasiIzlem = new DiyalizHastasiIzlemMSVS();
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            YenidoganKayit = new YenidoganKayitMSVS();
            Muayene = new MuayeneMSVS();
            Recete = new List<ReceteMSVS>();
            TetkikSonuclari = new List<TetkikSonucuMSVS>();
            HastaKabul = new HastaKabulMSVS();
            HastaCikis = new HastaCikisMSVS();
        }

        public void DialysisObservationDatasetDoldur(object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);
            
            object oId = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4", UUID);
            object oCode = CreateAndSetCodeProperty(o, "DIYALIZIZLEM", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Diyaliz Ýzlem Veriseti");
            object oText = CreateAndSetTextProperty(o, "");

            object oDialysisObservationDatasetComponent1 = CreateAndSetParent(o, "component1");
            object oTreatmentCourseSection = CreateAndSetParent(oDialysisObservationDatasetComponent1, "treatmentCourseSection");
            object oTreatmentCourseSectionId = CreateAndSetIDProperty(oTreatmentCourseSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oTreatmentCourseSectionCode = CreateAndSetCodeProperty(oTreatmentCourseSection, "TEDAVININSEYRI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Tedavinin Seyri Bilgisinin Olduðu Bölüm");
            object oTreatmentCourseSectionText = CreateAndSetTextProperty(oTreatmentCourseSection, "");
            object oTreatmentCourseSectionComponent = CreateAndSetParent(oTreatmentCourseSection, "component");
            object oTreatmentCourse = CreateAndSetParent(oTreatmentCourseSectionComponent, "treatmentCourse");
            object oTreatmentCourseCode = CreateAndSetCodeProperty(oTreatmentCourse, DiyalizHastasiIzlem.TedavininSeyri.Code, "2.16.840.1.113883.3.129.1.2.83", "Tedavinin Seyri", "1.0", DiyalizHastasiIzlem.TedavininSeyri.DisplayName);


            object oDialysisObservationDatasetComponent2 = CreateAndSetParent(o, "component2");
            object oVitaminDTreatmentSection = CreateAndSetParent(oDialysisObservationDatasetComponent2, "vitaminDTreatmentSection");
            object oVitaminDTreatmentSectionId = CreateAndSetIDProperty(oVitaminDTreatmentSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oVitaminDTreatmentSectionCode = CreateAndSetCodeProperty(oVitaminDTreatmentSection, "AKTIFVITAMINDKULLANIMI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Aktif Vitamin D Kullanýmý Bilgisinin Olduðu Bölüm");
            object oVitaminDTreatmentSectionText = CreateAndSetTextProperty(oVitaminDTreatmentSection, "");
            object oVitaminDTreatmentSectionComponent = CreateAndSetParent(oVitaminDTreatmentSection, "component");
            object oVitaminDTreatment = CreateAndSetParent(oVitaminDTreatmentSectionComponent, "vitaminDTreatment");
            object oVitaminDTreatmentCode = CreateAndSetCodeProperty(oVitaminDTreatment, DiyalizHastasiIzlem.AktifVitaminDKullanimi.Code, "2.16.840.1.113883.3.129.1.2.84", "Aktif Vitamin D Kullanýmý", "1.0", DiyalizHastasiIzlem.AktifVitaminDKullanimi.DisplayName);


            object oDialysisObservationDatasetComponent3 = CreateAndSetParent(o, "component3");
            object oAnaemiaTreatmentSection = CreateAndSetParent(oDialysisObservationDatasetComponent3, "anaemiaTreatmentSection");
            object oAnaemiaTreatmentSectionId = CreateAndSetIDProperty(oAnaemiaTreatmentSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oAnaemiaTreatmentSectionCode = CreateAndSetCodeProperty(oAnaemiaTreatmentSection, "ANEMITEDAVI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Anemi Tedavi Bilgisinin Olduðu Bölüm");
            object oAnaemiaTreatmentSectionText = CreateAndSetTextProperty(oAnaemiaTreatmentSection, "");
            object oAnaemiaTreatmentSectionComponent = CreateAndSetParent(oAnaemiaTreatmentSection, "component");
            object oAnaemiaTreatment = CreateAndSetParent(oAnaemiaTreatmentSectionComponent, "anaemiaTreatment");
            object oAnaemiaTreatmentCode = CreateAndSetCodeProperty(oAnaemiaTreatment, DiyalizHastasiIzlem.AnemiTedavisiYontemi.Code, "2.16.840.1.113883.3.129.1.2.84", "Aktif Vitamin D Kullanýmý", "1.0", DiyalizHastasiIzlem.AnemiTedavisiYontemi.DisplayName);


            object oDialysisObservationDatasetComponent4 = CreateAndSetParent(o, "component4");
            object oDialysisTreatmentSection = CreateAndSetParent(oDialysisObservationDatasetComponent4, "dialysisTreatmentSection");
            object oDialysisTreatmentSectionId = CreateAndSetIDProperty(oDialysisTreatmentSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object oDialysisTreatmentSectionCode = CreateAndSetCodeProperty(oDialysisTreatmentSection, "DIYALIZTEDAVI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Diyaliz Tedavi Bilgisinin Olduðu Bölüm");
            object oDialysisTreatmentSectionText = CreateAndSetTextProperty(oDialysisTreatmentSection, "");

            object oDialysisTreatmentSectionComponent1 = CreateAndSetParent(oDialysisTreatmentSection, "component1");
            object oDialysisFrequency = CreateAndSetParent(oDialysisTreatmentSectionComponent1, "dialysisFrequency");
            object oDialysisFrequencyCode = CreateAndSetCodeProperty(oDialysisFrequency, DiyalizHastasiIzlem.DiyalizeGirmeSikligi.Code, "2.16.840.1.113883.3.129.1.2.82", "Diyalize Girme Sýklýðý", "1.0", DiyalizHastasiIzlem.DiyalizeGirmeSikligi.DisplayName);

            object oDialysisTreatmentSectionComponent2 = CreateAndSetParent(oDialysisTreatmentSection, "component2");
            object oDialysisTreatment = CreateAndSetParent(oDialysisTreatmentSectionComponent2, "dialysisTreatment");
            object oDialysisTreatmentCode = CreateAndSetCodeProperty(oDialysisTreatment, DiyalizHastasiIzlem.DiyalizTedavisiYöntemi.Code, "2.16.840.1.113883.3.129.1.2.81", "Diyaliz Tedavi", "1.0", DiyalizHastasiIzlem.DiyalizTedavisiYöntemi.DisplayName);
            
        }

        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            MesajBilgileriniDoldur(mesaj_yeni);
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();

            POCD_MT000028TR01DialysisObservation DialysisObservation = new POCD_MT000028TR01DialysisObservation();
            mesaj_yeni.controlActEvent.subject.dialysisObservation = DialysisObservation;
            DokumanBilgileriniDoldur(DialysisObservation);

            DialysisObservation.code.code = "DIYABET-YENIDOGAN";
            DialysisObservation.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            DialysisObservation.code.codeSystemName = "Döküman Tipi";
            DialysisObservation.code.codeSystemVersion = "1.0";
            DialysisObservation.code.displayName = "Diyabet MSVS (Yenidoðan)";

            
            POCD_MT000028TR01RecordTarget RecordTarget = new POCD_MT000028TR01RecordTarget();
            DialysisObservation.recordTarget = RecordTarget;
            POCD_MT000028TR01BabyPatientRole BabyPatientRole = new POCD_MT000028TR01BabyPatientRole();
            RecordTarget.Item = BabyPatientRole;
            BabyPatientRoleDoldur(BabyPatientRole);

            DialysisObservation.component = new POCD_MT000028TR01Component1();
            POCD_MT000028TR01StructuredBody StructuredBody = new POCD_MT000028TR01StructuredBody();
            mesaj_yeni.controlActEvent.subject.dialysisObservation.component.structuredBody = StructuredBody;

            StructuredBody.component1 = new POCD_MT000028TR01Component4();
            POCD_MT000028TR01DischargeDataset DischargeDataset = new POCD_MT000028TR01DischargeDataset();
            StructuredBody.component1.dischargeDataset = DischargeDataset;
            DischargeDatasetDoldur(DischargeDataset);

            StructuredBody.component2 = new POCD_MT000028TR01Component2();
            POCD_MT000028TR01DialysisObservationDataset DialysisObservationDataset = new POCD_MT000028TR01DialysisObservationDataset();
            StructuredBody.component2.dialysisObservationDataset = DialysisObservationDataset;
            DialysisObservationDatasetDoldur(DialysisObservationDataset);
           
            POCD_MT000028TR01Component15[] Component15 = null;
            if (Recete.Count > 0)
            {
                Component15 = new POCD_MT000028TR01Component15[Recete.Count];
                PrescriptionDatasetDoldur(Component15);
            }
            StructuredBody.component3 = Component15;

            
            POCD_MT000028TR01Component27[] Component27 = null;
            if (TetkikSonuclari.Count > 0)
            {
                Component27 = new POCD_MT000028TR01Component27[TetkikSonuclari.Count];
                TestResultDatasetDoldur(Component27);
            }
            StructuredBody.component4 = Component27;

            StructuredBody.component5 = new POCD_MT000028TR01Component31();
            POCD_MT000028TR01ExaminationDataset ExaminationDataset = new POCD_MT000028TR01ExaminationDataset();
            StructuredBody.component5.examinationDataset = ExaminationDataset;
            ExaminationDatasetDoldur(ExaminationDataset);


            StructuredBody.component6 = new POCD_MT000028TR01Component48();
            POCD_MT000028TR01ReceptionDataset ReceptionDataset = new POCD_MT000028TR01ReceptionDataset();
            StructuredBody.component6.receptionDataset = ReceptionDataset;
            ReceptionDatasetDoldur(ReceptionDataset);

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
