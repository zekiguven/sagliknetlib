using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSAgizVeDisSagligi;

namespace SaglikNetLib
{
    public class AgizVeDisSagligiMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        AgizVeDisSagligiMSVS AgizVeDisSagligi; 

        public AgizVeDisSagligiMesaji()
        {
            AgizVeDisSagligi= new AgizVeDisSagligiMSVS();
            HastaKabul = new HastaKabulMSVS();
            TetkikSonuclari = new List<TetkikSonucuMSVS>();
            Recete = new List<ReceteMSVS>();
            ws = new MCCI_AR000001TR_ServiceWse();
        }

        public void MouthTeethHealthDatasetDoldur( object o)
        {
            Object oId = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4", UUID);
            Object oCode = CreateAndSetCodeProperty(o, "AGIZDIS", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Aðýz-Diþ Veriseti");
            Object oText = CreateAndSetTextProperty(o, "");

            Object oAuthor = CreateAndSetParent(o, "author");
            Object oTime = CreateAndSetParent(oAuthor, "time");
            SetProperty(oTime, "value", AgizVeDisSagligi.IslemZamani.ToString("yyyyMMddhhmm"));

            Object oDoctor = CreateAndSetParent(oAuthor, "doctor");
            Object oDoctorId = CreateAndSetIDProperty(oDoctor, "2.16.840.1.113883.3.129.1.1.1", AgizVeDisSagligi.HekimKimlikNumarasi);

            Object oComponent1 = CreateAndSetParent(o, "component1");
            Object oExamProtocolNoSection = CreateAndSetParent(oComponent1, "examProtocolNoSection");
            Object oExamProtocolNoSectionId = CreateAndSetIDProperty(oExamProtocolNoSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oExamProtocolNoSectionCode = CreateAndSetCodeProperty(oExamProtocolNoSection, "PROTOKOLNO", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Protokol No Bilgisinin Olduðu Bölüm");
            Object oExamProtocolNoSectionText = CreateAndSetTextProperty(oExamProtocolNoSection, "");

            object oExamProtocolNoSectionComponent = CreateAndSetParent(oExamProtocolNoSection, "component");
            object oExamProtocolNo = CreateAndSetParent(oExamProtocolNoSectionComponent, "examProtocolNo");
            object oExamProtocolNoId = CreateAndSetIDProperty(oExamProtocolNo, "2.16.840.1.113883.3.129.1.1.4", AgizVeDisSagligi.ProtokolNumarasi);


            if (AgizVeDisSagligi.Tetkik.Count > 0)
            {

                Object oMouthTeethHealthDatasetComponent2 = CreateAndSetParent(o, "component2");
                Object oTestSection = CreateAndSetParent(oMouthTeethHealthDatasetComponent2, "testSection");
                Object oTestSectionID = CreateAndSetIDProperty(oTestSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                Object oTestSectionCode = CreateAndSetCodeProperty(oTestSection, "TETKIK", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Tetkik Verisinin Olduðu Bölüm");
                Object oTestSectionText = CreateAndSetTextProperty(oTestSection, "");

                string oTestSectionComponentName;
                Object oTestSectionComponentArray;
                Object oTestSectionComponent;

                oTestSectionComponentName = GetPropertyTypeName(oTestSection, "component");
                oTestSectionComponentArray = Array.CreateInstance(Type.GetType(oTestSectionComponentName), AgizVeDisSagligi.Tetkik.Count);
                SetProperty(oTestSection, "component", oTestSectionComponentArray);

                for (int s = 0; s < AgizVeDisSagligi.Tetkik.Count; s++)
                {
                    oTestSectionComponent = CreateObject(oTestSectionComponentName);
                    ((Array)oTestSectionComponentArray).SetValue(oTestSectionComponent, s);

                    Object oTest = CreateAndSetParent(oTestSectionComponent, "test");
                    Object oTestCode = CreateAndSetCodeProperty(oTest, AgizVeDisSagligi.Tetkik[s].Tetkik.Code, "2.16.840.1.113883.3.129.1.2.2", "SUT", "1.0", AgizVeDisSagligi.Tetkik[s].Tetkik.DisplayName);
                    Object oPerformer = CreateAndSetParent(oTest, "performer");
                    Object oPerformerOrganization = CreateAndSetParent(oPerformer, "performerOrganization");
                    Object oPerformerOrganizationID = CreateAndSetIDProperty(oPerformerOrganization, "2.16.840.1.113883.3.129.1.1.6", AgizVeDisSagligi.Tetkik[s].TetkikIstenenKurum);
                }
            }


            if (AgizVeDisSagligi.TedaviEdilenDisinKodu.Count > 0)
            {

                Object oMouthTeethHealthDatasetComponent3 = CreateAndSetParent(o, "component3");
                Object oCuredTeethSection = CreateAndSetParent(oMouthTeethHealthDatasetComponent3, "curedTeethSection");
                Object oCuredTeethSectionID = CreateAndSetIDProperty(oCuredTeethSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                Object oCuredTeethSectionCode = CreateAndSetCodeProperty(oCuredTeethSection, "DIS", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Tedavi Edilen Diþ Bilgilerinin Olduðu Bölüm");
                Object oCuredTeethSectionText = CreateAndSetTextProperty(oCuredTeethSection, "");

                string oCuredTeethSectionComponentName;
                Object oCuredTeethSectionComponentArray;
                Object oCuredTeethSectionComponent;

                oCuredTeethSectionComponentName = GetPropertyTypeName(oCuredTeethSection, "component");
                oCuredTeethSectionComponentArray = Array.CreateInstance(Type.GetType(oCuredTeethSectionComponentName), AgizVeDisSagligi.TedaviEdilenDisinKodu.Count);
                SetProperty(oCuredTeethSection, "component", oCuredTeethSectionComponentArray);

                for (int s = 0; s < AgizVeDisSagligi.TedaviEdilenDisinKodu.Count; s++)
                {
                    oCuredTeethSectionComponent = CreateObject(oCuredTeethSectionComponentName);
                    ((Array)oCuredTeethSectionComponentArray).SetValue(oCuredTeethSectionComponent, s);

                    Object oTooth = CreateAndSetParent(oCuredTeethSectionComponent, "tooth");
                    Object oToothCode = CreateAndSetCodeProperty(oTooth, AgizVeDisSagligi.TedaviEdilenDisinKodu[s].Code, "2.16.840.1.113883.3.129.1.2.2", "SUT", "1.0", AgizVeDisSagligi.TedaviEdilenDisinKodu[s].DisplayName);
                }
            }





            if (AgizVeDisSagligi.Mudahale.Count > 0)
            {

                Object oMouthTeethHealthDatasetComponent4 = CreateAndSetParent(o, "component4");
                Object oProcedureSection = CreateAndSetParent(oMouthTeethHealthDatasetComponent4, "procedureSection");
                Object oProcedureSectionID = CreateAndSetIDProperty(oProcedureSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                Object oProcedureSectionCode = CreateAndSetCodeProperty(oProcedureSection, "MUDAHALE", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Müdehale Verisinin Olduðu Bölüm");
                Object oProcedureSectionText = CreateAndSetTextProperty(oProcedureSection, "");

                string oProcedureSectionComponentName;
                Object oProcedureSectionComponentArray;
                Object oProcedureSectionComponent;

                oProcedureSectionComponentName = GetPropertyTypeName(oProcedureSection, "component");
                oProcedureSectionComponentArray = Array.CreateInstance(Type.GetType(oProcedureSectionComponentName), AgizVeDisSagligi.Mudahale.Count);
                SetProperty(oProcedureSection, "component", oProcedureSectionComponentArray);

                for (int s = 0; s < AgizVeDisSagligi.Mudahale.Count; s++)
                {
                    oProcedureSectionComponent = CreateObject(oProcedureSectionComponentName);
                    ((Array)oProcedureSectionComponentArray).SetValue(oProcedureSectionComponent, s);

                    Object oProcedure = CreateAndSetParent(oProcedureSectionComponent, "procedure");
                    Object oProcedureCode = CreateAndSetCodeProperty(oProcedure, AgizVeDisSagligi.Mudahale[s].Code, "2.16.840.1.113883.3.129.1.2.2", "SUT", "1.0", AgizVeDisSagligi.Mudahale[s].DisplayName);
                }
            }



            Object oMouthTeethHealthDatasetComponent5 = CreateAndSetParent(o, "component5");
            Object oExaminationSection = CreateAndSetParent(oMouthTeethHealthDatasetComponent5, "examinationSection");
            Object oExaminationSectionID = CreateAndSetIDProperty(oExaminationSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oExaminationSectionCode = CreateAndSetCodeProperty(oExaminationSection, "MUAYENE", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Muayene Verisinin Olduðu Bölüm");
            Object oExaminationSectionText = CreateAndSetTextProperty(oExaminationSection, "");
            object oExaminationSectionComponent = CreateAndSetParent(oExaminationSection, "component");
            object oEncounter = CreateAndSetParent(oExaminationSectionComponent, "encounter");
            SetEncounterProperty(oEncounter,
                AgizVeDisSagligi.MuayeneBaslangicZamani,
                AgizVeDisSagligi.MuayeneBitisZamani,
                AgizVeDisSagligi.MuayeneYapilanPoliklinik);





        }
        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            mesaj_cevap = new MCCI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_yeni);
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();            

            POCD_MT000006TR01MouthTeethHealth MouthTeethHealth = new POCD_MT000006TR01MouthTeethHealth();

            mesaj_yeni.controlActEvent.subject.mouthTeethHealth = MouthTeethHealth;
            DokumanBilgileriniDoldur(MouthTeethHealth);

            MouthTeethHealth.code.code = "AGIZDIS";
            MouthTeethHealth.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            MouthTeethHealth.code.codeSystemName = "Döküman Tipi";
            MouthTeethHealth.code.codeSystemVersion = "1.0";
            MouthTeethHealth.code.displayName = "Aðýz ve Diþ Saðlýðý MSVS (Vatandaþ/Yabancý)";

            POCD_MT000006TR01RecordTarget RecordTarget = new POCD_MT000006TR01RecordTarget();
            MouthTeethHealth.recordTarget = RecordTarget;

            POCD_MT000006TR01PatientRole PatientRole = new POCD_MT000006TR01PatientRole();
            RecordTarget.Item = PatientRole;

            PatientRoleDoldur(PatientRole);

            POCD_MT000006TR01Component1 Component1 = new POCD_MT000006TR01Component1();
            MouthTeethHealth.component = Component1;

            POCD_MT000006TR01StructuredBody StructuredBody = new POCD_MT000006TR01StructuredBody();
            Component1.structuredBody = StructuredBody;

            // Hasta Kabul
            StructuredBody.component1 = new POCD_MT000006TR01Component38();
            POCD_MT000006TR01ReceptionDataset ReceptionDataset = new POCD_MT000006TR01ReceptionDataset();
            StructuredBody.component1.receptionDataset = ReceptionDataset;
            ReceptionDatasetDoldur(ReceptionDataset);

            // MouthTeethHealthDataset
            StructuredBody.component2 = new POCD_MT000006TR01Component22();
            POCD_MT000006TR01MouthTeethHealthDataset MouthTeethHealthDataset = new POCD_MT000006TR01MouthTeethHealthDataset();
            StructuredBody.component2.mouthTeethHealthDataset = MouthTeethHealthDataset;

            MouthTeethHealthDatasetDoldur(MouthTeethHealthDataset);

            // Test sonuçlarý
            POCD_MT000006TR01Component18[] Component18 = null;
            StructuredBody.component3 = Component18;

            if (TetkikSonuclari.Count > 0)
            {
                Component18 = new POCD_MT000006TR01Component18[TetkikSonuclari.Count];
                TestResultDatasetDoldur(Component18);
            }

            // Reçete bilgileri
            POCD_MT000006TR01Component7[] Component7 = null;
            StructuredBody.component4 = Component7;
            if (Recete.Count > 0)
            {
                StructuredBody.component4 = new POCD_MT000006TR01Component7[Recete.Count];
                PrescriptionDatasetDoldur(Component7);
            }

            // Hasta Çýkýþ bilgileri
            POCD_MT000006TR01Component2 Component2 = new POCD_MT000006TR01Component2();
            StructuredBody.component5 = Component2;
            DischargeDatasetDoldur(Component2);
            
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
