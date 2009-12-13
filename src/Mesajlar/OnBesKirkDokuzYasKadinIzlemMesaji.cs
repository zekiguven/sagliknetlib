using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WS1549YasKadinIzlem;

namespace SaglikNetLib
{
    public class OnBesKirkDokuzYasKadinIzlemMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        public OnbesKirkDokuzYasKadinIzlemMSVS OnbesKirkDokuzYasKadinIzlem;

        public OnBesKirkDokuzYasKadinIzlemMesaji()
        {
            VatandasYabanciKayit = new VatandasYabanciHastaKayitMSVS();
            OnbesKirkDokuzYasKadinIzlem = new OnbesKirkDokuzYasKadinIzlemMSVS();
            ws = new MCCI_AR000001TR_ServiceWse();
        }

        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            mesaj_cevap = new MCCI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_yeni);
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();

            POCD_MT000007TR01WomanObservation WomanObservation = new POCD_MT000007TR01WomanObservation();
            mesaj_yeni.controlActEvent.subject.womanObservation = WomanObservation;

            DokumanBilgileriniDoldur(WomanObservation);

            WomanObservation.code.code = "KADINIZLEM";
            WomanObservation.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            WomanObservation.code.codeSystemName = "Döküman Tipi";
            WomanObservation.code.codeSystemVersion = "1.0";
            WomanObservation.code.displayName = "15-49 Yaþ Kadýn Ýzlem MSVS (Vatandaþ/Yabancý)";

            POCD_MT000007TR01RecordTarget RecordTarget = new POCD_MT000007TR01RecordTarget();
            WomanObservation.recordTarget = RecordTarget;

            
            POCD_MT000007TR01PatientRole PatientRole = new POCD_MT000007TR01PatientRole();
            RecordTarget.patientRole = PatientRole;

            PatientRoleDoldur(PatientRole);

            
            POCD_MT000007TR01Component1 Component = new POCD_MT000007TR01Component1();
            WomanObservation.component = Component;

            Component.structuredBody = new POCD_MT000007TR01StructuredBody();
            Component.structuredBody.component = new POCD_MT000007TR01Component2();
            POCD_MT000007TR01WomanObservationDataset WomanObservationDataset = new POCD_MT000007TR01WomanObservationDataset();
            Component.structuredBody.component.womanObservationDataset = WomanObservationDataset;
            Object  WomanObservationDatasetId = CreateAndSetIDProperty(WomanObservationDataset, "2.16.840.1.113883.3.129.2.1.4", UUID);
            Object WomanObservationDatasetCode = CreateAndSetCodeProperty(WomanObservationDataset, "KADINIZLEM", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "15-49 Yaþ Arasý Kadýn Ýzlem Veriseti");
            Object WomanObservationDatasetText = CreateAndSetTextProperty(WomanObservationDataset, "");

            WomanObservationDataset.author = new POCD_MT000007TR01Author2();
            WomanObservationDataset.author.time = new POCD_MT000007TR01Author2Time();
            WomanObservationDataset.author.doctor = new POCD_MT000007TR01Doctor();
            WomanObservationDataset.author.doctor.id = new POCD_MT000007TR01DoctorID[2];
            WomanObservationDataset.author.doctor.id[0] = new POCD_MT000007TR01DoctorID();
            WomanObservationDataset.author.doctor.id[0].root = "2.16.840.1.113883.3.129.1.1.1";
            WomanObservationDataset.author.doctor.id[0].extension = OnbesKirkDokuzYasKadinIzlem.HekimKimlikNumarasi;
            WomanObservationDataset.author.doctor.id[1] = new POCD_MT000007TR01DoctorID();
            WomanObservationDataset.author.doctor.id[1].root = "2.16.840.1.113883.3.129.1.1.1";
            WomanObservationDataset.author.doctor.id[1].extension = OnbesKirkDokuzYasKadinIzlem.HekimKimlikNumarasi;

            if (OnbesKirkDokuzYasKadinIzlem.KonjenitalAnomaliliDogumVarligi.Code.Length > 0)
            {
                WomanObservationDataset.component1 = new POCD_MT000007TR01Component10();
                WomanObservationDataset.component1.congenitalAnomalyBirthSection = new POCD_MT000007TR01CongenitalAnomalyBirthSection();
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.id = new POCD_MT000007TR01CongenitalAnomalyBirthSectionID();
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.id.extension = UUID;
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.code = new POCD_MT000007TR01CongenitalAnomalyBirthSectionCode();
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.code.code = "KONJENITALANOMALILIDOGUM";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.code.codeSystemName = "Veri Kýsmý";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.code.displayName = "Konjenital Anomalili Doðum Bilgilerinin Olduðu Bölüm";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.text = new StrucDocText();
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.text.Text = new string[] { "" };

                WomanObservationDataset.component1.congenitalAnomalyBirthSection.component = new POCD_MT000007TR01Component11();

                WomanObservationDataset.component1.congenitalAnomalyBirthSection.component.congenitalAnomaly = new POCD_MT000007TR01CongenitalAnomaly();
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.component.congenitalAnomaly.code = new POCD_MT000007TR01CongenitalAnomalyCode();
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.component.congenitalAnomaly.code.code=OnbesKirkDokuzYasKadinIzlem.KonjenitalAnomaliliDogumVarligi.Code;
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.component.congenitalAnomaly.code.codeSystem = "2.16.840.1.113883.3.129.1.2.28";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.component.congenitalAnomaly.code.codeSystemName = "Konjenital Anomali";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.component.congenitalAnomaly.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component1.congenitalAnomalyBirthSection.component.congenitalAnomaly.code.displayName = OnbesKirkDokuzYasKadinIzlem.KonjenitalAnomaliliDogumVarligi.DisplayName;

            }




            if ((OnbesKirkDokuzYasKadinIzlem.CanliDoganBebekSayisi.Length>0) || (OnbesKirkDokuzYasKadinIzlem.OluDoganBebekSayisi.Length>0))
            {
                WomanObservationDataset.component2 = new POCD_MT000007TR01Component12();
                WomanObservationDataset.component2.babyNumberSection = new POCD_MT000007TR01BabyNumberSection();
                WomanObservationDataset.component2.babyNumberSection.id = new POCD_MT000007TR01BabyNumberSectionID();
                WomanObservationDataset.component2.babyNumberSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                WomanObservationDataset.component2.babyNumberSection.id.extension = UUID;

                WomanObservationDataset.component2.babyNumberSection.code = new POCD_MT000007TR01BabyNumberSectionCode();
                WomanObservationDataset.component2.babyNumberSection.code.code = "BEBEKSAYISI";
                WomanObservationDataset.component2.babyNumberSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                WomanObservationDataset.component2.babyNumberSection.code.codeSystemName = "Veri Kýsmý";
                WomanObservationDataset.component2.babyNumberSection.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component2.babyNumberSection.code.displayName = "Bebek Sayýsý Bilgilerinin Olduðu Bölüm";
                WomanObservationDataset.component2.babyNumberSection.text = new StrucDocText();
                WomanObservationDataset.component2.babyNumberSection.text.Text = new string[] { "" };

                if (OnbesKirkDokuzYasKadinIzlem.CanliDoganBebekSayisi.Length > 0)
                {
                    WomanObservationDataset.component2.babyNumberSection.component1 = new POCD_MT000007TR01Component13();
                    WomanObservationDataset.component2.babyNumberSection.component1.liveBirthNumber = new POCD_MT000007TR01LiveBirthNumber();
                    WomanObservationDataset.component2.babyNumberSection.component1.liveBirthNumber.value = new INT();
                    WomanObservationDataset.component2.babyNumberSection.component1.liveBirthNumber.value.value = OnbesKirkDokuzYasKadinIzlem.CanliDoganBebekSayisi;
                }

                if (OnbesKirkDokuzYasKadinIzlem.OluDoganBebekSayisi.Length > 0)
                {
                    WomanObservationDataset.component2.babyNumberSection.component2 = new POCD_MT000007TR01Component14();
                    WomanObservationDataset.component2.babyNumberSection.component2.stillbirthNumber = new POCD_MT000007TR01StillbirthNumber();
                    WomanObservationDataset.component2.babyNumberSection.component2.stillbirthNumber.value = new INT();
                    WomanObservationDataset.component2.babyNumberSection.component2.stillbirthNumber.value.value = OnbesKirkDokuzYasKadinIzlem.OluDoganBebekSayisi;
                }

            }




            if ((OnbesKirkDokuzYasKadinIzlem.IsteyerekDusukSayisi.Length > 0) || (OnbesKirkDokuzYasKadinIzlem.KendiligindenDusukSayisi.Length > 0))
            {
                WomanObservationDataset.component3 = new POCD_MT000007TR01Component15();
                WomanObservationDataset.component3.abortionNumberSection = new POCD_MT000007TR01AbortionNumberSection();
                WomanObservationDataset.component3.abortionNumberSection.id = new POCD_MT000007TR01AbortionNumberSectionID();
                WomanObservationDataset.component3.abortionNumberSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                WomanObservationDataset.component3.abortionNumberSection.id.extension = UUID;

                WomanObservationDataset.component3.abortionNumberSection.code = new POCD_MT000007TR01AbortionNumberSectionCode();
                WomanObservationDataset.component3.abortionNumberSection.code.code = "DUSUKSAYISI";
                WomanObservationDataset.component3.abortionNumberSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                WomanObservationDataset.component3.abortionNumberSection.code.codeSystemName = "Veri Kýsmý";
                WomanObservationDataset.component3.abortionNumberSection.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component3.abortionNumberSection.code.displayName = "Düþük Sayýsý Bilgilerinin Olduðu Bölüm";
                WomanObservationDataset.component3.abortionNumberSection.text = new StrucDocText();
                WomanObservationDataset.component3.abortionNumberSection.text.Text = new string[] { "" };

                if (OnbesKirkDokuzYasKadinIzlem.KendiligindenDusukSayisi.Length > 0)
                {
                    WomanObservationDataset.component3.abortionNumberSection.component1 = new POCD_MT000007TR01Component16();
                    WomanObservationDataset.component3.abortionNumberSection.component1.spontaneousAbortionNumber = new POCD_MT000007TR01SpontaneousAbortionNumber();
                    WomanObservationDataset.component3.abortionNumberSection.component1.spontaneousAbortionNumber.value = new INT();
                    WomanObservationDataset.component3.abortionNumberSection.component1.spontaneousAbortionNumber.value.value = OnbesKirkDokuzYasKadinIzlem.KendiligindenDusukSayisi;
                }

                if (OnbesKirkDokuzYasKadinIzlem.IsteyerekDusukSayisi.Length > 0)
                {

                    WomanObservationDataset.component3.abortionNumberSection.component2 = new POCD_MT000007TR01Component17();
                    WomanObservationDataset.component3.abortionNumberSection.component2.inducedAbortionNumber = new POCD_MT000007TR01InducedAbortionNumber();
                    WomanObservationDataset.component3.abortionNumberSection.component2.inducedAbortionNumber.value = new INT();
                    WomanObservationDataset.component3.abortionNumberSection.component2.inducedAbortionNumber.value.value = OnbesKirkDokuzYasKadinIzlem.IsteyerekDusukSayisi;
                }

            }




            if (OnbesKirkDokuzYasKadinIzlem.DogumSayisi.Length > 0) 
            {
                WomanObservationDataset.component4 = new POCD_MT000007TR01Component18();
                WomanObservationDataset.component4.birthNumberSection = new POCD_MT000007TR01BirthNumberSection();
                WomanObservationDataset.component4.birthNumberSection.id = new POCD_MT000007TR01BirthNumberSectionID();
                WomanObservationDataset.component4.birthNumberSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                WomanObservationDataset.component4.birthNumberSection.id.extension = UUID;

                WomanObservationDataset.component4.birthNumberSection.code = new POCD_MT000007TR01BirthNumberSectionCode();
                WomanObservationDataset.component4.birthNumberSection.code.code = "DOGUMSAYISI";
                WomanObservationDataset.component4.birthNumberSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                WomanObservationDataset.component4.birthNumberSection.code.codeSystemName = "Veri Kýsmý";
                WomanObservationDataset.component4.birthNumberSection.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component4.birthNumberSection.code.displayName = "Doðum Sayýsý Bilgilerinin Olduðu Bölüm";
                WomanObservationDataset.component4.birthNumberSection.text = new StrucDocText();
                WomanObservationDataset.component4.birthNumberSection.text.Text = new string[] { "" };

                WomanObservationDataset.component4.birthNumberSection.component = new POCD_MT000007TR01Component19();
                WomanObservationDataset.component4.birthNumberSection.component.birthNumber = new POCD_MT000007TR01BirthNumber();
                WomanObservationDataset.component4.birthNumberSection.component.birthNumber.value = new INT();
                WomanObservationDataset.component4.birthNumberSection.component.birthNumber.value.value = OnbesKirkDokuzYasKadinIzlem.DogumSayisi;
                
            }


            if (OnbesKirkDokuzYasKadinIzlem.EvlenmeYasi.Length > 0) 
            {
                WomanObservationDataset.component5 = new POCD_MT000007TR01Component20();
                WomanObservationDataset.component5.marriageAgeSection = new POCD_MT000007TR01MarriageAgeSection();
                WomanObservationDataset.component5.marriageAgeSection.id = new POCD_MT000007TR01MarriageAgeSectionID();
                WomanObservationDataset.component5.marriageAgeSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                WomanObservationDataset.component5.marriageAgeSection.id.extension = UUID;

                WomanObservationDataset.component5.marriageAgeSection.code = new POCD_MT000007TR01MarriageAgeSectionCode();
                WomanObservationDataset.component5.marriageAgeSection.code.code = "EVLENMEYASI";
                WomanObservationDataset.component5.marriageAgeSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                WomanObservationDataset.component5.marriageAgeSection.code.codeSystemName = "Veri Kýsmý";
                WomanObservationDataset.component5.marriageAgeSection.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component5.marriageAgeSection.code.displayName = "Evlenme Yaþý Bilgilerinin Olduðu Bölüm";
                WomanObservationDataset.component5.marriageAgeSection.text = new StrucDocText();
                WomanObservationDataset.component5.marriageAgeSection.text.Text = new string[] { "" };

                WomanObservationDataset.component5.marriageAgeSection.component = new POCD_MT000007TR01Component21();
                WomanObservationDataset.component5.marriageAgeSection.component.marriageAge = new POCD_MT000007TR01MarriageAge();
                WomanObservationDataset.component5.marriageAgeSection.component.marriageAge.value = new INT();
                WomanObservationDataset.component5.marriageAgeSection.component.marriageAge.value.value = OnbesKirkDokuzYasKadinIzlem.EvlenmeYasi;
            }




            if (OnbesKirkDokuzYasKadinIzlem.KullanilanAPKorunmaYontemi.Count > 0)
            {
                WomanObservationDataset.component6 = new POCD_MT000007TR01Component3();
                WomanObservationDataset.component6.contraceptiveSection = new POCD_MT000007TR01ContraceptiveSection();
                WomanObservationDataset.component6.contraceptiveSection.id = new POCD_MT000007TR01ContraceptiveSectionID();
                WomanObservationDataset.component6.contraceptiveSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                WomanObservationDataset.component6.contraceptiveSection.id.extension = UUID;

                WomanObservationDataset.component6.contraceptiveSection.code = new POCD_MT000007TR01ContraceptiveSectionCode();
                WomanObservationDataset.component6.contraceptiveSection.code.code = "KORUNMA";
                WomanObservationDataset.component6.contraceptiveSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                WomanObservationDataset.component6.contraceptiveSection.code.codeSystemName = "Veri Kýsmý";
                WomanObservationDataset.component6.contraceptiveSection.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component6.contraceptiveSection.code.displayName = "Gebelikten Korunma Bilgilerinin Olduðu Bölüm";
                WomanObservationDataset.component6.contraceptiveSection.text = new StrucDocText();
                WomanObservationDataset.component6.contraceptiveSection.text.Text = new string[] { "" };

                if (OnbesKirkDokuzYasKadinIzlem.APYontemiKullanmamaNedeni.Code.Length > 0)
                {
                    WomanObservationDataset.component6.contraceptiveSection.component1 = new POCD_MT000007TR01Component4();
                    WomanObservationDataset.component6.contraceptiveSection.component1.notUsageOfContraceptiveReason = new POCD_MT000007TR01NotUsageOfContraceptiveReason();
                    WomanObservationDataset.component6.contraceptiveSection.component1.notUsageOfContraceptiveReason.code = new POCD_MT000007TR01NotUsageOfContraceptiveReasonCode();
                    WomanObservationDataset.component6.contraceptiveSection.component1.notUsageOfContraceptiveReason.code.code = OnbesKirkDokuzYasKadinIzlem.APYontemiKullanmamaNedeni.Code;
                    WomanObservationDataset.component6.contraceptiveSection.component1.notUsageOfContraceptiveReason.code.codeSystem = "2.16.840.1.113883.3.129.1.2.32";
                    WomanObservationDataset.component6.contraceptiveSection.component1.notUsageOfContraceptiveReason.code.codeSystemName = "Kullanmama Nedeni";
                    WomanObservationDataset.component6.contraceptiveSection.component1.notUsageOfContraceptiveReason.code.codeSystemVersion = "1.0";
                    WomanObservationDataset.component6.contraceptiveSection.component1.notUsageOfContraceptiveReason.code.displayName = OnbesKirkDokuzYasKadinIzlem.APYontemiKullanmamaNedeni.DisplayName;
                }


                WomanObservationDataset.component6.contraceptiveSection.component2 = new POCD_MT000007TR01Component5[OnbesKirkDokuzYasKadinIzlem.KullanilanAPKorunmaYontemi.Count];
                for (int i = 0; i < OnbesKirkDokuzYasKadinIzlem.KullanilanAPKorunmaYontemi.Count; i++)
			    {
                    WomanObservationDataset.component6.contraceptiveSection.component2[i] = new POCD_MT000007TR01Component5();
                    WomanObservationDataset.component6.contraceptiveSection.component2[i].contraceptiveMethod = new POCD_MT000007TR01ContraceptiveMethod();
                    WomanObservationDataset.component6.contraceptiveSection.component2[i].contraceptiveMethod.code = new POCD_MT000007TR01ContraceptiveMethodCode();
                    WomanObservationDataset.component6.contraceptiveSection.component2[i].contraceptiveMethod.code.code = OnbesKirkDokuzYasKadinIzlem.KullanilanAPKorunmaYontemi[i].Code;
                    WomanObservationDataset.component6.contraceptiveSection.component2[i].contraceptiveMethod.code.codeSystem = "2.16.840.1.113883.3.129.1.2.31";
                    WomanObservationDataset.component6.contraceptiveSection.component2[i].contraceptiveMethod.code.codeSystemName = "Kullanýlan AP Yönetimi";
                    WomanObservationDataset.component6.contraceptiveSection.component2[i].contraceptiveMethod.code.codeSystemVersion = "1.0";
                    WomanObservationDataset.component6.contraceptiveSection.component2[i].contraceptiveMethod.code.displayName = OnbesKirkDokuzYasKadinIzlem.KullanilanAPKorunmaYontemi[i].DisplayName;
			    }                
            }



            if (OnbesKirkDokuzYasKadinIzlem.Hemoglobin.Code.Length > 0)
            {
                WomanObservationDataset.component7 = new POCD_MT000007TR01Component6();
                WomanObservationDataset.component7.hemoglobinSection = new POCD_MT000007TR01HemoglobinSection();
                WomanObservationDataset.component7.hemoglobinSection.id = new POCD_MT000007TR01HemoglobinSectionID();
                WomanObservationDataset.component7.hemoglobinSection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                WomanObservationDataset.component7.hemoglobinSection.id.extension = UUID;

                WomanObservationDataset.component7.hemoglobinSection.code = new POCD_MT000007TR01HemoglobinSectionCode();
                WomanObservationDataset.component7.hemoglobinSection.code.code = "HEMOGLOBIN";
                WomanObservationDataset.component7.hemoglobinSection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                WomanObservationDataset.component7.hemoglobinSection.code.codeSystemName = "Veri Kýsmý";
                WomanObservationDataset.component7.hemoglobinSection.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component7.hemoglobinSection.code.displayName = "Hemoglobin Bilgilerinin Olduðu Bölüm";
                WomanObservationDataset.component7.hemoglobinSection.text = new StrucDocText();
                WomanObservationDataset.component7.hemoglobinSection.text.Text = new string[] { "" };

                WomanObservationDataset.component7.hemoglobinSection.component = new POCD_MT000007TR01Component7();
                WomanObservationDataset.component7.hemoglobinSection.component.hemoglobin = new POCD_MT000007TR01Hemoglobin();
                WomanObservationDataset.component7.hemoglobinSection.component.hemoglobin.code = new POCD_MT000007TR01HemoglobinCode();
                WomanObservationDataset.component7.hemoglobinSection.component.hemoglobin.code.code = OnbesKirkDokuzYasKadinIzlem.Hemoglobin.Code;
                WomanObservationDataset.component7.hemoglobinSection.component.hemoglobin.code.codeSystem = "2.16.840.1.113883.3.129.1.2.30";
                WomanObservationDataset.component7.hemoglobinSection.component.hemoglobin.code.codeSystemName = "Hemoglobin";
                WomanObservationDataset.component7.hemoglobinSection.component.hemoglobin.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component7.hemoglobinSection.component.hemoglobin.code.displayName = OnbesKirkDokuzYasKadinIzlem.Hemoglobin.DisplayName;

            }





            if (OnbesKirkDokuzYasKadinIzlem.KadinSagligiIslemleri.Count > 0)
            {
                WomanObservationDataset.component8 = new POCD_MT000007TR01Component8();
                WomanObservationDataset.component8.womanHealthActivitySection= new POCD_MT000007TR01WomanHealthActivitySection();
                WomanObservationDataset.component8.womanHealthActivitySection.id = new POCD_MT000007TR01WomanHealthActivitySectionID();
                WomanObservationDataset.component8.womanHealthActivitySection.id.root = "2.16.840.1.113883.3.129.2.1.5";
                WomanObservationDataset.component8.womanHealthActivitySection.id.extension = UUID;

                WomanObservationDataset.component8.womanHealthActivitySection.code = new POCD_MT000007TR01WomanHealthActivitySectionCode();
                WomanObservationDataset.component8.womanHealthActivitySection.code.code = "KADINSAGLIGIISLEMLERI";
                WomanObservationDataset.component8.womanHealthActivitySection.code.codeSystem = "2.16.840.1.113883.3.129.2.2.3";
                WomanObservationDataset.component8.womanHealthActivitySection.code.codeSystemName = "Veri Kýsmý";
                WomanObservationDataset.component8.womanHealthActivitySection.code.codeSystemVersion = "1.0";
                WomanObservationDataset.component8.womanHealthActivitySection.code.displayName = "Kadýn Saðlýðý Ýþlemleri Bilgilerinin Olduðu Bölüm";
                WomanObservationDataset.component8.womanHealthActivitySection.text = new StrucDocText();
                WomanObservationDataset.component8.womanHealthActivitySection.text.Text = new string[] { "" };

                WomanObservationDataset.component8.womanHealthActivitySection.component = new POCD_MT000007TR01Component9[OnbesKirkDokuzYasKadinIzlem.KadinSagligiIslemleri.Count];
                for (int i = 0; i < OnbesKirkDokuzYasKadinIzlem.KadinSagligiIslemleri.Count; i++)
                {
                    WomanObservationDataset.component8.womanHealthActivitySection.component[i] = new POCD_MT000007TR01Component9();
                    WomanObservationDataset.component8.womanHealthActivitySection.component[i].womanHealthActivity = new POCD_MT000007TR01WomanHealthActivity();
                    WomanObservationDataset.component8.womanHealthActivitySection.component[i].womanHealthActivity.code = new POCD_MT000007TR01WomanHealthActivityCode();
                    WomanObservationDataset.component8.womanHealthActivitySection.component[i].womanHealthActivity.code.code = OnbesKirkDokuzYasKadinIzlem.KadinSagligiIslemleri[i].Code;
                    WomanObservationDataset.component8.womanHealthActivitySection.component[i].womanHealthActivity.code.codeSystem = "";
                    WomanObservationDataset.component8.womanHealthActivitySection.component[i].womanHealthActivity.code.codeSystemName = "";
                    WomanObservationDataset.component8.womanHealthActivitySection.component[i].womanHealthActivity.code.codeSystemVersion = "";
                    WomanObservationDataset.component8.womanHealthActivitySection.component[i].womanHealthActivity.code.displayName = OnbesKirkDokuzYasKadinIzlem.KadinSagligiIslemleri[i].DisplayName;

                }
                
            }





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
