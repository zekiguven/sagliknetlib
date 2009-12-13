using System;
using System.Collections.Generic;
using System.Text;
using SaglikNetLib.WSAsi;

namespace SaglikNetLib
{
    public class AsiMesaji : BaseMesaj
    {
        MCCI_AR000001TR_ServiceWse ws;
        MCCI_AR000001TR_Service servis;
        MCCI_IN000001TR01Message mesaj_yeni;
        MCCI_IN000002TR01Message mesaj_cevap;
        MCCI_IN000003TR01Message mesaj_guncelle;
        QUQI_IN000001TR01Message mesaj_sorgu;
        QUQI_IN000002TR01Message mesaj_sorgu_cevap;

        AsiMSVS Asi;

        public AsiMesaji()
        {
            Asi= new AsiMSVS();
            ws = new MCCI_AR000001TR_ServiceWse();
        }

        public void VaccineDatasetDoldur(object o)
        {

            object oId = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.4", UUID);
            object oCode = CreateAndSetCodeProperty(o, "ASI", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Aþý Veriseti");
            object oText = CreateAndSetTextProperty(o, "");
            object oAuthor = CreateAndSetParent(o, "author");
            object oTime = CreateAndSetParent(oAuthor, "time");
            SetProperty(oTime, "value", Asi.IslemZamani.ToString("yyyyMMddhhmm"));
            object oDoctor = CreateAndSetParent(oAuthor, "doctor");
            object oComponent = CreateAndSetParent(o, "component");
                                           

            object oVaccineSection = CreateAndSetParent(oComponent,"vaccineSection");
            object oVaccineSectionId = CreateAndSetIDProperty(oVaccineSection,"","");
            object oVaccineSectionCode = CreateAndSetCodeProperty(oVaccineSection,"","","","","");



           
/*
            
            VaccineDataset.component.vaccineSection.component[] = new POCD_MT000017TR01Component4[15];
            VaccineDataset.component.vaccineSection.component[0] = new POCD_MT000017TR01Component4();
            VaccineDataset.component.vaccineSection.component[0].vaccineInfo = new POCD_MT000017TR01VaccineInfo();

            VaccineDataset.component.vaccineSection.component[0].vaccineInfo.id = new POCD_MT000017TR01VaccineInfoID();
            VaccineDataset.component.vaccineSection.component[0].vaccineInfo.code= new POCD_MT000017TR01VaccineInfoCode();
            */
        }

        public void YeniKayit()
        {
            mesaj_yeni = new MCCI_IN000001TR01Message();
            mesaj_cevap = new MCCI_IN000002TR01Message();

            MesajBilgileriniDoldur(mesaj_yeni);
            mesaj_yeni.controlActEvent.subject = new MCCI_IN000001TR01Subject();

            POCD_MT000017TR01Vaccine Vaccine = new POCD_MT000017TR01Vaccine();
            
            mesaj_yeni.controlActEvent.subject.vaccine =Vaccine;
            DokumanBilgileriniDoldur(Vaccine);

            //ASI Aþý MSVS (Vatandaþ/Yabancý) 
            //ASI-YENIDOGAN Aþý MSVS (Yenidoðan) 

            //SetCodeProperty(Vaccine,""

            Vaccine.code.code = "ASI-YENIDOGAN";
            Vaccine.code.codeSystem = "2.16.840.1.113883.3.129.2.2.1";
            Vaccine.code.codeSystemName = "Döküman Tipi";
            Vaccine.code.codeSystemVersion = "1.0";
            Vaccine.code.displayName = "Aþý MSVS (Yenidoðan)";

            POCD_MT000017TR01RecordTarget RecordTarget = new POCD_MT000017TR01RecordTarget();
            Vaccine.recordTarget = RecordTarget;
            
            Vaccine.component = new POCD_MT000017TR01Component1();
            Vaccine.component.structuredBody = new POCD_MT000017TR01StructuredBody();
            Vaccine.component.structuredBody.component = new POCD_MT000017TR01Component2();
            POCD_MT000017TR01VaccineDataset VaccineDataset = new POCD_MT000017TR01VaccineDataset();
            Vaccine.component.structuredBody.component.vaccineDataset = VaccineDataset;

            VaccineDatasetDoldur(VaccineDataset);




                   

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
