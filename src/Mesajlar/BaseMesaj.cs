using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Web.Services3.Security.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Net;


namespace SaglikNetLib
{
    
    
    public enum MesajTuru
    {
        Yok,
        Yenikayit,
        Guncelleme,
        Iptal,
        Sorgula
    }


    public partial class BaseMesaj 
    {
        public string ServiceURL;
        public string ServiceUsername;
        public string ServicePassword;
        public string ServiceSertifikaYol;

        public string MesajGonderenYazilim;
        public string DokumanGUID;
        public string DokumanYazariTCKimlikNo;
        public string DokumaniOlusturanKurum;
        public DateTime DokumanIslemZamani;
        public MesajTuru SonMesajTuru;

        public VatandasYabanciHastaKayitMSVS VatandasYabanciKayit;
        public YenidoganKayitMSVS YenidoganKayit;                
        public List<TetkikSonucuMSVS> TetkikSonuclari;
        public HastaKabulMSVS HastaKabul;
        public HastaCikisMSVS HastaCikis;
        public List<ReceteMSVS> Recete;
        public MuayeneMSVS Muayene;

        public BaseMesaj()
        {
            MesajGonderenYazilim = "SAGLIKNETLIB";
            DokumanIslemZamani = DateTime.Now;
            SonMesajTuru = MesajTuru.Yok;
        }

        public string UUID
        {
            get { return System.Guid.NewGuid().ToString(); }
        }

        protected void SetProperty(Object o, string Property, Object Value)
        {
            o.GetType().GetProperty(Property).SetValue(o,Value,null);
        }

        protected Object CreateObject(string TypeName)
        {
            Type t = Type.GetType(TypeName);
            ConstructorInfo info = t.GetConstructor(Type.EmptyTypes);
            ObjectCreateMethod inv = new ObjectCreateMethod(info);
            Object o = inv.CreateInstance();

            return o;
        }

        protected Object CreateAndSetParent(Object Parent, string Property)
        {
            Object o = CreateObject(GetPropertyTypeName(Parent, Property));
            SetProperty(Parent, Property, o);
            return o;
        }

        protected void SetIDProperty(Object o, string Root, string Extension)
        {
            SetProperty(o, "root", Root);
            SetProperty(o, "extension", Extension);
        }

        protected Object CreateAndSetIDProperty(Object Parent, string Root, string Extension)
        {
            Object o = CreateAndSetParent(Parent, "id");
            SetIDProperty(o, Root, Extension);
            return o;
        }

        protected void SetCodeProperty(Object o, string Code, string CodeSystem, string CodeSystemName, string CodeSystemVersion, string DisplayName) 
        {            
            SetProperty(o, "code", Code);
            SetProperty(o, "codeSystem", CodeSystem);
            SetProperty(o, "codeSystemName", CodeSystemName);
            SetProperty(o, "codeSystemVersion", CodeSystemVersion);
            SetProperty(o, "displayName", DisplayName);
        }

        protected Object CreateAndSetCodeProperty(Object Parent, string Code, string CodeSystem, string CodeSystemName, string CodeSystemVersion, string DisplayName)
        {
            Object o = CreateAndSetParent(Parent, "code");
            SetCodeProperty(o, Code, CodeSystem, CodeSystemName, CodeSystemVersion, DisplayName);
            
            return o;
        }

        protected void SetEncounterProperty(Object oEncounter,DateTime Baslangic,DateTime Bitis,CodeDisplayName Poliklinik)
        {
            string ClassName = GetClassName(oEncounter);
            string BaseClassName = GetBaseClassName(oEncounter);

            Object oIVL_TS = CreateObject(BaseClassName + ".IVL_TS");
            SetProperty(oEncounter, "effectiveTime", oIVL_TS);

            Object oMuayeneAraligi = Array.CreateInstance(Type.GetType(BaseClassName + ".QTY"), 2);
            SetProperty(oIVL_TS, "Items", oMuayeneAraligi);

            Object oIVXB_TS_low = CreateObject(BaseClassName + ".IVXB_TS");
            ((Array)oMuayeneAraligi).SetValue(oIVXB_TS_low, 0);
            SetProperty(oIVXB_TS_low, "value", Baslangic.ToString("yyyyMMddhhmmss"));

            Object oIVXB_TS_high = CreateObject(BaseClassName + ".IVXB_TS");
            ((Array)oMuayeneAraligi).SetValue(oIVXB_TS_high, 1);
            SetProperty(oIVXB_TS_high, "value", Bitis.ToString("yyyyMMddhhmmss"));

            string oItemsElementNameName = GetPropertyTypeName(oIVL_TS, "ItemsElementName");
            Object oItemsElementNameArray = Array.CreateInstance(Type.GetType(oItemsElementNameName), 2);
            SetProperty(oIVL_TS, "ItemsElementName", oItemsElementNameArray);

            Object oLow = Enum.Parse(Type.GetType(oItemsElementNameName), "low");
            Object oHigh = Enum.Parse(Type.GetType(oItemsElementNameName), "high");

            ((Array)oItemsElementNameArray).SetValue(oLow, 0);
            ((Array)oItemsElementNameArray).SetValue(oHigh, 1);

            Object oLocation = CreateAndSetParent(oEncounter, "location");
            Object oClinic = CreateAndSetParent(oLocation, "clinic");
            Object oClinicCode = CreateAndSetCodeProperty(oClinic, Poliklinik.Code, "2.16.840.1.113883.3.129.1.2.1", "Klinikler", "1.0", Poliklinik.DisplayName);


        }

        // Veri Kýsmý
        protected Object CreateAndSetSection(Object parent, string sectioncode, string sectionname, CodeDisplayName value)
        {
            Object GroupSection = CreateAndSetParent(parent, sectionname);
            Object Id = CreateAndSetIDProperty(parent, "", "");
            Object Code = CreateAndSetCodeProperty(parent, "", "", "", "", "");
            Object Iext = CreateAndSetTextProperty(parent, "");

            Object Component = CreateAndSetParent(GroupSection, "component");
            Object Section = CreateAndSetParent(Component, "");
            CreateAndSetCodeProperty(Section, value.Code, "", "", "", value.DisplayName);

            return GroupSection;
        }
       
        protected string GetPropertyTypeName(Object o, string PropertyName)
        {
            string PropertyTypeName = o.GetType().GetProperty(PropertyName).ToString();

            if (PropertyTypeName.EndsWith("[] " + PropertyName))
                PropertyTypeName = PropertyTypeName.Substring(0, PropertyTypeName.Length - ("[] ".Length + PropertyName.Length));
            else
                PropertyTypeName = PropertyTypeName.Substring(0, PropertyTypeName.Length - (" ".Length + PropertyName.Length));

            return PropertyTypeName;

        }

        /*
        protected void SetSectionProperty()
        {
        }
        */

        protected string GetClassName(Object o)
        {
            // Gelen : SaglikNetLib.WSVatandasYabanciHastaKayit.MCCI_IN000001TR01Message
            // Dönen : SaglikNetLib.WSVatandasYabanciHastaKayit.MCCI_IN000001TR01
            return o.ToString().Substring(0, o.ToString().LastIndexOf('.') + 18);
        }

        protected string GetBaseClassName(Object o)
        {
            // Gelen : SaglikNetLib.WSVatandasYabanciHastaKayit.MCCI_IN000001TR01Message
            // Dönen : SaglikNetLib.WSVatandasYabanciHastaKayit
            return o.ToString().Substring(0, o.ToString().LastIndexOf('.'));
        }

        protected Object CreateAndSetTextProperty(Object parent,string value)
        {
            Object oStrucDocText = CreateObject(GetBaseClassName(parent) + ".StrucDocText");
            SetProperty(parent, "text", oStrucDocText);
            SetProperty(oStrucDocText, "Text", new string[] { value });
            return oStrucDocText;
        }

        protected object CreateAndSetINTValue(object parent, string value)
        {
            object oClass = CreateObject(GetBaseClassName(parent) + ".INT");
            SetProperty(parent, "value", oClass);
            SetProperty(oClass, "value", value);

            return oClass;
        }

        public virtual void YeniKayit() {
        }
        
        public virtual void Guncelle() {
        }
        
        public virtual void Iptal(){
        }
        
        public virtual void Sorgula(){
            SonMesajTuru = MesajTuru.Sorgula;
        }        

        public void Kaydet(string DosyaAdi)
        {
            XmlSerializer serializer;
            FileStream fs;
            TextWriter writer;
            FieldInfo MesajFieldInfo;
            //this.GetType().GetField("mesaj_yeni", BindingFlags.NonPublic | BindingFlags.Instance)
            switch (SonMesajTuru)
            {
                case MesajTuru.Yok:
                    break;

                case MesajTuru.Yenikayit:

                    MesajFieldInfo=this.GetType().GetField("mesaj_yeni", BindingFlags.NonPublic | BindingFlags.Instance);
                    serializer = new XmlSerializer(MesajFieldInfo.FieldType);
                    fs = new FileStream(DosyaAdi, FileMode.OpenOrCreate);
                    writer = new StreamWriter(fs, Encoding.UTF8);
                    serializer.Serialize(writer, MesajFieldInfo.GetValue(this));
                    fs.Flush();
                    fs.Close();
                    break;
                    
                case MesajTuru.Guncelleme:
                    MesajFieldInfo=this.GetType().GetField("mesaj_guncelle", BindingFlags.NonPublic | BindingFlags.Instance);
                    serializer = new XmlSerializer(MesajFieldInfo.FieldType);
                    fs = new FileStream(DosyaAdi, FileMode.OpenOrCreate);
                    writer = new StreamWriter(fs, Encoding.UTF8);
                    serializer.Serialize(writer, MesajFieldInfo.GetValue(this));
                    fs.Flush();
                    fs.Close();
                    break;

                case MesajTuru.Iptal:
                    break;

                case MesajTuru.Sorgula:
                    MesajFieldInfo=this.GetType().GetField("mesaj_sorgu", BindingFlags.NonPublic | BindingFlags.Instance);
                    serializer = new XmlSerializer(MesajFieldInfo.FieldType);
                    fs = new FileStream(DosyaAdi, FileMode.OpenOrCreate);
                    writer = new StreamWriter(fs, Encoding.UTF8);
                    serializer.Serialize(writer, MesajFieldInfo.GetValue(this));
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
            FieldInfo MesajFieldInfo;

            switch (SonMesajTuru)
            {
                case MesajTuru.Yok:
                    break;

                case MesajTuru.Yenikayit:
                    MesajFieldInfo = this.GetType().GetField("mesaj_yeni", BindingFlags.NonPublic | BindingFlags.Instance);
                    serializer = new XmlSerializer(MesajFieldInfo.FieldType);
                    serializer.Serialize(ms, MesajFieldInfo.GetValue(this));
                    ms.Position = 0;
                    sr = new StreamReader(ms);
                    break;

                case MesajTuru.Guncelleme:
                    MesajFieldInfo = this.GetType().GetField("mesaj_guncelle", BindingFlags.NonPublic | BindingFlags.Instance);
                    serializer = new XmlSerializer(MesajFieldInfo.FieldType);
                    serializer.Serialize(ms, MesajFieldInfo.GetValue(this));
                    ms.Position = 0;
                    sr = new StreamReader(ms);

                    break;

                case MesajTuru.Iptal:
                    break;

                case MesajTuru.Sorgula:
                    MesajFieldInfo = this.GetType().GetField("mesaj_sorgu", BindingFlags.NonPublic | BindingFlags.Instance);
                    serializer = new XmlSerializer(MesajFieldInfo.FieldType);
                    serializer.Serialize(ms, MesajFieldInfo.GetValue(this));
                    ms.Position = 0;
                    sr = new StreamReader(ms);

                    break;

                default:
                    break;
            }

            return sr.ReadToEnd();
        }
        
        public string Gonder()
        {
            FieldInfo WSFieldInfo;
            FieldInfo GidenMesajFieldInfo;
            FieldInfo GelenMesajFieldInfo;
            MethodInfo WSMethodInfo;
            Object Retval;

            WSFieldInfo = this.GetType().GetField("ws", BindingFlags.NonPublic | BindingFlags.Instance);
            Microsoft.Web.Services3.WebServicesClientProtocol ws = (Microsoft.Web.Services3.WebServicesClientProtocol)WSFieldInfo.GetValue(this);

            UsernameToken token = new UsernameToken(ServiceUsername, ServicePassword, PasswordOption.SendPlainText);
            
            ws.Url = ServiceURL;
            ws.RequestSoapContext.Security.Tokens.Add(token);
            ws.RequestSoapContext.Security.MustUnderstand = false;

            //X509Certificate X509 = new X509Certificate(ServiceSertifikaYol);
            //ws.ClientCertificates.Add(X509);
            //ServicePointManager.CertificatePolicy = new MyPolicy();

            string acknowledgementcode = null;

            switch (SonMesajTuru)
            {

                case MesajTuru.Yok:
                    break;

                case MesajTuru.Yenikayit:
                    WSMethodInfo = ws.GetType().GetMethod("MCCI_AR000001TR_MCCI_IN000001TR");
                    GidenMesajFieldInfo = this.GetType().GetField("mesaj_yeni", BindingFlags.NonPublic | BindingFlags.Instance);
                    //WSFieldInfo.GetValue(this)
                    Retval = WSMethodInfo.Invoke(ws, new object[] { GidenMesajFieldInfo.GetValue(this) });

                    GelenMesajFieldInfo = this.GetType().GetField("mesaj_cevap", BindingFlags.NonPublic | BindingFlags.Instance);
                    GelenMesajFieldInfo.SetValue(this, Retval);
                    Object oAcknowledgement = 
                    acknowledgementcode = Retval.GetType().GetProperty("acknowledgement").GetType().GetProperty("typeCode").GetType().GetProperty("code").GetValue(Retval, null).ToString();

                    
                    //mesaj_cevap = ws.GetType().MCCI_AR000001TR_MCCI_IN000001TR(mesaj_yeni);
                    
                    //acknowledgementcode = mesaj_cevap.acknowledgement.typeCode.code;
                    break;
                    /*
                case MesajTuru.Guncelleme:
                    mesaj_cevap = ws.MCCI_AR000001TR_MCCI_IN000003TR(mesaj_guncelle);
                    acknowledgementcode = mesaj_cevap.acknowledgement.typeCode.code;
                    break;
                case MesajTuru.Iptal:

                    break;
                case MesajTuru.Sorgulama:
                    mesaj_sorgu_cevap = ws.MCCI_AR000001TR_QUQI_IN000001TR(mesaj_sorgu);
                    acknowledgementcode = mesaj_sorgu_cevap.acknowledgement.typeCode.code;
                    break;
                     * */
 
                default:
                    break;
            }

            return acknowledgementcode;
        }




        protected void MesajBilgileriniDoldur(Object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);

            Object oMessageId = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.2", DokumanGUID);
            Object oCreationTime = CreateAndSetParent(o, "creationTime");
            SetProperty(oCreationTime, "value", DokumanIslemZamani.ToString("yyyyMMddhhmmss"));

            Object oResponseModeCode = CreateAndSetParent(o, "responseModeCode");

            if (ClassName.EndsWith("QUQI_IN000001TR01")) 
                SetProperty(oResponseModeCode, "code", "I");                
            else
                SetProperty(oResponseModeCode, "code", "Q");

            Object oInteractionId = CreateAndSetParent(o, "interactionId");
            SetIDProperty(oInteractionId, "2.16.840.1.113883.3.129.2.1.1", ClassName.Substring(ClassName.LastIndexOf(".") + 1, 17));
            
            Object oProcessingCode = CreateAndSetParent(o, "processingCode");
            SetProperty(oProcessingCode, "code", "P");

            Object oProcessingModeCode = CreateAndSetParent(o, "processingModeCode");
            SetProperty(oProcessingModeCode, "code", "T");

            Object oAcceptAckCode = CreateAndSetParent(o, "acceptAckCode");
            SetProperty(oAcceptAckCode, "code", "AL");
            
            //(+)receiver  
            Object oReceiver = CreateAndSetParent(o, "receiver");            
            Object oReceiverDevice = CreateAndSetParent(oReceiver, "device");            
            Object oReceiverDeviceId = CreateAndSetIDProperty(oReceiverDevice, "2.16.840.1.113883.3.129.1.1.5", "USBS");            

            //(+)sender 
            Object oSender = CreateAndSetParent(o, "sender");            
            Object oSenderDevice = CreateAndSetParent(oSender, "device");           
            Object oSenderDeviceId = CreateAndSetIDProperty(oSenderDevice, "2.16.840.1.113883.3.129.1.1.5", MesajGonderenYazilim);            

            //(+)controlActEvent 
            Object oControlActEvent = CreateAndSetParent(o, "controlActEvent");           
            //Object oSubject = CreateAndSetParent(oControlActEvent, "subject");            
        }


        protected void DokumanBilgileriniDoldur(Object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);

            Object oId = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.2.1.3", DokumanGUID);

            Object oCode = CreateAndSetCodeProperty(o, "Burasý", "Mesaj", "Ýçinde", "doldurulacak", " Burasý mesaj içinde doldurulacak");

            Object oEffectiveTime = CreateAndSetParent(o, "effectiveTime");
            SetProperty(oEffectiveTime, "value", DokumanIslemZamani.ToString("yyyyMMddhhmmss"));

            Object oConfidentialityCode = CreateAndSetParent(o,"confidentialityCode");
            SetCodeProperty(oConfidentialityCode, "1", "2.16.840.1.113883.3.129.1.2.77", "Gizlilik", "1.0", "Normal");

            Object oLanguageCode = CreateAndSetParent(o, "languageCode");
            SetProperty(oLanguageCode, "code", "tr-TR");

            Object oVersionNumber = CreateAndSetParent(o, "versionNumber");
            SetProperty(oVersionNumber, "value", "1");

            //(+) recordTarget
            // Bu kýsým mesaj içerisinde hasta türüne göre atanacak.

            //(+) author
            Object oAuthor = CreateAndSetParent(o, "author");
            Object oAuthorTime = CreateAndSetParent(oAuthor, "time");
            SetProperty(oAuthorTime, "value", DokumanIslemZamani.ToString("yyyyMMddhhmmss"));

            Object oAssignedAuthor = CreateAndSetParent(oAuthor, "assignedAuthor");
            Object oAssignedAuthorId = CreateAndSetIDProperty(oAssignedAuthor, "2.16.840.1.113883.3.129.1.1.1", DokumanYazariTCKimlikNo);


            //(+) custodian

            Object oCustodian = CreateAndSetParent(o, "custodian");
            Object oassignedCustodian = CreateAndSetParent(oCustodian, "assignedCustodian");
            Object oHealthcareOrganization = CreateAndSetParent(oassignedCustodian, "representedHealthcareOrganization");
            Object oHealthcareOrganizationId = CreateAndSetIDProperty(oHealthcareOrganization, "2.16.840.1.113883.3.129.1.1.6", DokumaniOlusturanKurum);

            //(+) primaryInformationRecipient

            Object oPrimaryInformationRecipient = CreateAndSetParent(o, "primaryInformationRecipient");
            Object oRecipient = CreateAndSetParent(oPrimaryInformationRecipient, "recipient");
            Object oRepresentedMinisteryOfHealth = CreateAndSetParent(oRecipient, "representedMinisteryOfHealth");
            Object oRepresentedMinisteryOfHealthId = CreateAndSetIDProperty(oRepresentedMinisteryOfHealth, "2.16.840.1.113883.3.129.1.1.6", "5881");

        }


        protected void PatientRoleDoldur(Object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);

            Object oId = CreateAndSetIDProperty(o, "2.16.840.1.113883.3.129.1.1.1", VatandasYabanciKayit.HastaTCKimlikNumarasi);

            Object oPatient = CreateAndSetParent(o, "patient");
            Object oPatientName = CreateAndSetParent(oPatient, "name");

            Type tAdSoyad = Type.GetType(BaseClassName + ".ENXP");
            Object oAdSoyad = Array.CreateInstance(tAdSoyad, 2);

            SetProperty(oPatientName, "Items", oAdSoyad);
            // Adý
            Object oAdi = CreateObject(BaseClassName + ".engiven");
            SetProperty(oAdi, "Text", new string[] { VatandasYabanciKayit.Ad});

            // Soyadý
            Object oSoyadi = CreateObject(BaseClassName + ".enfamily");
            SetProperty(oSoyadi, "Text", new string[] { VatandasYabanciKayit.Soyad });

            ((Array)oAdSoyad).SetValue(oAdi, 0);
            ((Array)oAdSoyad).SetValue(oSoyadi, 1);

            Object oAdministrativeGenderCode = CreateAndSetParent(oPatient, "administrativeGenderCode");
            SetCodeProperty(oAdministrativeGenderCode, VatandasYabanciKayit.Cinsiyet.Code, "2.16.840.1.113883.3.129.1.2.21", "Cinsiyet", "1.0", VatandasYabanciKayit.Cinsiyet.DisplayName);

            Object oBirthTime = CreateAndSetParent(oPatient, "birthTime");
            SetProperty(oBirthTime, "value", VatandasYabanciKayit.DogumTarihi.ToString("yyyyMMdd"));

            Object oRaceCode = CreateAndSetParent(oPatient, "raceCode");
            SetCodeProperty(oRaceCode, VatandasYabanciKayit.Uyruk.Code, "2.16.840.1.113883.3.129.1.2.52", "Uyruk", "1.0", VatandasYabanciKayit.Uyruk.DisplayName);
        }

        
        protected void BabyPatientRoleDoldur(Object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);
            
            Object oBaby = CreateAndSetParent(o, "patientBaby");
            Object oAdministrativeGenderCode = CreateAndSetParent(oBaby, "administrativeGenderCode");
            SetCodeProperty(oAdministrativeGenderCode, YenidoganKayit.Cinsiyet.Code, "2.16.840.1.113883.3.129.1.2.21", "Cinsiyet", "1.0", YenidoganKayit.Cinsiyet.DisplayName);

            Object oBirthTime = CreateAndSetParent(oBaby, "birthTime");
            SetProperty(oBirthTime, "value", YenidoganKayit.DogumTarihi.ToString("yyyyMMdd"));

            Object oGuardian = CreateAndSetParent(oBaby, "guardian");
            object oGuardianCode = CreateAndSetCodeProperty(oGuardian, "MTH", "2.16.840.1.113883.5.111", "RoleCode", "1.0", "Mother");
            Object oGuardianMother = CreateAndSetParent(oGuardian, "guardianMother");
            Object oGuardianMotherId = CreateAndSetIDProperty(oGuardianMother, " 2.16.840.1.113883.3.129.1.1.1", YenidoganKayit.AnneTCKimlikNo);


            Object oMultipleBirthOrderNumber = CreateAndSetParent(oBaby, "multipleBirthOrderNumber");
            SetProperty(oMultipleBirthOrderNumber, "value", YenidoganKayit.DogumSirasi);

        }

        /// <summary>
        /// Tetkik Sonuçlarý doldurulur.
        /// </summary>
        /// <param name="o">Tetkik sonuçlarýnýn atanacaðý array nesnesi(oluþturulmadan)</param>

        protected void TestResultDatasetDoldur(Object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);

            if (TetkikSonuclari.Count == 0) return;

            //Object oa = Array.CreateInstance(o.GetType(), TetkikSonuclari.Count);

            for (int i = 0; i < TetkikSonuclari.Count; i++)
            {
                
                Object o1 = CreateObject(o.GetType().ToString().Substring(0, o.GetType().ToString().Length - 2));
                ((Array)o).SetValue(o1,i);

                Object oTestResultDataset = CreateAndSetParent(o1, "testResultDataset");
                Object oTestResultDatasetId = CreateAndSetIDProperty(oTestResultDataset, "2.16.840.1.113883.3.129.2.1.4", UUID);
                Object oTestResultDatasetCode = CreateAndSetCodeProperty(oTestResultDataset, "TETKIKSONUCU", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Tetkik Sonucu Veriseti");
                Object oStrucDocText = CreateAndSetTextProperty(oTestResultDataset, "");

                Object oAuthor = CreateAndSetParent(oTestResultDataset, "author");
                Object oTestDoctor = CreateAndSetParent(oAuthor, "testDoctor");               
                Object oTestDoctorID = CreateAndSetIDProperty(oTestDoctor,"2.16.840.1.113883.3.129.1.1.1",TetkikSonuclari[i].HekimKimlikNumarasi);

                Object oTestResultDatasetComponent = CreateAndSetParent(oTestResultDataset, "component");
                Object oTestResultSection = CreateAndSetParent(oTestResultDatasetComponent, "testResultSection");

                Object oTestResultSectionID = CreateAndSetIDProperty(oTestResultSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
                Object oTestResultSectionCode = CreateAndSetCodeProperty(oTestResultSection, "TETKIKSONUC", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Tetkik Sonuç Verisinin Olduðu Bölüm");
                Object oTestResultSectionText = CreateAndSetTextProperty(oTestResultSection, "");
                                
                Object oTestResultSectionComponent = CreateAndSetParent(oTestResultSection, "component");
                Object oTestResultOrganizer = CreateAndSetParent(oTestResultSectionComponent, "testResultOrganizer");

                Object oTestResultOrganizerStatusCode = CreateAndSetParent(oTestResultOrganizer, "statusCode");                
                SetProperty(oTestResultOrganizerStatusCode, "code", "completed");

                Object oPerformer = CreateAndSetParent(oTestResultOrganizer, "performer");
                Object oStudyOrganization = CreateAndSetParent(oPerformer, "studyOrganization");
                Object oStudyOrganizationID = CreateAndSetIDProperty(oStudyOrganization, "2.16.840.1.113883.3.129.1.1.6", TetkikSonuclari[i].TetkikYapanKurum);

                
                string TestResultOrganizerComponentTypeName = GetPropertyTypeName(oTestResultOrganizer, "component");
                Object oTestResultOrganizerComponentArray = Array.CreateInstance( Type.GetType(TestResultOrganizerComponentTypeName), 1);
                SetProperty(oTestResultOrganizer, "component", oTestResultOrganizerComponentArray);

                Object oTestResultOrganizerComponent = CreateObject(TestResultOrganizerComponentTypeName);
                
                ((Array)oTestResultOrganizerComponentArray).SetValue(oTestResultOrganizerComponent, 0);
                Object oTestResult = CreateObject(ClassName + "TestResult");
                SetProperty(oTestResultOrganizerComponent, "testResult", oTestResult);

                Object oTestResultCode = CreateAndSetCodeProperty(oTestResult, TetkikSonuclari[i].Tetkik.Code, "2.16.840.1.113883.3.129.1.2.2", "SUT", "1.0", TetkikSonuclari[i].Tetkik.DisplayName);
                Object oTestResultActivityTime = CreateAndSetParent(oTestResult, "activityTime");                
                SetProperty(oTestResultActivityTime, "value", TetkikSonuclari[i].TetkikSonucTarihi.ToString("yyyyMMdd"));
            }
        }

        
        // Çýkýþ 
        protected void DischargeDatasetDoldur(Object o)
        {
            
            if (HastaKabul.SevkTanisi.Count == 0) return;

            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);
 
            Object oDischargeDatasetID = CreateAndSetIDProperty(o,"2.16.840.1.113883.3.129.2.1.4", UUID);            
            Object oDischargeDatasetCode = CreateAndSetCodeProperty(o, "CIKIS", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Çýkýþ Veriseti");                      

            Object oDischargeDatasetText = CreateObject(BaseClassName + ".StrucDocText");
            SetProperty(o, "text", oDischargeDatasetText);
            SetProperty(oDischargeDatasetText, "Text", new string[] { "" });

            Object oDischargeDatasetComponent1 = CreateAndSetParent(o, "component1");
            Object oDischargeDiagnosisSection = CreateAndSetParent(oDischargeDatasetComponent1, "dischargeDiagnosisSection");

            Object oDischargeDiagnosisSectionID = CreateAndSetIDProperty(oDischargeDiagnosisSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oDischargeDiagnosisSectionCode = CreateAndSetCodeProperty(oDischargeDiagnosisSection,"TANI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Taný Verisinin Olduðu Bölüm");
            Object oDischargeDiagnosisSectionText = CreateAndSetTextProperty(oDischargeDiagnosisSection, "");

            string oDischargeDiagnosisSectionComponentName = GetPropertyTypeName(oDischargeDiagnosisSection, "component");
            Object oDischargeDiagnosisSectionComponentArray = Array.CreateInstance(Type.GetType(oDischargeDiagnosisSectionComponentName), HastaKabul.SevkTanisi.Count);
            SetProperty(oDischargeDiagnosisSection, "component", oDischargeDiagnosisSectionComponentArray);


            for (int i = 0; i < HastaKabul.SevkTanisi.Count; i++)
            {
                Object oDischargeDiagnosisSectionComponent = CreateObject(oDischargeDiagnosisSectionComponentName);
                ((Array)oDischargeDiagnosisSectionComponentArray).SetValue(oDischargeDiagnosisSectionComponent, i);

                Object oDischargeDiagnosis = CreateAndSetParent(oDischargeDiagnosisSectionComponent, "dischargeDiagnosis");
                Object oDischargeDiagnosisCode = CreateAndSetCodeProperty(oDischargeDiagnosis, "SEVKTANISI", "2.16.840.1.113883.3.129.2.2.6", "Taný Tipi", "1.0", "Sevk Tanýsý");

                Object oDischargeDiagnosisValue = CreateAndSetParent(oDischargeDiagnosis, "value");                               
                SetCodeProperty(oDischargeDiagnosisValue, HastaKabul.SevkTanisi[i].Code, "2.16.840.1.113883.6.3", "ICD-10", "1.0", HastaKabul.SevkTanisi[i].DisplayName);

            }


            Object oDischargeDatasetComponent2 = CreateAndSetParent(o, "component2");
            Object oDischargeSection = CreateAndSetParent(oDischargeDatasetComponent2, "dischargeSection");
            Object oDischargeSectionID = CreateAndSetIDProperty(oDischargeSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oDischargeSectionCode = CreateAndSetCodeProperty(oDischargeSection,"CIKIS", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Çýkýþ Verisinin Olduðu Bölüm");
            Object oDischargeSectionText = CreateAndSetTextProperty(oDischargeSection, "");

            Object oDischargeSectionComponent = CreateAndSetParent(oDischargeSection, "component");
            Object oDischarge = CreateAndSetParent(oDischargeSectionComponent, "discharge");
            Object oDischargeCode = CreateAndSetCodeProperty(oDischarge, HastaCikis.CikisSekli.Code, "2.16.840.1.113883.3.129.1.2.9", "Çýkýþ Þekli", "1.0", HastaCikis.CikisSekli.DisplayName);

            Object oDischargeEffectiveTime = CreateAndSetParent(oDischarge, "effectiveTime");            
            SetProperty(oDischargeEffectiveTime, "value", HastaCikis.CikisZamani.ToString("yyyyMMdd"));

            Object oDestination = CreateAndSetParent(oDischarge, "destination"); 
            Object oReferralToClinic = CreateAndSetParent(oDestination, "referralToClinic");
            Object oReferralToClinicCode = CreateAndSetCodeProperty(oReferralToClinic, HastaCikis.SevkEdilenPoliklinik.Code, "2.16.840.1.113883.3.129.1.2.1", "Klinikler", "1.0", HastaCikis.SevkEdilenPoliklinik.DisplayName);                                     

        }


        protected void PrescriptionDatasetDoldur(Object o)
        {
            if (Recete.Count == 0) return;

            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);
            
            Object o1;

            for (int i = 0; i < ((Array)o).Length; i++)
            {
                //ToDo: return yerine breakgibi birþey
                if (Recete[i].Ilac.Count == 0) return; 

                o1 = CreateObject(o.GetType().ToString().Substring(0, o.GetType().ToString().Length - 2));
                ((Array)o).SetValue(o1,i);

                Object oPrescriptionDataset = CreateAndSetParent(o1, "prescriptionDataset");
                Object oPrescriptionDatasetId = CreateAndSetIDProperty(oPrescriptionDataset, "2.16.840.1.113883.3.129.2.1.4", UUID);
                Object oPrescriptionDatasetCode = CreateAndSetCodeProperty(oPrescriptionDataset, "RECETE", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Reçete Veriseti");
                
                Object oPrescriptionDatasetText = CreateObject(BaseClassName + ".StrucDocText");
                SetProperty(oPrescriptionDataset, "text", oPrescriptionDatasetText);
                SetProperty(oPrescriptionDatasetText, "Text", new string[] { "" });

                Object oAuthor = CreateAndSetParent(oPrescriptionDataset, "author");
                Object oAssignedDoctor = CreateAndSetParent(oAuthor, "assignedDoctor");
                
                Object AssignedDoctorIDArray = Array.CreateInstance(Type.GetType(GetPropertyTypeName(oAssignedDoctor, "id")), 2);
                SetProperty(oAssignedDoctor, "id", AssignedDoctorIDArray);

                Object AssignedDoctorID1 = CreateObject(GetPropertyTypeName(oAssignedDoctor, "id"));
                ((Array)AssignedDoctorIDArray).SetValue(AssignedDoctorID1, 0);
                SetProperty(AssignedDoctorID1, "root", "2.16.840.1.113883.3.129.1.1.1");
                SetProperty(AssignedDoctorID1, "extension", Recete[i].HekimKimlikNumarasi);

                Object AssignedDoctorID2 = CreateObject(GetPropertyTypeName(oAssignedDoctor, "id"));
                ((Array)AssignedDoctorIDArray).SetValue(AssignedDoctorID2, 1);
                SetProperty(AssignedDoctorID2, "root", "2.16.840.1.113883.3.129.1.1.2");
                SetProperty(AssignedDoctorID2, "extension", Recete[i].DiplomaTescilNumarasi);

                #region component1
                Object oPrescriptionDatasetComponent1 = CreateAndSetParent(oPrescriptionDataset, "component1");
                Object oMedicationSection = CreateAndSetParent(oPrescriptionDatasetComponent1, "medicationSection");                
                Object oMedicationSectionID = CreateAndSetIDProperty(oMedicationSection, "2.16.840.1.113883.3.129.2.1.5",UUID);
                Object oMedicationSectionCode = CreateAndSetCodeProperty(oMedicationSection, "ILAC", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Ýlaç Verisinin Olduðu Bölüm");
                Object oMedicationSectionText = CreateAndSetTextProperty(oMedicationSection, "");

                string oMedicationSectionComponentName = GetPropertyTypeName(oMedicationSection, "component");
                Object oMedicationSectionComponentArray = Array.CreateInstance(Type.GetType(oMedicationSectionComponentName), Recete[i].Ilac.Count);
                SetProperty(oMedicationSection, "component", oMedicationSectionComponentArray);
                Object oMedicationSectionComponent; 
                
                for (int j = 0; j < Recete[i].Ilac.Count; j++)
                {
                    oMedicationSectionComponent = CreateObject(oMedicationSectionComponentName);
                    ((Array)oMedicationSectionComponentArray).SetValue(oMedicationSectionComponent, j);

                    Object oSubstanceAdministration = CreateAndSetParent(oMedicationSectionComponent, "substanceAdministration");
                    Object oSubstanceAdministrationEffectiveTime = CreateAndSetParent(oSubstanceAdministration, "effectiveTime");
                    
                    Object oPeriod = CreateObject(BaseClassName + ".PQ");
                    SetProperty(oSubstanceAdministrationEffectiveTime, "period", oPeriod);
                    SetProperty(oPeriod, "value", Recete[i].Ilac[j].KullanimPeriyodu);
                    SetProperty(oPeriod, "unit", Recete[i].Ilac[j].KullanimPeriyoduBirimi);                    

                    Object oSubstanceAdministrationRouteCode =  CreateAndSetParent(  oSubstanceAdministration, "routeCode");                    
                    SetCodeProperty(oSubstanceAdministrationRouteCode, Recete[i].Ilac[j].KullanimSekli.Code, "2.16.840.1.113883.3.129.1.2.47", "Ýlaç Kullaným Þekli", "1.0", Recete[i].Ilac[j].KullanimSekli.DisplayName);

                    Object oDoseQuantity = CreateObject(BaseClassName + ".REAL");
                    SetProperty(oSubstanceAdministration, "doseQuantity", oDoseQuantity);
                    SetProperty(oDoseQuantity, "value", Recete[i].Ilac[j].KullanimAdedi);

                    Object oConsumable = CreateAndSetParent(oSubstanceAdministration, "consumable");
                    Object oManufacturedProduct = CreateAndSetParent(oConsumable, "manufacturedProduct");
                    Object oManufacturedMaterial = CreateAndSetParent(oManufacturedProduct, "manufacturedMaterial");                   
                    Object oManufacturedMaterialCode = CreateAndSetCodeProperty(oManufacturedMaterial,Recete[i].Ilac[j].Ilac.Code, "2.16.840.1.113883.3.129.1.2.3", "Ýlaçlar", "1.0", Recete[i].Ilac[j].Ilac.DisplayName);
                    Object oSubstanceAdministrationComponent = CreateAndSetParent(oSubstanceAdministration, "component");
                    Object oSuppy = CreateAndSetParent(oSubstanceAdministrationComponent, "supply");
                    Object oQuantity = CreateObject(BaseClassName + ".INT");

                    SetProperty(oSuppy, "quantity", oQuantity);
                    SetProperty(oQuantity,"value",Recete[i].Ilac[j].Adedi);
                }

                #endregion

                #region component2
                
                Object oPrescriptionDatasetComponent2 = CreateAndSetParent(oPrescriptionDataset, "component2");
                Object oPrescriptionHeaderSection = CreateAndSetParent(oPrescriptionDatasetComponent2, "prescriptionHeaderSection");
                Object oPrescriptionHeaderSectionID = CreateAndSetIDProperty(oPrescriptionHeaderSection, "2.16.840.1.113883.3.129.2.1.5",UUID);
                Object oPrescriptionHeaderSectionCode = CreateAndSetCodeProperty(oPrescriptionHeaderSection, "RECETEBASLIK", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Reçete Baþlýk Bilgisinin Olduðu Bölüm");
                
                Object oPrescriptionHeaderSectionText = CreateObject(BaseClassName + ".StrucDocText");
                SetProperty(oPrescriptionHeaderSection, "text", oPrescriptionHeaderSectionText);
                SetProperty(oPrescriptionHeaderSectionText, "Text", new string[] { "" });

                // Reçete Türü
                Object oPrescriptionHeaderSectionComponent = CreateAndSetParent(oPrescriptionHeaderSection, "component");
                Object oPrescriptionHeader = CreateAndSetParent(oPrescriptionHeaderSectionComponent, "prescriptionHeader");                
                Object oPrescriptionHeaderCode = CreateAndSetCodeProperty(oPrescriptionHeader, Recete[i].ReceteTuru.Code, "2.16.840.1.113883.3.129.1.2.48", "Reçete Türü", "1.0", Recete[i].ReceteTuru.DisplayName);
                Object oPrescriptionHeaderEffectiveTime = CreateAndSetParent(oPrescriptionHeader, "effectiveTime");                
                SetProperty(oPrescriptionHeaderEffectiveTime, "value", Recete[i].ReceteTarihi.ToString("yyyyMMdd"));
                
                // Protokol No                
                Object oPrescriptionHeaderComponent1 = CreateAndSetParent(oPrescriptionHeader, "component1");  
                Object oProtocolNo = CreateAndSetParent(oPrescriptionHeaderComponent1,"protocolNo");
                Object oProtocolNoID = CreateAndSetIDProperty(oProtocolNo,"2.16.840.1.113883.3.129.1.1.4",Recete[i].ProtokolNumarasi);
               
                // SGK Karne No
                Object oPrescriptionHeaderComponent2 = CreateAndSetParent(oPrescriptionHeader, "component2");
                Object oSGKRationBook = CreateAndSetParent(oPrescriptionHeaderComponent2, "sGKRationBook");
                Object oSGKRationBookID = CreateAndSetIDProperty(oSGKRationBook, "2.16.840.1.113883.3.129.1.1.3",Recete[i].SGKKarneNumarasi);

                #endregion

                #region component3
                
                // Sosyal güvence durumu bölümünü belirtir
                
                Object oPrescriptionDatasetComponent3 = CreateAndSetParent(oPrescriptionDataset, "component3");                                
                Object oGuarantorSection = CreateAndSetParent(oPrescriptionDatasetComponent3,"guarantorSection");
                

                Object oGuarantorSectionID = CreateAndSetIDProperty(oGuarantorSection,"2.16.840.1.113883.3.129.2.1.5",UUID);
                Object oGuarantorSectionCode = CreateAndSetCodeProperty(oGuarantorSection, "SOSYALGUVENCEDURUMU", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Sosyal Güvence Durumu Bilgilerinin Olduðu Bölüm");
                Object oGuarantorSectionText = CreateAndSetTextProperty(oGuarantorSection, "");


                Object oGuarantorSectionComponent = CreateAndSetParent(oGuarantorSection, "component");                
                Object oGuarantor = CreateAndSetParent(oGuarantorSectionComponent, "guarantor");                
                Object oGuarantorCode = CreateAndSetCodeProperty(oGuarantor,Recete[i].SosyalGuvenceDurumu.Code, "2.16.840.1.113883.3.129.1.2.11", "Sosyal Güvenlik", "1.0", Recete[i].SosyalGuvenceDurumu.DisplayName);               

                #endregion

                #region component4
                // Taný bilgisi
                Object oPrescriptionDatasetComponent4 = CreateAndSetParent(oPrescriptionDataset, "component4");                
                Object oPresDiagnosisSection = CreateAndSetParent(oPrescriptionDatasetComponent4, "presDiagnosisSection");
                Object oPresDiagnosisSectionID = CreateAndSetIDProperty(oPresDiagnosisSection, "2.16.840.1.113883.3.129.2.1.5",UUID);                
                Object oPresDiagnosisSectionCode = CreateAndSetCodeProperty(oPresDiagnosisSection, "TANI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Taný Verisinin Olduðu Bölüm");
                Object oPresDiagnosisSectionText = CreateAndSetTextProperty(oPresDiagnosisSection, "");


                string oPresDiagnosisSectionComponentName; 
                Object oPresDiagnosisSectionComponentArray; 
                Object oPresDiagnosisSectionComponent;

                oPresDiagnosisSectionComponentName = GetPropertyTypeName(oPresDiagnosisSection, "component");
                oPresDiagnosisSectionComponentArray = Array.CreateInstance(Type.GetType(oPresDiagnosisSectionComponentName), Recete[i].EkTani.Count+1);
                SetProperty(oPresDiagnosisSection, "component", oPresDiagnosisSectionComponentArray);

                
                oPresDiagnosisSectionComponent = CreateObject(oPresDiagnosisSectionComponentName);
                ((Array)oPresDiagnosisSectionComponentArray).SetValue(oPresDiagnosisSectionComponent, 0);

                
                Object oPresDiagnosis = CreateAndSetParent( oPresDiagnosisSectionComponent, "presDiagnosis");
                
                Object oPresDiagnosisCode = CreateAndSetCodeProperty(oPresDiagnosis,"ANATANI", "2.16.840.1.113883.3.129.2.2.6", "Taný Tipi", "1.0", "Ana Taný");               
                Object oPresDiagnosisValue = CreateAndSetParent(oPresDiagnosis, "value");                
                SetCodeProperty(oPresDiagnosisValue, Recete[i].AnaTani.Code, "2.16.840.1.113883.6.3", "ICD-10", "1.0", Recete[i].AnaTani.DisplayName);

                if (Recete[i].EkTani.Count > 0)
                {
                    for (int k = 0; k < Recete[i].EkTani.Count; k++)
                    {
                        oPresDiagnosisSectionComponent = CreateObject(oPresDiagnosisSectionComponentName);
                        ((Array)oPresDiagnosisSectionComponentArray).SetValue(oPresDiagnosisSectionComponent, k+1);

                        oPresDiagnosis = CreateAndSetParent(oPresDiagnosisSectionComponent, "presDiagnosis");                        
                        oPresDiagnosisCode = CreateAndSetCodeProperty(oPresDiagnosis, "EKTANI", "2.16.840.1.113883.3.129.2.2.6", "Taný Tipi", "1.0", "Ek Taný");
                        oPresDiagnosisValue = CreateAndSetParent(oPresDiagnosis, "value");                        
                        SetCodeProperty(oPresDiagnosisValue, Recete[i].EkTani[k].Code, "2.16.840.1.113883.6.3", "ICD-10", "1.0", Recete[i].EkTani[k].DisplayName);
                    }
                }


                #endregion

            }
        }
        
        
        // Hasta Kabul
        protected void ReceptionDatasetDoldur(Object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);

            Object oReceptionDatasetID = CreateAndSetIDProperty(o,"2.16.840.1.113883.3.129.2.1.4", UUID);
            Object oReceptionDatasetCode = CreateAndSetCodeProperty(o, "KABUL", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Kabul Veriseti");
            Object oReceptionDatasetText = CreateAndSetTextProperty(o, "");

            #region component1

            Object oReceptionDatasetComponent1 = CreateAndSetParent(o, "component1");
            Object oSocialSecurityFollowNumberSection = CreateAndSetParent(oReceptionDatasetComponent1, "socialSecurityFollowNumberSection");
            Object oSocialSecurityFollowNumberSectionID = CreateAndSetIDProperty(oSocialSecurityFollowNumberSection, "2.16.840.1.113883.3.129.2.1.5", UUID);            
            Object oSocialSecurityFollowNumberSectionCode = CreateAndSetCodeProperty(oSocialSecurityFollowNumberSection, "SGKTAKIPNO", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý","1.0", "SGK Takip No Bilgisinin Olduðu Bölüm");
            Object oSocialSecurityFollowNumberSectionText = CreateAndSetTextProperty(oSocialSecurityFollowNumberSection, HastaKabul.SGKTakipNumarasi);

            #endregion

            #region component2

            Object oReceptionDatasetComponent2 = CreateAndSetParent(o, "component2");
            Object oReferralSection = CreateAndSetParent(oReceptionDatasetComponent2, "referralSection");            
            Object oReferralSectionID = CreateAndSetIDProperty(oReferralSection,"2.16.840.1.113883.3.129.2.1.5",UUID);            
            Object oReferralSectionCode = CreateAndSetCodeProperty(oReferralSection,"SEVK", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Sevk Verisinin Olduðu Bölüm");
            Object oReferralSectionText = CreateAndSetTextProperty(oReferralSection, "");

            Object oReferralSectionComponent = CreateAndSetParent(oReferralSection, "component");            
            Object oReferral = CreateAndSetParent(oReferralSectionComponent, "referral");
            Object oReferralEffectiveTime = CreateAndSetParent(oReferral, "effectiveTime");            
            SetProperty(oReferralEffectiveTime, "value", HastaKabul.SevkTarihi.ToString("yyyyMMdd"));

            Object oReferrer = CreateAndSetParent(oReferral, "referrer");            
            Object oReferralFromClinic = CreateAndSetParent( oReferrer, "referralFromClinic");            
            Object oReferralFromClinicCode = CreateAndSetCodeProperty(oReferralFromClinic, HastaKabul.GeldigiPoliklinik.Code, "2.16.840.1.113883.3.129.1.2.1", "Klinikler", "1.0", HastaKabul.GeldigiPoliklinik.DisplayName);
            
            string oReferralComponentName;
            Object oReferralComponentArray;
            Object oReferralComponent;

            if (HastaKabul.SevkTanisi.Count > 0)
            {
                oReferralComponentName = GetPropertyTypeName(oReferral, "component");
                oReferralComponentArray = Array.CreateInstance(Type.GetType(oReferralComponentName), HastaKabul.SevkTanisi.Count);
                SetProperty(oReferral, "component", oReferralComponentArray);                

                for (int s = 0; s < HastaKabul.SevkTanisi.Count; s++)
                {
                    oReferralComponent = CreateObject(oReferralComponentName);
                    ((Array)oReferralComponentArray).SetValue(oReferralComponent, s);

                    Object oReferralDiagnosis = CreateAndSetParent( oReferralComponent, "referralDiagnosis");                    
                    Object oReferralDiagnosisCode = CreateAndSetCodeProperty(oReferralDiagnosis,"SEVKTANISI", "2.16.840.1.113883.3.129.2.2.6","Taný Tipi", "1.0", "Sevk Tanýsý");
                    
                    Object oReferralDiagnosisValue = CreateAndSetParent(oReferralDiagnosis, "value");
                    SetCodeProperty(oReferralDiagnosisValue, HastaKabul.SevkTanisi[s].Code, "2.16.840.1.113883.6.3", "ICD-10", "1.0", HastaKabul.SevkTanisi[s].DisplayName);                    
                }
            }

            #endregion

            #region component3

            Object oReceptionDatasetComponent3 = CreateAndSetParent(o, "component3");
            Object oRegistrationSection = CreateAndSetParent(oReceptionDatasetComponent3, "registrationSection");            
            Object oRegistrationSectionID = CreateAndSetIDProperty(oRegistrationSection,"2.16.840.1.113883.3.129.2.1.5", UUID);            
            Object oRegistrationSectionCode = CreateAndSetCodeProperty(oRegistrationSection, "KABUL", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Kabul Verisinin Olduðu Bölüm");
            Object oRegistrationSectionText = CreateAndSetTextProperty(oRegistrationSection, "");

            Object oRegistrationSectionComponent = CreateAndSetParent(oRegistrationSection, "component");
            Object oRegistration = CreateAndSetParent(oRegistrationSectionComponent, "registration");

            Object oRegistrationCode = CreateAndSetCodeProperty(oRegistration, HastaKabul.KabulSekli.Code, "2.16.840.1.113883.3.129.1.2.7", "Kabul Þekli", "1.0", HastaKabul.KabulSekli.DisplayName);            
            Object oRegistrationEffectiveTime =  CreateAndSetParent(oRegistration, "effectiveTime");
            SetProperty(oRegistrationEffectiveTime, "value", HastaKabul.KabulZamani.ToString("yyyyMMddhhmm"));

            #endregion

            #region component4

            Object oReceptionDatasetComponent4 = CreateAndSetParent(o, "component4");            
            Object oCaseTypeSection = CreateAndSetParent( oReceptionDatasetComponent4, "caseTypeSection");            
            Object oCaseTypeSectionID = CreateAndSetIDProperty(oCaseTypeSection, "2.16.840.1.113883.3.129.2.1.5",UUID);            
            Object oCaseTypeSectionCode = CreateAndSetCodeProperty(oCaseTypeSection,"VAKATURU", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Vaka Türü Bilgisinin Olduðu Bölüm");
            Object oCaseTypeSectionText = CreateAndSetTextProperty(oCaseTypeSection, "");

            Object oCaseTypeSectionComponent = CreateAndSetParent(oCaseTypeSection, "component");
            Object oCaseType = CreateAndSetParent(oCaseTypeSectionComponent, "caseType");
            Object oCaseTypeCode =  CreateAndSetCodeProperty(oCaseType,HastaKabul.VakaTuru.Code, "2.16.840.1.113883.3.129.1.2.53", "Vaka Türü", "1.0", HastaKabul.VakaTuru.DisplayName);
            
            #endregion


        }

        
       
        protected void ExaminationDatasetDoldur(Object o)
        {
            string ClassName = GetClassName(o);
            string BaseClassName = GetBaseClassName(o);

            Object oExaminationDatasetID = CreateAndSetIDProperty(o,"2.16.840.1.113883.3.129.2.1.4",UUID);            
            Object oExaminationDatasetCode = CreateAndSetCodeProperty(o,"MUAYENE", "2.16.840.1.113883.3.129.2.2.2", "Veriseti", "1.0", "Muayene Veriseti");
            Object oExaminationDatasetText = CreateAndSetTextProperty(o, "");

            Object oAuthor = CreateAndSetParent( o, "author");
            Object oDoctor = CreateAndSetParent(oAuthor, "doctor");           
            Object oDoctorID = CreateAndSetIDProperty(oDoctor,"2.16.840.1.113883.3.129.1.1.1", Muayene.HekimKimlikNumarasi);

            #region component1

            Object oExaminationDatasetComponent1 = CreateAndSetParent(o, "component1");
            Object oExamProtocolNoSection = CreateAndSetParent(oExaminationDatasetComponent1, "examProtocolNoSection");
            Object oExamProtocolNoSectionID = CreateAndSetIDProperty(oExamProtocolNoSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oExamProtocolNoSectionCode =CreateAndSetCodeProperty(oExamProtocolNoSection, "PROTOKOLNO", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Protokol No Bilgisinin Olduðu Bölüm");
            Object oExamProtocolNoSectionText = CreateAndSetTextProperty(oExamProtocolNoSection, "");

            Object oExamProtocolNoSectionComponent = CreateAndSetParent(oExamProtocolNoSection, "component");
            Object oExamProtocolNo = CreateAndSetParent(oExamProtocolNoSectionComponent, "examProtocolNo");            
            Object oExamProtocolNoID = CreateAndSetIDProperty(oExamProtocolNo,"2.16.840.1.113883.3.129.1.1.4",Muayene.ProtokolNumarasi);

            #endregion

            #region component2

            Object oExaminationDatasetComponent2 = CreateAndSetParent(o, "component2");            
            Object oReportSection = CreateAndSetParent(oExaminationDatasetComponent2, "reportSection");
            Object oReportSectionID = CreateAndSetIDProperty(oReportSection,"2.16.840.1.113883.3.129.2.1.5",UUID);
            Object oReportSectionCode = CreateAndSetCodeProperty(oReportSection,  "RAPOR", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Rapor Verisinin Olduðu Bölüm");
            Object oReportSectionText = CreateAndSetTextProperty(oReportSection, "");

            string oReportSectionComponentName;
            Object oReportSectionComponentArray;
            Object oReportSectionComponent;

            if (Muayene.Rapor.Count > 0)
            {
                oReportSectionComponentName = GetPropertyTypeName(oReportSection, "component");
                oReportSectionComponentArray = Array.CreateInstance(Type.GetType(oReportSectionComponentName), Muayene.Rapor.Count);
                SetProperty(oReportSection, "component", oReportSectionComponentArray);

                for (int s = 0; s < Muayene.Rapor.Count; s++)
                {
                    oReportSectionComponent = CreateObject(oReportSectionComponentName);
                    ((Array)oReportSectionComponentArray).SetValue(oReportSectionComponent, s);

                    Object oReport = CreateAndSetParent( oReportSectionComponent, "report");                   
                    Object oReportCode = CreateAndSetCodeProperty( oReport,Muayene.Rapor[s].Turu.Code, "2.16.840.1.113883.3.129.1.2.8", "Rapor Türü", "1.0", Muayene.Rapor[s].Turu.DisplayName);
                    
                    Object oReportEffectiveTime = CreateAndSetParent(oReport, "effectiveTime");
                    SetProperty(oReportEffectiveTime, "value", Muayene.Rapor[s].Tarihi.ToString("yyyyMMdd"));

                    Object oReportValue = CreateObject(BaseClassName + ".ST");
                    SetProperty(oReport, "value", oReportValue);
                    SetProperty(oReportValue, "Text", new string[] { Muayene.Rapor[s].Dokumani });

                }
            }

            #endregion

            #region component3

            Object oExaminationDatasetComponent3 = CreateAndSetParent(o, "component3");
            Object oInvestigationSection = CreateAndSetParent(oExaminationDatasetComponent3, "investigationSection");            
            Object oInvestigationSectionID = CreateAndSetIDProperty(oInvestigationSection,"2.16.840.1.113883.3.129.2.1.5",UUID);
            Object oInvestigationSectionCode = CreateAndSetCodeProperty(oInvestigationSection, "BULGU", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Bulgu Verisinin Olduðu Bölüm");
            Object oInvestigationSectionText = CreateAndSetTextProperty(oInvestigationSection, Muayene.Bulgu);

           #endregion

            #region component4

            Object oExaminationDatasetComponent4 = CreateAndSetParent(o, "component4");
            Object oHistorySection = CreateAndSetParent(oExaminationDatasetComponent4, "historySection");            
            Object oHistorySectionID = CreateAndSetIDProperty(oHistorySection, "2.16.840.1.113883.3.129.2.1.5",UUID);
            Object oHistorySectionCode =  CreateAndSetCodeProperty(oHistorySection, "HIKAYE", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Hikaye Verisinin Olduðu Bölüm");
            Object oHistorySectionText = CreateAndSetTextProperty(oHistorySection, Muayene.Hikayesi);

            #endregion

            #region component5

            Object oExaminationDatasetComponent5 = CreateAndSetParent(o, "component5");
            Object oComplaintSection = CreateAndSetParent(oExaminationDatasetComponent5, "complaintSection");
            Object oComplaintSectionID = CreateAndSetIDProperty(oComplaintSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oComplaintSectionCode = CreateAndSetCodeProperty(oComplaintSection, "SIKAYET", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Þikayet Verisinin Olduðu Bölüm");
            Object oComplaintSectionText = CreateAndSetTextProperty(oComplaintSection, Muayene.Sikayeti);

            #endregion

            #region component6

            Object oExaminationDatasetComponent6 = CreateAndSetParent(o, "component6");
            Object oTestSection = CreateAndSetParent(oExaminationDatasetComponent6, "testSection");
            Object oTestSectionID = CreateAndSetIDProperty(oTestSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oTestSectionCode = CreateAndSetCodeProperty(oTestSection, "TETKIK", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Tetkik Verisinin Olduðu Bölüm");
            Object oTestSectionText = CreateAndSetTextProperty(oTestSection, "");

            string oTestSectionComponentName;
            Object oTestSectionComponentArray;
            Object oTestSectionComponent;

            if (Muayene.Tetkik.Count > 0)
            {
                oTestSectionComponentName = GetPropertyTypeName(oTestSection, "component");
                oTestSectionComponentArray = Array.CreateInstance(Type.GetType(oTestSectionComponentName), Muayene.Tetkik.Count);
                SetProperty(oTestSection, "component", oTestSectionComponentArray);

                for (int s = 0; s < Muayene.Tetkik.Count; s++)
                {
                    oTestSectionComponent = CreateObject(oTestSectionComponentName);
                    ((Array)oTestSectionComponentArray).SetValue(oTestSectionComponent, s);

                    Object oTest = CreateAndSetParent(oTestSectionComponent, "test");
                    Object oTestCode = CreateAndSetCodeProperty(oTest,Muayene.Tetkik[s].Tetkik.Code, "2.16.840.1.113883.3.129.1.2.2", "SUT", "1.0", Muayene.Tetkik[s].Tetkik.DisplayName);
                    Object oPerformer = CreateAndSetParent(oTest, "performer");
                    Object oPerformerOrganization = CreateAndSetParent(oPerformer, "performerOrganization");
                    Object oPerformerOrganizationID =  CreateAndSetIDProperty(oPerformerOrganization,"2.16.840.1.113883.3.129.1.1.6", Muayene.Tetkik[s].TetkikIstenenKurum);
                }
            }

            #endregion

            #region component7

            Object oExaminationDatasetComponent7 = CreateAndSetParent(o, "component7");
            Object oProcedureSection = CreateAndSetParent(oExaminationDatasetComponent7, "procedureSection");
            Object oProcedureSectionID = CreateAndSetIDProperty(oProcedureSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oProcedureSectionCode = CreateAndSetCodeProperty(oProcedureSection, "MUDAHALE", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Müdehale Verisinin Olduðu Bölüm");
            Object oProcedureSectionText = CreateAndSetTextProperty(oProcedureSection, "");

            string oProcedureSectionComponentName;
            Object oProcedureSectionComponentArray;
            Object oProcedureSectionComponent;

            if (Muayene.Mudahale.Count > 0)
            {
                oProcedureSectionComponentName = GetPropertyTypeName(oProcedureSection, "component");
                oProcedureSectionComponentArray = Array.CreateInstance(Type.GetType(oProcedureSectionComponentName), Muayene.Mudahale.Count);
                SetProperty(oProcedureSection, "component", oProcedureSectionComponentArray);

                for (int s = 0; s < Muayene.Mudahale.Count; s++)
                {
                    oProcedureSectionComponent = CreateObject(oProcedureSectionComponentName);
                    ((Array)oProcedureSectionComponentArray).SetValue(oProcedureSectionComponent, s);

                    Object oProcedure = CreateAndSetParent(oProcedureSectionComponent, "procedure");
                    Object oProcedureCode = CreateAndSetCodeProperty(oProcedure, Muayene.Mudahale[s].Code, "2.16.840.1.113883.3.129.1.2.2", "SUT", "1.0", Muayene.Mudahale[s].DisplayName);
                }
            }

            #endregion

            #region component8

            Object oExaminationDatasetComponent8 = CreateAndSetParent(o, "component8");            
            Object oDiagnosisSection = CreateAndSetParent(oExaminationDatasetComponent8, "diagnosisSection");            
            Object oDiagnosisSectionID = CreateAndSetIDProperty(oDiagnosisSection, "2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oDiagnosisSectionCode = CreateAndSetCodeProperty(oDiagnosisSection,"TANI", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Taný Verisinin Olduðu Bölüm");
            Object oDiagnosisSectionText = CreateAndSetTextProperty(oDiagnosisSection, "");

            string oDiagnosisSectionComponentName;
            Object oDiagnosisSectionComponentArray;
            Object oDiagnosisSectionComponent;

            // Ana Tani
            oDiagnosisSectionComponentName = GetPropertyTypeName(oDiagnosisSection, "component");
            oDiagnosisSectionComponentArray = Array.CreateInstance(Type.GetType(oDiagnosisSectionComponentName), Muayene.EkTani.Count+1);
            SetProperty(oDiagnosisSection, "component", oDiagnosisSectionComponentArray);

            oDiagnosisSectionComponent = CreateObject(oDiagnosisSectionComponentName);
            ((Array)oDiagnosisSectionComponentArray).SetValue(oDiagnosisSectionComponent, 0);

            Object oDiagnosis = CreateAndSetParent(oDiagnosisSectionComponent, "diagnosis");            
            Object oDiagnosisCode = CreateAndSetCodeProperty(oDiagnosis, "ANATANI", "2.16.840.1.113883.3.129.2.2.6", "Taný Tipi", "1.0", "Ana Taný");
            Object oDiagnosisValue = CreateAndSetParent(oDiagnosis, "value");            
            SetCodeProperty(oDiagnosisValue, Muayene.AnaTani.Code, "2.16.840.1.113883.6.3", "ICD-10", "1.0", Muayene.AnaTani.DisplayName);

                if (Muayene.EkTani.Count > 0)
                {

                for (int s = 0; s < Muayene.EkTani.Count; s++)
                {
                    oDiagnosisSectionComponent = CreateObject(oDiagnosisSectionComponentName);
                    ((Array)oDiagnosisSectionComponentArray).SetValue(oDiagnosisSectionComponent, s+1);

                    oDiagnosis = CreateAndSetParent(oDiagnosisSectionComponent, "diagnosis");
                    oDiagnosisCode = CreateAndSetCodeProperty(oDiagnosis, "EKTANI", "2.16.840.1.113883.3.129.2.2.6", "Taný Tipi", "1.0", "Ek Taný");

                    oDiagnosisValue = CreateAndSetParent(oDiagnosis, "value");                    
                    SetCodeProperty(oDiagnosisValue, Muayene.EkTani[s].Code, "2.16.840.1.113883.6.3", "ICD-10", "1.0", Muayene.EkTani[s].DisplayName);

                }
            }

            #endregion

            #region component9
            Object oExaminationDatasetComponent9 = CreateAndSetParent(o, "component9");
            //Object oExaminationSection = CreateAndSetExaminationSection(oExaminationDatasetComponent9);
            
            
            Object oExaminationSection = CreateAndSetParent(oExaminationDatasetComponent9, "examinationSection");
            Object oExaminationSectionID = CreateAndSetIDProperty(oExaminationSection,"2.16.840.1.113883.3.129.2.1.5", UUID);
            Object oExaminationSectionCode = CreateAndSetCodeProperty(oExaminationSection, "MUAYENE", "2.16.840.1.113883.3.129.2.2.3", "Veri Kýsmý", "1.0", "Muayene Verisinin Olduðu Bölüm");

            Object oExaminationSectionText = CreateObject(BaseClassName + ".StrucDocText");
            SetProperty(oExaminationSection, "text", oExaminationSectionText);
            SetProperty(oExaminationSectionText, "Text", new string[] { "" });

            Object oExaminationSectionComponent = CreateAndSetParent(oExaminationSection, "component");
            Object oEncounter = CreateAndSetParent(oExaminationSectionComponent, "encounter");
            SetEncounterProperty(oEncounter, Muayene.MuayeneBaslangicZamani, Muayene.MuayeneBitisZamani, Muayene.MuayeneYapilanPoliklinik);
             
            /*
            Object oIVL_TS = CreateObject(BaseClassName + ".IVL_TS");
            SetProperty(oEncounter, "effectiveTime", oIVL_TS);

            Object oMuayeneAraligi = Array.CreateInstance(Type.GetType(BaseClassName + ".QTY"), 2);            
            SetProperty(oIVL_TS, "Items", oMuayeneAraligi);            

            Object oIVXB_TS_low = CreateObject(BaseClassName + ".IVXB_TS");
            ((Array)oMuayeneAraligi).SetValue(oIVXB_TS_low, 0);
            SetProperty(oIVXB_TS_low, "value", Muayene.MuayeneBaslangicZamani.ToString("yyyyMMddhhmmss"));

            Object oIVXB_TS_high = CreateObject(BaseClassName + ".IVXB_TS");
            ((Array)oMuayeneAraligi).SetValue(oIVXB_TS_high, 1);
            SetProperty(oIVXB_TS_high, "value", Muayene.MuayeneBitisZamani.ToString("yyyyMMddhhmmss"));

            string oItemsElementNameName = GetPropertyTypeName(oIVL_TS, "ItemsElementName");
            Object oItemsElementNameArray = Array.CreateInstance(Type.GetType(oItemsElementNameName), 2);
            SetProperty(oIVL_TS, "ItemsElementName", oItemsElementNameArray);
            
            Object oLow = Enum.Parse(Type.GetType(oItemsElementNameName), "low");
            Object oHigh = Enum.Parse(Type.GetType(oItemsElementNameName), "high");

            ((Array)oItemsElementNameArray).SetValue(oLow, 0);
            ((Array)oItemsElementNameArray).SetValue(oHigh, 1);

            Object oLocation = CreateAndSetParent(oEncounter, "location");
            Object oClinic = CreateAndSetParent(oLocation, "clinic");
            Object oClinicCode = CreateAndSetCodeProperty(oClinic, Muayene.MuayeneYapilanPoliklinik.Code, "2.16.840.1.113883.3.129.1.2.1", "Klinikler", "1.0", Muayene.MuayeneYapilanPoliklinik.DisplayName);
            */
            #endregion

        }


    }
}
