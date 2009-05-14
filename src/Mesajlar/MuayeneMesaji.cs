using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using SaglikNetLib.WebReference_Muayene;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Web.Services3.Security.Tokens;


namespace SaglikNetLib.Mesajlar
{
    class MuayeneMesaji :BaseMesaj,IMesaj   
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        VatandasYabanciHastaKayitMSVS VatandasYabanciKayit;
        List<TetkikSonucuMSVS> TetkikSonuclari;
        List<ReceteMSVS> Recete;
        HastaKabulMSVS HastaKabul;
        YenidoganKayitMSVS YenidoganKayit;
        HastaCikisMSVS HastaCikis;
        MuayeneMSVS Muayene;

        public MuayeneMesaji()
        {
            ws = new MCCI_AR000001TR_ServiceWse();

            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            TetkikSonuclari = new List<TetkikSonucuMSVS>();
            Recete = new List<ReceteMSVS>();
            HastaKabul = new HastaKabulMSVS();


            YenidoganKayit = new YenidoganKayitMSVS();
            HastaCikis = new HastaCikisMSVS();
            mesaj_cevap = new MCCI_IN000002TR01Message();


            Muayene = new MuayeneMSVS();

        }






        #region IMesaj Members

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

            mesaj_yeni.processingCode = new CS();
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

            POCD_MT000005TR01Examination Dokuman = new POCD_MT000005TR01Examination();
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();
            mesaj_yeni.controlActEvent.subject.examination = Dokuman;

            #region Dokuman bilgilerini doldur

            Dokuman.id = new POCD_MT000005TR01ExaminationID();
            Dokuman.id.root = "2.16.840.1.113883.3.129.2.1.3";
            Dokuman.id.extension=DokumanGUID;

            Dokuman.code = new POCD_MT000005TR01ExaminationCode();
            Dokuman.code.code = "MUAYENE";
            Dokuman.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            Dokuman.code.codeSystemName = "Döküman Tipi";
            Dokuman.code.codeSystemVersion = "1.0";
            Dokuman.code.displayName = "Muayene MSVS (Vatandaþ/Yabancý)";

            Dokuman.effectiveTime = new POCD_MT000005TR01ExaminationEffectiveTime();
            Dokuman.effectiveTime.value = DokumanIslemZamani.ToString("yyyyMMddhhmmss");

            Dokuman.confidentialityCode = new POCD_MT000005TR01ExaminationConfidentialityCode();
            Dokuman.confidentialityCode.code = "1";
            Dokuman.confidentialityCode.codeSystem = "2.16.840.1.113883.3.129.1.2.77";
            Dokuman.confidentialityCode.codeSystemName = "Gizlilik";
            Dokuman.confidentialityCode.codeSystemVersion = "1.0";
            Dokuman.confidentialityCode.displayName = "Normal";


            Dokuman.languageCode = new POCD_MT000005TR01ExaminationLanguageCode();
            Dokuman.languageCode.code = "tr-TR";
            
            Dokuman.versionNumber = new POCD_MT000005TR01ExaminationVersionNumber();
            Dokuman.versionNumber.value = "1";

            Dokuman.author = new POCD_MT000005TR01Author1();
            Dokuman.author.time = new POCD_MT000005TR01Author1Time();
            Dokuman.author.time.value = DokumanIslemZamani.ToString("yyyyMMddhhmmss");

            Dokuman.author.assignedAuthor = new POCD_MT000005TR01AssignedAuthor();
            Dokuman.author.assignedAuthor.id = new POCD_MT000005TR01AssignedAuthorID();
            Dokuman.author.assignedAuthor.id.root = "2.16.840.1.113883.3.129.1.1.1";
            Dokuman.author.assignedAuthor.id.extension = DokumanYazariTCKimlikNo;

            Dokuman.custodian = new POCD_MT000005TR01Custodian();
            Dokuman.custodian.assignedCustodian = new POCD_MT000005TR01AssignedCustodian();
            Dokuman.custodian.assignedCustodian.representedHealthcareOrganization = new POCD_MT000005TR01HealthcareOrganization();
            Dokuman.custodian.assignedCustodian.representedHealthcareOrganization.id = new POCD_MT000005TR01HealthcareOrganizationID();
            Dokuman.custodian.assignedCustodian.representedHealthcareOrganization.id.root = "2.16.840.1.113883.3.129.1.1.6";
            Dokuman.custodian.assignedCustodian.representedHealthcareOrganization.id.extension = DokumaniOlusturanKurum;

            Dokuman.primaryInformationRecipient = new POCD_MT000005TR01PrimaryInformationRecipient();
            Dokuman.primaryInformationRecipient.recipient = new POCD_MT000005TR01Recipient();
            Dokuman.primaryInformationRecipient.recipient.representedMinisteryOfHealth = new POCD_MT000005TR01MinisteryOfHealth();
            Dokuman.primaryInformationRecipient.recipient.representedMinisteryOfHealth.id.root = "2.16.840.1.113883.3.129.1.1.6";
            Dokuman.primaryInformationRecipient.recipient.representedMinisteryOfHealth.id.extension = "5881";

            POCD_MT000005TR01RecordTarget RecordTarget = new POCD_MT000005TR01RecordTarget();
            Dokuman.recordTarget = RecordTarget;

            if (HastaTuru == HastaTuru.Normal)
            {

                #region PatientRole
                POCD_MT000005TR01PatientRole PatientRole = new POCD_MT000005TR01PatientRole();
                RecordTarget.Item = PatientRole;
                PatientRole.id = new POCD_MT000005TR01PatientRoleID();
                PatientRole.id.root = "2.16.840.1.113883.3.129.1.1.1";
                PatientRole.id.extension = VatandasYabanciKayit.HastaTCKimlikNumarasi;
                POCD_MT000005TR01Patient Patient = new POCD_MT000005TR01Patient();
                PatientRole.patient = Patient;
                Patient.name = new POCD_MT000005TR01PatientName();
                Patient.name.Items = new ENXP[2];

                Patient.name.Items[0] = new engiven();
                Patient.name.Items[0].Text = new string[] { VatandasYabanciKayit.Ad };

                Patient.name.Items[1] = new enfamily();
                Patient.name.Items[1].Text = new string[] { VatandasYabanciKayit.Soyad };

                Patient.administrativeGenderCode = new POCD_MT000005TR01PatientAdministrativeGenderCode();
                Patient.administrativeGenderCode.code = VatandasYabanciKayit.Cinsiyet.Code;
                Patient.administrativeGenderCode.codeSystem = "2.16.840.1.113883.3.129.1.2.21";
                Patient.administrativeGenderCode.codeSystemName = "Cinsiyet";
                Patient.administrativeGenderCode.codeSystemVersion = "1.0";
                Patient.administrativeGenderCode.displayName = VatandasYabanciKayit.Cinsiyet.DisplayName;

                Patient.birthTime = new POCD_MT000005TR01PatientBirthTime();
                Patient.birthTime.value = VatandasYabanciKayit.DogumTarihi.ToString("yyyyMMdd");

                Patient.raceCode = new POCD_MT000005TR01PatientRaceCode();
                Patient.raceCode.code = VatandasYabanciKayit.Uyruk.Code;
                Patient.raceCode.codeSystem = "2.16.840.1.113883.3.129.1.2.52";
                Patient.raceCode.codeSystemName = "Uyruk";
                Patient.raceCode.codeSystemVersion = "1.0";
                Patient.raceCode.displayName = VatandasYabanciKayit.Uyruk.DisplayName;

                #endregion

            }
            else if (HastaTuru == HastaTuru.YeniDogan)
            {

                #region BabyPatientRole
                
                POCD_MT000005TR01BabyPatientRole BabyPatientRole = new POCD_MT000005TR01BabyPatientRole();
                RecordTarget.Item = BabyPatientRole;
                POCD_MT000005TR01Baby Baby = new POCD_MT000005TR01Baby();
                BabyPatientRole.patientBaby = Baby;
                
                Baby.administrativeGenderCode = new POCD_MT000005TR01BabyAdministrativeGenderCode();
                Baby.administrativeGenderCode.code = YenidoganKayit.Cinsiyet.Code;
                Baby.administrativeGenderCode.codeSystem = "2.16.840.1.113883.3.129.1.2.21";
                Baby.administrativeGenderCode.codeSystemName = "Cinsiyet";
                Baby.administrativeGenderCode.codeSystemVersion = "1.0";
                Baby.administrativeGenderCode.displayName = YenidoganKayit.Cinsiyet.DisplayName;

                Baby.birthTime = new POCD_MT000005TR01BabyBirthTime();
                Baby.birthTime.value = YenidoganKayit.DogumTarihi.ToString("yyyyMMdd");

                Baby.multipleBirthOrderNumber = new INT();
                Baby.multipleBirthOrderNumber.value = YenidoganKayit.DogumSirasi;

                Baby.guardian = new POCD_MT000005TR01Guardian();
                Baby.guardian.code = new POCD_MT000005TR01GuardianCode();
                Baby.guardian.guardianMother = new POCD_MT000005TR01Mother();
                Baby.guardian.guardianMother.id = new POCD_MT000005TR01MotherID();
                Baby.guardian.guardianMother.id.root = "2.16.840.1.113883.3.129.1.1.1";
                Baby.guardian.guardianMother.id.extension = YenidoganKayit.AnneTCKimlikNo;                

                #endregion

            }

            #endregion

            #region StructuredBody
            
            Dokuman.component = new POCD_MT000005TR01Component1();
            POCD_MT000005TR01StructuredBody StructuredBody = new POCD_MT000005TR01StructuredBody();
            Dokuman.component.structuredBody = StructuredBody;


            #region component1 - Tetkik sonuç bilgisinin bulunduðu verikýsmýný belirtir.
            
            POCD_MT000005TR01Component18[] Component18 = null;
            StructuredBody.component1 = Component18;
            if (TetkikSonuclari.Count > 0)
            {
                Component18 = new POCD_MT000005TR01Component18[TetkikSonuclari.Count];
                for (int i = 0; i < TetkikSonuclari.Count; i++)
                {
                    Component18[i] = new POCD_MT000005TR01Component18();
                    POCD_MT000005TR01TestResultDataset TestResultDataset = new POCD_MT000005TR01TestResultDataset();
                    Component18[i].testResultDataset = TestResultDataset;
                    
                    TestResultDataset.id = new POCD_MT000005TR01TestResultDatasetID();
                    TestResultDataset.id.root = "2.16.840.1.113883.3.129.2.1.4";
                    TestResultDataset.id.extension = UUID;
                    
                    TestResultDataset.code = new POCD_MT000005TR01TestResultDatasetCode();
                    TestResultDataset.code.code = "TETKIKSONUCU";
                    TestResultDataset.code.codeSystem = "2.16.840.1.113883.3.129.2.2.2";
                    TestResultDataset.code.codeSystemName = "Veriseti";
                    TestResultDataset.code.codeSystemVersion = "1.0";
                    TestResultDataset.code.displayName = "Tetkik Sonucu Veriseti";

                    TestResultDataset.text = new StrucDocText();
                    TestResultDataset.text.Text = new string[] { "" };

                    TestResultDataset.author = new POCD_MT000005TR01Author3();
                    TestResultDataset.author.testDoctor = new POCD_MT000005TR01TestDoctor();
                    TestResultDataset.author.testDoctor.id = new POCD_MT000005TR01TestDoctorID();
                    TestResultDataset.author.testDoctor.id.root = "2.16.840.1.113883.3.129.1.1.1";
                    TestResultDataset.author.testDoctor.id.extension = TetkikSonuclari[i].HekimKimlikNumarasi;

                    TestResultDataset.component = new POCD_MT000005TR01Component19();
                    TestResultDataset.component.testResultSection = new POCD_MT000005TR01TestResultSection();
                    TestResultDataset.component.testResultSection.id = new POCD_MT000005TR01TestResultSectionID();
                    TestResultDataset.component.testResultSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                    TestResultDataset.component.testResultSection.id.extension = UUID;

                    TestResultDataset.component.testResultSection.code = new POCD_MT000005TR01TestResultSectionCode();
                    TestResultDataset.component.testResultSection.code.code = "TETKIKSONUC";
                    TestResultDataset.component.testResultSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                    TestResultDataset.component.testResultSection.code.codeSystemName = "Veri Kýsmý";
                    TestResultDataset.component.testResultSection.code.codeSystemVersion = "1.0";
                    TestResultDataset.component.testResultSection.code.displayName = "Tetkik Sonuç Verisinin Olduðu Bölüm";

                    TestResultDataset.component.testResultSection.component = new POCD_MT000005TR01Component20();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer = new POCD_MT000005TR01TestResultOrganizer();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.statusCode = new POCD_MT000005TR01TestResultOrganizerStatusCode();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.statusCode.code = "completed";

                    TestResultDataset.component.testResultSection.component.testResultOrganizer.performer = new POCD_MT000005TR01Performer1();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.performer.studyOrganization = new POCD_MT000005TR01StudyOrganization();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.performer.studyOrganization.id = new POCD_MT000005TR01StudyOrganizationID();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.performer.studyOrganization.id.root = "2.16.840.1.113883.3.129.1.1.6";
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.performer.studyOrganization.id.extension = TetkikSonuclari[i].TetkikYapanKurum;

                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component = new POCD_MT000005TR01Component21[1];
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0] = new POCD_MT000005TR01Component21();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult = new POCD_MT000005TR01TestResult();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult.code = new POCD_MT000005TR01TestResultCode();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult.code.code = TetkikSonuclari[i].Tetkik.Code;
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult.code.codeSystem = "2.16.840.1.113883.3.129.1.2.2";
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult.code.codeSystemName = "SUT";
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult.code.codeSystemVersion = "1.0";
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult.code.displayName = TetkikSonuclari[i].Tetkik.DisplayName;

                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult.activityTime = new POCD_MT000005TR01TestResultActivityTime();
                    TestResultDataset.component.testResultSection.component.testResultOrganizer.component[0].testResult.activityTime.value = TetkikSonuclari[i].TetkikSonucTarihi.ToString("yyyyMMdd");
                }

            }
            #endregion

            #region component2 - Hasta çýkýþ verisetini belirtir.
            
            POCD_MT000005TR01Component2 Component2 = new POCD_MT000005TR01Component2();
            StructuredBody.component2 = Component2;

            POCD_MT000005TR01DischargeDataset DischargeDataset = new POCD_MT000005TR01DischargeDataset();
            Component2.dischargeDataset = DischargeDataset;

            DischargeDataset.id = new POCD_MT000005TR01DischargeDatasetID();
            DischargeDataset.id.root = "2.16.840.1.113883.3.129.2.1.4";
            DischargeDataset.id.extension = UUID;

            DischargeDataset.code = new POCD_MT000005TR01DischargeDatasetCode();
            DischargeDataset.code.code = "CIKIS";
            DischargeDataset.code.codeSystem = "2.16.840.1.113883.3.129.2.2.2";
            DischargeDataset.code.codeSystemName = "Veriseti";
            DischargeDataset.code.codeSystemVersion = "1.0";
            DischargeDataset.code.displayName = "Çýkýþ Veriseti";

            DischargeDataset.text = new StrucDocText();
            DischargeDataset.text.Text = new string[] { "" };

            DischargeDataset.component1 = new POCD_MT000005TR01Component3();
            DischargeDataset.component1.dischargeDiagnosisSection = new POCD_MT000005TR01DischargeDiagnosisSection();
            DischargeDataset.component1.dischargeDiagnosisSection.id = new POCD_MT000005TR01DischargeDiagnosisSectionID();
            DischargeDataset.component1.dischargeDiagnosisSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
            DischargeDataset.component1.dischargeDiagnosisSection.id.extension = UUID;

            DischargeDataset.component1.dischargeDiagnosisSection.code = new POCD_MT000005TR01DischargeDiagnosisSectionCode();
            DischargeDataset.component1.dischargeDiagnosisSection.code.code = "TANI";
            DischargeDataset.component1.dischargeDiagnosisSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
            DischargeDataset.component1.dischargeDiagnosisSection.code.codeSystemName = "Veri Kýsmý";
            DischargeDataset.component1.dischargeDiagnosisSection.code.codeSystemVersion = "1.0";
            DischargeDataset.component1.dischargeDiagnosisSection.code.displayName = "Taný Verisinin Olduðu Bölüm";

            DischargeDataset.component1.dischargeDiagnosisSection.text = new StrucDocText();
            DischargeDataset.component1.dischargeDiagnosisSection.text.Text = new string[] { "" };


            if (HastaKabul.SevkTanisi.Count > 0)
            {
                DischargeDataset.component1.dischargeDiagnosisSection.component = new POCD_MT000005TR01Component4[HastaKabul.SevkTanisi.Count];

                for (int i = 0; i < HastaKabul.SevkTanisi.Count; i++)
                {
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i] = new POCD_MT000005TR01Component4();
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis = new POCD_MT000005TR01DischargeDiagnosis();
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.code = new POCD_MT000005TR01DischargeDiagnosisCode();
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.code.code = "SEVKTANISI";
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.code.codeSystem = "2.16.840.1.113883.3.129.2.2.6";
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.code.codeSystemName = "Taný Tipi";
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.code.codeSystemVersion = "1.0";
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.code.displayName = "Sevk Tanýsý";
                    
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.value = new POCD_MT000005TR01DischargeDiagnosisValue();
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.value.code = HastaKabul.SevkTanisi[i].Code;
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.value.codeSystem = "2.16.840.1.113883.6.3";
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.value.codeSystemName = "ICD-10";
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.value.codeSystemVersion = "1.0";
                    DischargeDataset.component1.dischargeDiagnosisSection.component[i].dischargeDiagnosis.value.displayName = HastaKabul.SevkTanisi[i].DisplayName;

                }

            }


            DischargeDataset.component2 = new POCD_MT000005TR01Component5();
            DischargeDataset.component2.dischargeSection = new POCD_MT000005TR01DischargeSection();
            
            DischargeDataset.component2.dischargeSection.id = new POCD_MT000005TR01DischargeSectionID();
            DischargeDataset.component2.dischargeSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
            DischargeDataset.component2.dischargeSection.id.extension = UUID;

            DischargeDataset.component2.dischargeSection.code = new POCD_MT000005TR01DischargeSectionCode();
            DischargeDataset.component2.dischargeSection.code.code = "CIKIS";
            DischargeDataset.component2.dischargeSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
            DischargeDataset.component2.dischargeSection.code.codeSystemName = "Veri Kýsmý";
            DischargeDataset.component2.dischargeSection.code.codeSystemVersion = "1.0";
            DischargeDataset.component2.dischargeSection.code.displayName = "Çýkýþ Verisinin Olduðu Bölüm";

            DischargeDataset.component2.dischargeSection.text = new StrucDocText();
            DischargeDataset.component2.dischargeSection.text.Text = new string[] { "" };

            DischargeDataset.component2.dischargeSection.component = new POCD_MT000005TR01Component6();
            DischargeDataset.component2.dischargeSection.component.discharge = new POCD_MT000005TR01Discharge();
            DischargeDataset.component2.dischargeSection.component.discharge.code = new POCD_MT000005TR01DischargeCode();
            DischargeDataset.component2.dischargeSection.component.discharge.code.code = HastaCikis.CikisSekli.Code;
            DischargeDataset.component2.dischargeSection.component.discharge.code.codeSystem = "2.16.840.1.113883.3.129.1.2.9";
            DischargeDataset.component2.dischargeSection.component.discharge.code.codeSystemName = "Çýkýþ Þekli";
            DischargeDataset.component2.dischargeSection.component.discharge.code.codeSystemVersion = "1.0";
            DischargeDataset.component2.dischargeSection.component.discharge.code.displayName = HastaCikis.CikisSekli.DisplayName;
            
            DischargeDataset.component2.dischargeSection.component.discharge.effectiveTime = new POCD_MT000005TR01DischargeEffectiveTime();
            DischargeDataset.component2.dischargeSection.component.discharge.effectiveTime.value = HastaCikis.CikisZamani.ToString("yyyyMMdd");

            if (HastaCikis.SevkEdilenPoliklinik.IsSet)
            {
                DischargeDataset.component2.dischargeSection.component.discharge.destination = new POCD_MT000005TR01Destination();
                DischargeDataset.component2.dischargeSection.component.discharge.destination.referralToClinic = new POCD_MT000005TR01ReferralToClinic();
                DischargeDataset.component2.dischargeSection.component.discharge.destination.referralToClinic.code = new POCD_MT000005TR01ReferralToClinicCode();
                DischargeDataset.component2.dischargeSection.component.discharge.destination.referralToClinic.code.code = HastaCikis.SevkEdilenPoliklinik.Code;
                DischargeDataset.component2.dischargeSection.component.discharge.destination.referralToClinic.code.codeSystem = "2.16.840.1.113883.3.129.1.2.1";
                DischargeDataset.component2.dischargeSection.component.discharge.destination.referralToClinic.code.codeSystemName = "Klinikler";
                DischargeDataset.component2.dischargeSection.component.discharge.destination.referralToClinic.code.codeSystemVersion = "1.0";
                DischargeDataset.component2.dischargeSection.component.discharge.destination.referralToClinic.code.displayName = HastaCikis.SevkEdilenPoliklinik.DisplayName;
            }

            #endregion

            #region component3 - Muayene  verisetini belirtir.
            POCD_MT000005TR01Component22 Component22 = new POCD_MT000005TR01Component22();
            StructuredBody.component3 = Component22;

            POCD_MT000005TR01ExaminationDataset ExaminationDataset = new POCD_MT000005TR01ExaminationDataset();
            Component22.examinationDataset = ExaminationDataset;
            ExaminationDataset.id= new POCD_MT000005TR01ExaminationDatasetID();
            ExaminationDataset.id.root = "2.16.840.1.113883.3.129.2.1.4";
            ExaminationDataset.id.extension = UUID;

            ExaminationDataset.code = new POCD_MT000005TR01ExaminationDatasetCode();
            ExaminationDataset.code.code = "MUAYENE";
            ExaminationDataset.code.codeSystem = "2.16.840.1.113883.3.129.2.2.2";
            ExaminationDataset.code.codeSystemName = "Veriseti";
            ExaminationDataset.code.codeSystemVersion = "1.0";
            ExaminationDataset.code.displayName = "Muayene Veriseti";

            ExaminationDataset.text = new StrucDocText();
            ExaminationDataset.text.Text = new string[] { "" };

            ExaminationDataset.author = new POCD_MT000005TR01Author4();
            ExaminationDataset.author.doctor = new POCD_MT000005TR01Doctor();
            ExaminationDataset.author.doctor.id = new POCD_MT000005TR01DoctorID();
            ExaminationDataset.author.doctor.id.root = "2.16.840.1.113883.3.129.1.1.1";
            ExaminationDataset.author.doctor.id.extension = Muayene.HekimKimlikNumarasi;


            #region component1

            ExaminationDataset.component1 = new POCD_MT000005TR01Component23();
            ExaminationDataset.component1.examProtocolNoSection = new POCD_MT000005TR01ExamProtocolNoSection();
            
            ExaminationDataset.component1.examProtocolNoSection.id = new POCD_MT000005TR01ExamProtocolNoSectionID();
            ExaminationDataset.component1.examProtocolNoSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
            ExaminationDataset.component1.examProtocolNoSection.id.extension = UUID;

            ExaminationDataset.component1.examProtocolNoSection.code = new POCD_MT000005TR01ExamProtocolNoSectionCode();
            ExaminationDataset.component1.examProtocolNoSection.code.code = "PROTOKOLNO";
            ExaminationDataset.component1.examProtocolNoSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
            ExaminationDataset.component1.examProtocolNoSection.code.codeSystemName = "Veri Kýsmý";
            ExaminationDataset.component1.examProtocolNoSection.code.codeSystemVersion = "1.0";
            ExaminationDataset.component1.examProtocolNoSection.code.displayName = "Protokol No Bilgisinin Olduðu Bölüm";

            ExaminationDataset.component1.examProtocolNoSection.text = new StrucDocText();
            ExaminationDataset.component1.examProtocolNoSection.text.Text = new string[] { "" };

            ExaminationDataset.component1.examProtocolNoSection.component = new POCD_MT000005TR01Component24();
            ExaminationDataset.component1.examProtocolNoSection.component.examProtocolNo = new POCD_MT000005TR01ExamProtocolNo();
            ExaminationDataset.component1.examProtocolNoSection.component.examProtocolNo.id = new POCD_MT000005TR01ExamProtocolNoID();
            ExaminationDataset.component1.examProtocolNoSection.component.examProtocolNo.id.root= "2.16.840.1.113883.3.129.1.1.4";
            ExaminationDataset.component1.examProtocolNoSection.component.examProtocolNo.id.extension = Muayene.ProtokolNumarasi;

            #endregion

            #region component2

            if (Muayene.Rapor.Count > 0)
            {
                ExaminationDataset.component2 = new POCD_MT000005TR01Component25();
                ExaminationDataset.component2.reportSection = new POCD_MT000005TR01ReportSection();
                ExaminationDataset.component2.reportSection.id = new POCD_MT000005TR01ReportSectionID();
                ExaminationDataset.component2.reportSection.id.root="2.16.840.1.113883.3.129.2.1.5";
                ExaminationDataset.component2.reportSection.id.extension=UUID;

                ExaminationDataset.component2.reportSection.code = new POCD_MT000005TR01ReportSectionCode();
                ExaminationDataset.component2.reportSection.code.code = "RAPOR";
                ExaminationDataset.component2.reportSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                ExaminationDataset.component2.reportSection.code.codeSystemName = "Veri Kýsmý";
                ExaminationDataset.component2.reportSection.code.codeSystemVersion = "1.0";
                ExaminationDataset.component2.reportSection.code.displayName = "Rapor Verisinin Olduðu Bölüm";

                ExaminationDataset.component2.reportSection.text = new StrucDocText();
                ExaminationDataset.component2.reportSection.text.Text = new string[] { "" };


                ExaminationDataset.component2.reportSection.component = new POCD_MT000005TR01Component26[Muayene.Rapor.Count];
                for (int i = 0; i < Muayene.Rapor.Count; i++)
                {
                    ExaminationDataset.component2.reportSection.component[i] = new POCD_MT000005TR01Component26();
                    ExaminationDataset.component2.reportSection.component[i].report = new POCD_MT000005TR01Report();

                    ExaminationDataset.component2.reportSection.component[i].report.code = new POCD_MT000005TR01ReportCode();
                    ExaminationDataset.component2.reportSection.component[i].report.code.code = Muayene.Rapor[i].Turu.Code;
                    ExaminationDataset.component2.reportSection.component[i].report.code.codeSystem = "2.16.840.1.113883.3.129.1.2.8";
                    ExaminationDataset.component2.reportSection.component[i].report.code.codeSystemName = "Rapor Türü";
                    ExaminationDataset.component2.reportSection.component[i].report.code.codeSystemVersion = "1.0";
                    ExaminationDataset.component2.reportSection.component[i].report.code.displayName = Muayene.Rapor[i].Turu.DisplayName;
                    
                    ExaminationDataset.component2.reportSection.component[i].report.effectiveTime = new POCD_MT000005TR01ReportEffectiveTime();
                    ExaminationDataset.component2.reportSection.component[i].report.effectiveTime.value = Muayene.Rapor[i].Tarihi.ToString("yyyyMMdd");

                    ExaminationDataset.component2.reportSection.component[i].report.value = new ST();
                    ExaminationDataset.component2.reportSection.component[i].report.value.Text=new string[] { Muayene.Rapor[i].Dokumani };
                }

            }                                    
            

            #endregion

            #region component3

            ExaminationDataset.component3 = new POCD_MT000005TR01Component27();
            ExaminationDataset.component3.investigationSection = new POCD_MT000005TR01InvestigationSection();
            ExaminationDataset.component3.investigationSection.id = new POCD_MT000005TR01InvestigationSectionID();
            ExaminationDataset.component3.investigationSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
            ExaminationDataset.component3.investigationSection.id.extension = UUID;

            ExaminationDataset.component3.investigationSection.code = new POCD_MT000005TR01InvestigationSectionCode();
            ExaminationDataset.component3.investigationSection.code.code = "BULGU";
            ExaminationDataset.component3.investigationSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
            ExaminationDataset.component3.investigationSection.code.codeSystemName = "Veri Kýsmý";
            ExaminationDataset.component3.investigationSection.code.codeSystemVersion = "1.0";
            ExaminationDataset.component3.investigationSection.code.displayName = "Bulgu Verisinin Olduðu Bölüm";

            ExaminationDataset.component3.investigationSection.text = new StrucDocText();
            ExaminationDataset.component3.investigationSection.text.Text = new string[] { Muayene.Bulgu };

            #endregion

            #region component4

            ExaminationDataset.component4 = new POCD_MT000005TR01Component28();
            ExaminationDataset.component4.historySection = new POCD_MT000005TR01HistorySection();
            
            ExaminationDataset.component4.historySection.id = new POCD_MT000005TR01HistorySectionID();
            ExaminationDataset.component4.historySection.id.root = "2.16.840.1.113883.3.129.2.1.5";
            ExaminationDataset.component4.historySection.id.extension = UUID;
            
            ExaminationDataset.component4.historySection.code = new POCD_MT000005TR01HistorySectionCode();
            ExaminationDataset.component4.historySection.code.code = "HIKAYE";
            ExaminationDataset.component4.historySection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
            ExaminationDataset.component4.historySection.code.codeSystemName = "Veri Kýsmý";
            ExaminationDataset.component4.historySection.code.codeSystemVersion = "1.0";
            ExaminationDataset.component4.historySection.code.displayName = "Hikaye Verisinin Olduðu Bölüm";

            ExaminationDataset.component4.historySection.text = new StrucDocText();
            ExaminationDataset.component4.historySection.text.Text = new string[] { Muayene.Hikayesi };

            #endregion

            #region component5

            ExaminationDataset.component5 = new POCD_MT000005TR01Component29();
            ExaminationDataset.component5.complaintSection = new POCD_MT000005TR01ComplaintSection();
            ExaminationDataset.component5.complaintSection.id = new POCD_MT000005TR01ComplaintSectionID();
            ExaminationDataset.component5.complaintSection.id.root="2.16.840.1.113883.3.129.2.1.5";
            ExaminationDataset.component5.complaintSection.id.extension=UUID;

            ExaminationDataset.component5.complaintSection.code = new POCD_MT000005TR01ComplaintSectionCode();
            ExaminationDataset.component5.complaintSection.code.code = "SIKAYET";
            ExaminationDataset.component5.complaintSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
            ExaminationDataset.component5.complaintSection.code.codeSystemName = "Veri Kýsmý";
            ExaminationDataset.component5.complaintSection.code.codeSystemVersion = "1.0";
            ExaminationDataset.component5.complaintSection.code.displayName = "Þikayet Verisinin Olduðu Bölüm";

            ExaminationDataset.component5.complaintSection.text= new StrucDocText();
            ExaminationDataset.component5.complaintSection.text.Text = new string[] { Muayene.Sikayeti };

            #endregion

            #region component6
            if (Muayene.Tetkik.Count > 0)
            {

                ExaminationDataset.component6 = new POCD_MT000005TR01Component30();
                ExaminationDataset.component6.testSection = new POCD_MT000005TR01TestSection();

                ExaminationDataset.component6.testSection.id = new POCD_MT000005TR01TestSectionID();
                ExaminationDataset.component6.testSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                ExaminationDataset.component6.testSection.id.extension = UUID;

                ExaminationDataset.component6.testSection.code = new POCD_MT000005TR01TestSectionCode();
                ExaminationDataset.component6.testSection.code.code = "TETKIK";
                ExaminationDataset.component6.testSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                ExaminationDataset.component6.testSection.code.codeSystemName = "Veri Kýsmý";
                ExaminationDataset.component6.testSection.code.codeSystemVersion = "1.0";
                ExaminationDataset.component6.testSection.code.displayName = "Tetkik Verisinin Olduðu Bölüm";

                ExaminationDataset.component6.testSection.component = new POCD_MT000005TR01Component31[Muayene.Tetkik.Count];

                for (int i = 0; i < Muayene.Tetkik.Count; i++)
                {
                    ExaminationDataset.component6.testSection.component[i] = new POCD_MT000005TR01Component31();
                    ExaminationDataset.component6.testSection.component[i].test = new POCD_MT000005TR01Test();

                    ExaminationDataset.component6.testSection.component[i].test.code = new POCD_MT000005TR01TestCode();
                    ExaminationDataset.component6.testSection.component[i].test.code.code = Muayene.Tetkik[i].Tetkik.Code;
                    ExaminationDataset.component6.testSection.component[i].test.code.codeSystem = "2.16.840.1.113883.3.129.1.2.2";
                    ExaminationDataset.component6.testSection.component[i].test.code.codeSystemName = "SUT";
                    ExaminationDataset.component6.testSection.component[i].test.code.codeSystemVersion = "1.0";
                    ExaminationDataset.component6.testSection.component[i].test.code.displayName = Muayene.Tetkik[i].Tetkik.DisplayName;

                    ExaminationDataset.component6.testSection.component[i].test.performer = new POCD_MT000005TR01Performer2();
                    ExaminationDataset.component6.testSection.component[i].test.performer.performerOrganization = new POCD_MT000005TR01PerformerOrganization();
                    ExaminationDataset.component6.testSection.component[i].test.performer.performerOrganization.id = new POCD_MT000005TR01PerformerOrganizationID();
                    ExaminationDataset.component6.testSection.component[i].test.performer.performerOrganization.id.root = "2.16.840.1.113883.3.129.1.1.6";
                    ExaminationDataset.component6.testSection.component[i].test.performer.performerOrganization.id.extension = Muayene.Tetkik[i].TetkikIstenenKurum;

                }


            }
            
        

            #endregion

            #region component7

            if (Muayene.Mudahale.Count > 0)
            {

                ExaminationDataset.component7 = new POCD_MT000005TR01Component32();
                ExaminationDataset.component7.procedureSection = new POCD_MT000005TR01ProcedureSection();

                ExaminationDataset.component7.procedureSection.id = new POCD_MT000005TR01ProcedureSectionID();
                ExaminationDataset.component7.procedureSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                ExaminationDataset.component7.procedureSection.id.extension = UUID;
                
                ExaminationDataset.component7.procedureSection.code = new POCD_MT000005TR01ProcedureSectionCode();
                ExaminationDataset.component7.procedureSection.code.code = "MUDAHALE";
                ExaminationDataset.component7.procedureSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                ExaminationDataset.component7.procedureSection.code.codeSystemName = "Veri Kýsmý";
                ExaminationDataset.component7.procedureSection.code.codeSystemVersion = "1.0";
                ExaminationDataset.component7.procedureSection.code.displayName = "Müdehale Verisinin Olduðu Bölüm";

                ExaminationDataset.component7.procedureSection.text = new StrucDocText();
                ExaminationDataset.component7.procedureSection.text.Text = new string[] { "" };

                ExaminationDataset.component7.procedureSection.component = new POCD_MT000005TR01Component33[Muayene.Mudahale.Count];

                for (int i = 0; i < Muayene.Mudahale.Count; i++)
                {
                    ExaminationDataset.component7.procedureSection.component[i] = new POCD_MT000005TR01Component33();
                    ExaminationDataset.component7.procedureSection.component[i].procedure = new POCD_MT000005TR01Procedure();
                    ExaminationDataset.component7.procedureSection.component[i].procedure.code = new POCD_MT000005TR01ProcedureCode();
                    ExaminationDataset.component7.procedureSection.component[i].procedure.code.code = Muayene.Mudahale[i].Code;
                    ExaminationDataset.component7.procedureSection.component[i].procedure.code.codeSystem = "2.16.840.1.113883.3.129.1.2.2";
                    ExaminationDataset.component7.procedureSection.component[i].procedure.code.codeSystemName = "SUT";
                    ExaminationDataset.component7.procedureSection.component[i].procedure.code.codeSystemVersion = "1.0";
                    ExaminationDataset.component7.procedureSection.component[i].procedure.code.displayName = Muayene.Mudahale[i].DisplayName;
                }

            }
            #endregion

            #region component8

            ExaminationDataset.component8 = new POCD_MT000005TR01Component34();
            ExaminationDataset.component8.diagnosisSection = new POCD_MT000005TR01DiagnosisSection();
            ExaminationDataset.component8.diagnosisSection.id = new POCD_MT000005TR01DiagnosisSectionID();
            ExaminationDataset.component8.diagnosisSection.id.root="2.16.840.1.113883.3.129.2.1.5";
            ExaminationDataset.component8.diagnosisSection.id.extension=UUID;

            ExaminationDataset.component8.diagnosisSection.code = new POCD_MT000005TR01DiagnosisSectionCode();
            ExaminationDataset.component8.diagnosisSection.code.code = "TANI";
            ExaminationDataset.component8.diagnosisSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
            ExaminationDataset.component8.diagnosisSection.code.codeSystemName = "Veri Kýsmý";
            ExaminationDataset.component8.diagnosisSection.code.codeSystemVersion = "1.0";
            ExaminationDataset.component8.diagnosisSection.code.displayName = "Taný Verisinin Olduðu Bölüm";

            ExaminationDataset.component8.diagnosisSection.text = new StrucDocText();
            ExaminationDataset.component8.diagnosisSection.text.Text = new string[] { "" };

            ExaminationDataset.component8.diagnosisSection.component = new POCD_MT000005TR01Component35[Muayene.EkTani.Count+1];

            // Ana Tani
            ExaminationDataset.component8.diagnosisSection.component[0] = new POCD_MT000005TR01Component35();
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis = new POCD_MT000005TR01Diagnosis();
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.code = new POCD_MT000005TR01DiagnosisCode();
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.code.code = "ANATANI";
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.code.codeSystem = "2.16.840.1.113883.3.129.2.2.6";
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.code.codeSystemName = "Taný Tipi";
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.code.codeSystemVersion = "1.0";
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.code.displayName = "Ana Taný";

            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.value = new POCD_MT000005TR01DiagnosisValue();
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.value.code = Muayene.AnaTani.Code;
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.value.codeSystem = "2.16.840.1.113883.6.3";
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.value.codeSystemName = "ICD-10";
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.value.codeSystemVersion = "1.0";
            ExaminationDataset.component8.diagnosisSection.component[0].diagnosis.value.displayName = Muayene.AnaTani.DisplayName;

            if (Muayene.EkTani.Count > 0)
            {

                for (int s = 1; s < Muayene.EkTani.Count; s++)
                {
                    ExaminationDataset.component8.diagnosisSection.component[s] = new POCD_MT000005TR01Component35();

                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis = new POCD_MT000005TR01Diagnosis();
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.code = new POCD_MT000005TR01DiagnosisCode();
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.code.code = "EKTANI";
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.code.codeSystem = "2.16.840.1.113883.3.129.2.2.6";
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.code.codeSystemName = "Taný Tipi";
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.code.codeSystemVersion = "1.0";
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.code.displayName = "Ek Taný";

                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.value = new POCD_MT000005TR01DiagnosisValue();
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.value.code = Muayene.EkTani[s].Code;
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.value.codeSystem = "2.16.840.1.113883.6.3";
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.value.codeSystemName = "ICD-10";
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.value.codeSystemVersion = "1.0";
                    ExaminationDataset.component8.diagnosisSection.component[s].diagnosis.value.displayName = Muayene.EkTani[s].DisplayName;

                }
            }

            #endregion

            #region component9

            ExaminationDataset.component9 = new POCD_MT000005TR01Component36();
            ExaminationDataset.component9.examinationSection = new POCD_MT000005TR01ExaminationSection();
            ExaminationDataset.component9.examinationSection.id = new POCD_MT000005TR01ExaminationSectionID();
            ExaminationDataset.component9.examinationSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
            ExaminationDataset.component9.examinationSection.id.extension = UUID;

            ExaminationDataset.component9.examinationSection.code = new POCD_MT000005TR01ExaminationSectionCode();
            ExaminationDataset.component9.examinationSection.code.code = "MUAYENE";
            ExaminationDataset.component9.examinationSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
            ExaminationDataset.component9.examinationSection.code.codeSystemName = "Veri Kýsmý";
            ExaminationDataset.component9.examinationSection.code.codeSystemVersion = "1.0";
            ExaminationDataset.component9.examinationSection.code.displayName = "Muayene Verisinin Olduðu Bölüm";

            ExaminationDataset.component9.examinationSection.text = new StrucDocText();
            ExaminationDataset.component9.examinationSection.text.Text = new string[] { "" };

            ExaminationDataset.component9.examinationSection.component = new POCD_MT000005TR01Component37();
            ExaminationDataset.component9.examinationSection.component.encounter = new POCD_MT000005TR01Encounter();
            
            IVL_TS EffectiveTime = new IVL_TS();
            EffectiveTime.ItemsElementName = new ItemsChoiceType2[2];
            EffectiveTime.ItemsElementName[0] = ItemsChoiceType2.low;
            EffectiveTime.ItemsElementName[1] = ItemsChoiceType2.high;

            IVXB_TS low = new IVXB_TS();
            low.value = Muayene.MuayeneBaslangicZamani.ToString("yyyyMMddhhmmss");
            IVXB_TS high = new IVXB_TS();
            high.value = Muayene.MuayeneBitisZamani.ToString("yyyyMMddhhmmss");
 
            EffectiveTime.Items = new QTY[2];
            EffectiveTime.Items[0] = low;
            EffectiveTime.Items[1] = high;            

            ExaminationDataset.component9.examinationSection.component.encounter.effectiveTime = EffectiveTime;

            ExaminationDataset.component9.examinationSection.component.encounter.location = new POCD_MT000005TR01Location();
            ExaminationDataset.component9.examinationSection.component.encounter.location.clinic = new POCD_MT000005TR01Clinic();
            ExaminationDataset.component9.examinationSection.component.encounter.location.clinic.code = new POCD_MT000005TR01ClinicCode();
            ExaminationDataset.component9.examinationSection.component.encounter.location.clinic.code.code = Muayene.MuayeneYapilanPoliklinik.Code;
            ExaminationDataset.component9.examinationSection.component.encounter.location.clinic.code.codeSystem = "2.16.840.1.113883.3.129.1.2.1";
            ExaminationDataset.component9.examinationSection.component.encounter.location.clinic.code.codeSystemName = "Klinikler";
            ExaminationDataset.component9.examinationSection.component.encounter.location.clinic.code.codeSystemVersion = "1.0";
            ExaminationDataset.component9.examinationSection.component.encounter.location.clinic.code.displayName = Muayene.MuayeneYapilanPoliklinik.DisplayName;            
           
            #endregion
            
#endregion

            #region component4 - Hasta kabul verisetini belirtir.

            POCD_MT000005TR01Component38 Component38 = new POCD_MT000005TR01Component38();
            StructuredBody.component4 = Component38;

            POCD_MT000005TR01ReceptionDataset ReceptionDataset = new POCD_MT000005TR01ReceptionDataset();
            Component38.receptionDataset = ReceptionDataset;
            //ReceptionDatasetDoldur(ReceptionDataset);

            #endregion

            #region component5 - Reçete bilgilerinin bulunduðu verisetini belirtir.

            POCD_MT000005TR01Component7[] Component7 = null;
            StructuredBody.component5 = Component7;

            if (Recete.Count > 0)
            {
                Component7 = new POCD_MT000005TR01Component7[Recete.Count];
                //PrescriptionDatasetDoldur(Component7);
            }

            #endregion
            
            #endregion
            

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

        public void Gonder()
        {
            UsernameToken token = new UsernameToken(ServiceUsername, ServicePassword, PasswordOption.SendPlainText);
            MCCI_AR000001TR_ServiceWse ws = new MCCI_AR000001TR_ServiceWse();
            ws.Url = ServiceURL;
            ws.RequestSoapContext.Security.Tokens.Add(token);
            ws.RequestSoapContext.Security.MustUnderstand = false;

            //if ((ServiceSertifikaKullan) && (ServiceSertifikaYol.Length > 0))
            {
                X509Certificate X509 = new X509Certificate(ServiceSertifikaYol);
                ws.ClientCertificates.Add(X509);
                ServicePointManager.CertificatePolicy = new MyPolicy();
            }

            string acknowledgementcode = null;

            switch (SonMesajTuru)
            {

                case MesajTuru.Yok:
                    break;

                case MesajTuru.Yenikayit:
                    mesaj_cevap = ws.MCCI_AR000001TR_MCCI_IN000001TR(mesaj_yeni);
                    acknowledgementcode = mesaj_cevap.acknowledgement.typeCode.code;
                    break;

                case MesajTuru.Guncelle:
                    mesaj_cevap = ws.MCCI_AR000001TR_MCCI_IN000003TR(mesaj_guncelle);
                    acknowledgementcode = mesaj_cevap.acknowledgement.typeCode.code;
                    break;
                case MesajTuru.Iptal:

                    break;
                case MesajTuru.Sorgulama:
                    mesaj_sorgu_cevap = ws.MCCI_AR000001TR_QUQI_IN000001TR(mesaj_sorgu);
                    acknowledgementcode = mesaj_sorgu_cevap.acknowledgement.typeCode.code;
                    break;
                default:
                    break;
            }

            //return acknowledgementcode;

        }

        public void XMLKaydet(string DosyaAdi)
        {
            XmlSerializer serializer;
            FileStream fs;
            TextWriter writer;

            switch (SonMesajTuru)
            {
                case MesajTuru.Yok:
                    break;

                case MesajTuru.Yenikayit:
                    serializer = new XmlSerializer(typeof(MCCI_IN000001TR01Message));
                    fs = new FileStream(DosyaAdi, FileMode.OpenOrCreate);
                    writer = new StreamWriter(fs, Encoding.UTF8);
                    serializer.Serialize(writer, mesaj_yeni);
                    fs.Flush();
                    fs.Close();
                    break;

                case MesajTuru.Guncelle:
                    serializer = new XmlSerializer(typeof(MCCI_IN000003TR01Message));
                    fs = new FileStream(DosyaAdi, FileMode.OpenOrCreate);
                    writer = new StreamWriter(fs, Encoding.UTF8);
                    serializer.Serialize(writer, mesaj_guncelle);
                    fs.Flush();
                    fs.Close();
                    break;

                case MesajTuru.Iptal:
                    break;

                case MesajTuru.Sorgulama:
                    serializer = new XmlSerializer(typeof(QUQI_IN000001TR01Message));
                    fs = new FileStream(DosyaAdi, FileMode.OpenOrCreate);
                    writer = new StreamWriter(fs, Encoding.UTF8);
                    serializer.Serialize(writer, mesaj_sorgu);
                    fs.Flush();
                    fs.Close();
                    break;

                default:
                    break;
            }

        }

        public string XMLString()
        {
            XmlSerializer serializer = null;
            MemoryStream ms = new MemoryStream();
            StreamReader sr = null;

            switch (SonMesajTuru)
            {
                case MesajTuru.Yok:
                    break;

                case MesajTuru.Yenikayit:
                    serializer = new XmlSerializer(typeof(MCCI_IN000001TR01Message));
                    serializer.Serialize(ms, mesaj_yeni);
                    ms.Position = 0;
                    sr = new StreamReader(ms);
                    break;

                case MesajTuru.Guncelle:
                    serializer = new XmlSerializer(typeof(MCCI_IN000003TR01Message));
                    serializer.Serialize(ms, mesaj_yeni);
                    ms.Position = 0;
                    sr = new StreamReader(ms);

                    break;

                case MesajTuru.Iptal:
                    break;

                case MesajTuru.Sorgulama:
                    serializer = new XmlSerializer(typeof(QUQI_IN000001TR01Message));
                    serializer.Serialize(ms, mesaj_yeni);
                    ms.Position = 0;
                    sr = new StreamReader(ms);

                    break;

                default:
                    break;
            }

            return sr.ReadToEnd();

        }

        #endregion
    }
}
