using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSKanser;

namespace SaglikNetLib
{
    public class KanserMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public KanserMSVS Kanser;

        public KanserMesaji()
        {
            Kanser = new KanserMSVS();
            HastaKabul = new HastaKabulMSVS();
            HastaCikis = new HastaCikisMSVS();
            Muayene = new MuayeneMSVS();
            Recete = new List<ReceteMSVS>();
            TetkikSonuclari = new List<TetkikSonucuMSVS>();
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            YenidoganKayit = new YenidoganKayitMSVS();
        }

        public void CancerDatasetDoldur(object o)
        {
            object Id = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4", UUID);
            object Code = CreateAndSetCodeProperty(o, "KANSER","2.16.840.1.113883.3.129.2.2.2","Veriseti","1.0","Kanser Veriseti");
            object Text = CreateAndSetTextProperty(o, "");
            
            object Component1 = CreateAndSetParent(o, "component1");
            object TreatmentMethodSection = CreateAndSetParent(Component1, "treatmentMethodSection");
            object TreatmentMethodSectionId = CreateAndSetIDProperty(TreatmentMethodSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object TreatmentMethodSectionCode = CreateAndSetCodeProperty(TreatmentMethodSection, "TEDAVIYONTEMI","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý","1.0","Tedavi Yöntemi Bilgisinin Olduðu Bölüm");
            object TreatmentMethodSectionText = CreateAndSetTextProperty(TreatmentMethodSection, "");
            object TreatmentMethodSectionComponent = CreateAndSetParent(TreatmentMethodSection, "component");
            object TreatmentMethod = CreateAndSetParent(TreatmentMethodSectionComponent, "treatmentMethod");
            object TreatmentMethodCode = CreateAndSetCodeProperty(TreatmentMethod, Kanser.TedaviYontemi.Code, "2.16.840.1.113883.3.129.1.2.63", "Tedavi Yöntemi", "1.0", Kanser.TedaviYontemi.DisplayName);


            object Component2 = CreateAndSetParent(o, "component2");
            object SeerSummaryPhaseSection = CreateAndSetParent(Component2, "seerSummaryPhaseSection");
            object SeerSummaryPhaseSectionId = CreateAndSetIDProperty(SeerSummaryPhaseSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object SeerSummaryPhaseSectionCode = CreateAndSetCodeProperty(SeerSummaryPhaseSection, "SEEROZETEVRE","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý","1.0","Seer Özet Evre Bilgisinin Olduðu Bölüm");
            object SeerSummaryPhaseSectionText = CreateAndSetTextProperty(SeerSummaryPhaseSection, "");
            object SeerSummaryPhaseSectionComponent = CreateAndSetParent(SeerSummaryPhaseSection, "component");
            object SeerSummaryPhase = CreateAndSetParent(SeerSummaryPhaseSectionComponent, "seerSummaryPhase");
            object SeerSummaryPhaseCode = CreateAndSetCodeProperty(SeerSummaryPhase, Kanser.SEEROzetEvre.Code, "2.16.840.1.113883.3.129.1.2.62", "Seer Özet Evre", "1.0", Kanser.SEEROzetEvre.DisplayName);												
								

            object Component3 = CreateAndSetParent(o, "component3");
            object PluralPrimaryStatusSection = CreateAndSetParent(Component3, "pluralPrimaryStatusSection");
            object PluralPrimaryStatusSectionId = CreateAndSetIDProperty(PluralPrimaryStatusSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object PluralPrimaryStatusSectionCode = CreateAndSetCodeProperty(PluralPrimaryStatusSection, "COGULPRIMERDURUMU","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý","1.0","Çoðul Primer Durumu Bilgisinin Olduðu Bölüm");
            object PluralPrimaryStatusSectionText = CreateAndSetTextProperty(PluralPrimaryStatusSection, "");
            object PluralPrimaryStatusSectionComponent = CreateAndSetParent(PluralPrimaryStatusSection, "component");
            object PluralPrimaryStatus = CreateAndSetParent(PluralPrimaryStatusSectionComponent, "pluralPrimaryStatus");
            object PluralPrimaryStatusCode = CreateAndSetCodeProperty(PluralPrimaryStatus, Kanser.CogulPrimerDurumu.Code, "2.16.840.1.113883.3.129.1.2.72", "Çoðul Primer Durumu", "1.0", Kanser.CogulPrimerDurumu.DisplayName);

							
            object Component4 = CreateAndSetParent(o, "component4");
            object LateralitySection = CreateAndSetParent(Component4, "lateralitySection");
            object LateralitySectionId = CreateAndSetIDProperty(LateralitySection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object LateralitySectionCode = CreateAndSetCodeProperty(LateralitySection, "LATERALITE","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý","1.0","Lateralite Bilgisinin Olduðu Bölüm");
            object LateralitySectionText = CreateAndSetTextProperty(LateralitySection, "");
            object LateralitySectionComponent = CreateAndSetParent(LateralitySection, "component");
            object Laterality = CreateAndSetParent(LateralitySectionComponent, "laterality");
            object LateralityCode = CreateAndSetCodeProperty(Laterality, Kanser.Lateralite.Code, "2.16.840.1.113883.3.129.1.2.64", "Lateralite", "1.0", Kanser.Lateralite.DisplayName);
           					

            object Component5 = CreateAndSetParent(o, "component5");
            object HistologicalTypeSection = CreateAndSetParent(Component5, "histologicalTypeSection");
            object HistologicalTypeSectionId = CreateAndSetIDProperty(HistologicalTypeSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object HistologicalTypeSectionCode = CreateAndSetCodeProperty(HistologicalTypeSection, "HISTOLOJIKTIP","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý","1.0","Histolojik Týp Bilgisinin Olduðu Bölüm");
            object HistologicalTypeSectionText = CreateAndSetTextProperty(HistologicalTypeSection, "");
            object HistologicalTypeSectionComponent = CreateAndSetParent(HistologicalTypeSection, "component");
            object HistologicalType = CreateAndSetParent(HistologicalTypeSectionComponent, "histologicalType");
            object HistologicalTypeCode = CreateAndSetCodeProperty(HistologicalType, Kanser.HistolojikTip.Code, "2.16.840.1.113883.3.129.1.2.61", "Histolojik Tip", "1.0", Kanser.HistolojikTip.DisplayName);
										

            object Component6 = CreateAndSetParent(o, "component6");
            object TumourPlaceSection = CreateAndSetParent(Component6, "tumourPlaceSection");
            object TumourPlaceSectionId = CreateAndSetIDProperty(TumourPlaceSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object TumourPlaceSectionCode = CreateAndSetCodeProperty(TumourPlaceSection, "TUMORUNYERI","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý","1.0","Tümörün Yeri Bilgisinin Olduðu Bölüm");
            object TumourPlaceSectionText = CreateAndSetTextProperty(TumourPlaceSection, "");
            object TumourPlaceSectionComponent = CreateAndSetParent(TumourPlaceSection, "component");
            object TumourPlace = CreateAndSetParent(TumourPlaceSectionComponent, "tumourPlace");
            object TumourPlaceCode = CreateAndSetCodeProperty(TumourPlace, Kanser.TumorunYeri.Code, "2.16.840.1.113883.3.129.1.2.60", "Tümör'ün Yeri", "1.0", Kanser.TumorunYeri.DisplayName);


            object Component7 = CreateAndSetParent(o, "component7");
            object DiagnosisMethodSection = CreateAndSetParent(Component7, "diagnosisMethodSection");
            object DiagnosisMethodSectionId = CreateAndSetIDProperty(DiagnosisMethodSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object DiagnosisMethodSectionCode = CreateAndSetCodeProperty(DiagnosisMethodSection, "TANIYONTEMI","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý","1.0","Taný Yöntemi Bilgisinin Olduðu Bölüm");
            object DiagnosisMethodSectionText = CreateAndSetTextProperty(DiagnosisMethodSection, "");
            object DiagnosisMethodSectionComponent = CreateAndSetParent(DiagnosisMethodSection, "component");
            object DiagnosisMethod = CreateAndSetParent(DiagnosisMethodSectionComponent, "diagnosisMethod");
            object DiagnosisMethodCode = CreateAndSetCodeProperty(DiagnosisMethod, Kanser.TaniYontemi.Code, "2.16.840.1.113883.3.129.1.2.59", "Taný Yöntemi", "1.0", Kanser.TaniYontemi.DisplayName);

								

            object Component8 = CreateAndSetParent(o, "component8");
            object FirstDiagnosisDateSection = CreateAndSetParent(Component8, "firstDiagnosisDateSection");
            object FirstDiagnosisDateSectionId = CreateAndSetIDProperty(FirstDiagnosisDateSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            object FirstDiagnosisDateSectionCode = CreateAndSetCodeProperty(FirstDiagnosisDateSection, "ILKTANITARIHI","2.16.840.1.113883.3.129.2.2.3","Veri Kýsmý","1.0","Ýlk Taný Tarihi Bilgisinin Olduðu Bölüm");
            object FirstDiagnosisDateSectionText = CreateAndSetTextProperty(FirstDiagnosisDateSection, "");
            object FirstDiagnosisDateSectionComponent = CreateAndSetParent(FirstDiagnosisDateSection, "component");
            object FirstDiagnosisDate = CreateAndSetParent(FirstDiagnosisDateSectionComponent, "firstDiagnosisDate");
            object FirstDiagnosisDateEffectiveTime = CreateAndSetParent(FirstDiagnosisDate, "effectiveTime");
            SetProperty(FirstDiagnosisDateEffectiveTime, "value", Kanser.IlkTaniTarihi.ToString("yyyyMMdd"));
            			
        }

        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            mesaj_cevap = new MCCI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_yeni);

            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();
            POCD_MT000025TR01Cancer Cancer = new POCD_MT000025TR01Cancer();
            mesaj_yeni.controlActEvent.subject.cancer = Cancer;

            DokumanBilgileriniDoldur(Cancer);

            Cancer.code.code = "KANSER-YENIDOGAN";
            Cancer.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            Cancer.code.codeSystemName = "Döküman Tipi";
            Cancer.code.codeSystemVersion = "1.0";
            Cancer.code.displayName = "Kanser MSVS (Yenidoðan)";

            Cancer.recordTarget = new POCD_MT000025TR01RecordTarget();
            
            //Cancer.recordTarget.Item

            POCD_MT000025TR01Patient PatientRole = new POCD_MT000025TR01Patient();
            Cancer.recordTarget.Item = PatientRole;
            PatientRoleDoldur(PatientRole);

            Cancer.component = new POCD_MT000025TR01Component1();
            Cancer.component.structuredBody = new POCD_MT000025TR01StructuredBody();
            
            Cancer.component.structuredBody.component1 = new POCD_MT000025TR01Component2();
            POCD_MT000025TR01CancerDataset CancerDataset = new POCD_MT000025TR01CancerDataset();
            CancerDatasetDoldur(CancerDataset);
            Cancer.component.structuredBody.component1.cancerDataset = CancerDataset;


            Cancer.component.structuredBody.component2 = new POCD_MT000025TR01Component19();
            POCD_MT000025TR01DischargeDataset DischargeDataset = new POCD_MT000025TR01DischargeDataset();
            DischargeDatasetDoldur(DischargeDataset);
            Cancer.component.structuredBody.component2.dischargeDataset = DischargeDataset;


            POCD_MT000025TR01Component24[] Component24 = null;
            if (Recete.Count > 0)
            {
                Component24 = new POCD_MT000025TR01Component24[Recete.Count];
                PrescriptionDatasetDoldur(Component24);
            }            
            Cancer.component.structuredBody.component3 = Component24;


            POCD_MT000025TR01Component36[] Component36 = null;
            if (TetkikSonuclari.Count > 0)
            {
                Component36 = new POCD_MT000025TR01Component36[TetkikSonuclari.Count];
                TestResultDatasetDoldur(Component36);
            }
            Cancer.component.structuredBody.component4 = Component36;

            Cancer.component.structuredBody.component5 = new POCD_MT000025TR01Component40();
            POCD_MT000025TR01ExaminationDataset ExaminationDataset = new POCD_MT000025TR01ExaminationDataset();
            Cancer.component.structuredBody.component5.examinationDataset = ExaminationDataset;
            ExaminationDatasetDoldur(ExaminationDataset);


            Cancer.component.structuredBody.component6 = new POCD_MT000025TR01Component56();
            POCD_MT000025TR01ReceptionDataset ReceptionDataset = new POCD_MT000025TR01ReceptionDataset();
            Cancer.component.structuredBody.component6.receptionDataset = ReceptionDataset;
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
