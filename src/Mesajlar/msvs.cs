using System;
using System.Collections.Generic;


namespace SaglikNetLib
{

    public class CodeDisplayName
    {
        public string Code;
        public string DisplayName;

        public bool IsSet {
            get { return Code.Length>0; }
        }

        public CodeDisplayName()
        {
            Code = "";
            DisplayName = "";
        }
    }

    public class VatandasYabanciHastaKayitMSVS
    {
        public string HastaTCKimlikNumarasi;
        public string Ad;
        public string Soyad;
        public CodeDisplayName Cinsiyet;
        public CodeDisplayName Uyruk;
        public DateTime DogumTarihi;

        public VatandasYabanciHastaKayitMSVS()
        {
            Cinsiyet=new CodeDisplayName();
            Uyruk = new CodeDisplayName();
        }

    }

    public class YenidoganKayitMSVS
    {
        public DateTime DogumTarihi;
        public string AnneTCKimlikNo;
        public string DogumSirasi;
        public CodeDisplayName Cinsiyet;

        public YenidoganKayitMSVS()
        {
            Cinsiyet = new CodeDisplayName();
        }
    }

    public class HastaKabulMSVS
    {
        public DateTime KabulZamani;
        public CodeDisplayName KabulSekli;
        public CodeDisplayName GeldigiPoliklinik;
        public List<CodeDisplayName> SevkTanisi;
        public DateTime SevkTarihi;
        public CodeDisplayName VakaTuru;
        public string SGKTakipNumarasi;

        public HastaKabulMSVS()
        {
            KabulSekli = new CodeDisplayName();
            GeldigiPoliklinik = new CodeDisplayName();
            VakaTuru = new CodeDisplayName();
            SevkTanisi = new List<CodeDisplayName>();
        }
        
    }


    public struct RaporBilgisi
    {
        public CodeDisplayName Turu;
        public DateTime Tarihi;
        public string Dokumani;
    }

    public struct TetkikBilgisi
    {
        public CodeDisplayName Tetkik;
        public string TetkikIstenenKurum;
    }

    public class MuayeneMSVS
    {
        public string HekimKimlikNumarasi;
        public string ProtokolNumarasi;
        public List<CodeDisplayName> Mudahale;
        public CodeDisplayName MuayeneYapilanPoliklinik;
        public DateTime MuayeneBaslangicZamani;
        public DateTime MuayeneBitisZamani;
        public string Sikayeti;
        public string Hikayesi;
        public string Bulgu;
        public List<TetkikBilgisi> Tetkik;
        public CodeDisplayName AnaTani;
        public List<CodeDisplayName> EkTani;
        public List<RaporBilgisi> Rapor;

        public MuayeneMSVS()
        {
            MuayeneYapilanPoliklinik = new CodeDisplayName();
            AnaTani = new CodeDisplayName();

            Mudahale = new List<CodeDisplayName>();
            EkTani = new List<CodeDisplayName>();
            Rapor = new List<RaporBilgisi>();
            Tetkik = new List<TetkikBilgisi>();
        }

        ~MuayeneMSVS()
        {
            Mudahale.Clear();
            EkTani.Clear();
            Rapor.Clear();
            Tetkik.Clear();
        }

    }


    public class HastaCikisMSVS
    {
        public CodeDisplayName CikisSekli;
        public DateTime CikisZamani;
        public CodeDisplayName SevkEdilenPoliklinik;
        public CodeDisplayName SevkTanisi;
    }

    public class TetkikSonucuMSVS
    {
        public string HekimKimlikNumarasi;
        public string TetkikYapanKurum;
        public CodeDisplayName Tetkik;
        public DateTime TetkikSonucTarihi;
        public string TetkikSonucDokumani;
    }

    public struct IlacBilgisi
    {
        public string Adedi;
        public CodeDisplayName Ilac;
        public CodeDisplayName KullanimSekli;
        public string KullanimPeriyodu;
        public string KullanimPeriyoduBirimi;
        public string KullanimAdedi;
    }

    public class ReceteMSVS
    {
        public string HekimKimlikNumarasi;
        public string DiplomaTescilNumarasi;
        public string ProtokolNumarasi;
        public CodeDisplayName ReceteTuru;
        public DateTime ReceteTarihi;
        public CodeDisplayName SosyalGuvenceDurumu;
        public CodeDisplayName AnaTani;
        public List<CodeDisplayName> EkTani;
        public List<IlacBilgisi> Ilac;
        public string SGKKarneNumarasi;

        public ReceteMSVS()
        {
            EkTani = new List<CodeDisplayName>();
            Ilac = new List<IlacBilgisi>();
        }

        ~ReceteMSVS()
        {
            EkTani.Clear();
            Ilac.Clear();
        }
    }


    public class DogumBildirimMSVS
    {
        public string HekimKimlikNumarasi;
        public DateTime IslemZamani;
        public string Agirlik;
        public string BasCevresi;
        public CodeDisplayName APGAR1;
        public CodeDisplayName APGAR5;
        public List<CodeDisplayName> KomplikasyonTanisi;
        public List<CodeDisplayName> BebekSagligiIslemleri;
        public CodeDisplayName DogumYontemi;

        public DogumBildirimMSVS()
        {
            KomplikasyonTanisi = new List<CodeDisplayName>();
            BebekSagligiIslemleri = new List<CodeDisplayName>();
        }

        ~DogumBildirimMSVS()
        {
            KomplikasyonTanisi.Clear();
            BebekSagligiIslemleri.Clear();
        }
    }

    struct OlumBilgisi
    {
        CodeDisplayName OlumNedeniTuru;
        CodeDisplayName OlumNedeni;
    }

    public class OlumBildirimMSVS
    {
        string Kurum;
        string HekimKimlikNumarasi;
        DateTime IslemZamani;
        DateTime OlumTarihi;
        CodeDisplayName OlumYeri;
        List<OlumBilgisi> OlumBilgisi;
        CodeDisplayName AnneOlumuDurumu;

        public OlumBildirimMSVS()
        {
            OlumBilgisi = new List<OlumBilgisi>();
        }

        ~OlumBildirimMSVS()
        {
            OlumBilgisi.Clear();
        }
    }

    public class AgizVeDisSagligiMSVS
    {
        public string HekimKimlikNumarasi;
        public string ProtokolNumarasi;
        public DateTime IslemZamani;
        public CodeDisplayName MuayeneYapilanPoliklinik;
        public DateTime MuayeneBaslangicZamani;
        public DateTime MuayeneBitisZamani;
        public List<CodeDisplayName> TedaviEdilenDisinKodu;
        public List<TetkikBilgisi> Tetkik;
        public List<CodeDisplayName> Mudahale;

        public AgizVeDisSagligiMSVS()
        {
            TedaviEdilenDisinKodu = new List<CodeDisplayName>();
            Tetkik = new List<TetkikBilgisi>();
            Mudahale = new List<CodeDisplayName>();
        }

        ~AgizVeDisSagligiMSVS()
        {
            TedaviEdilenDisinKodu.Clear();
            Tetkik.Clear();
            Mudahale.Clear();
        }


    }

    public class DiyalizHastasiBildirimMSVS
    {
        public DateTime DiyalizTedavisineBaslamaTarihi;
        public CodeDisplayName AnaTani;
        public CodeDisplayName PrimerTani;
        public CodeDisplayName AlternatifHemodiyalizTedavisi;
    }

    public class DiyalizHastasiIzlemMSVS
    {
        public CodeDisplayName DiyalizTedavisiYöntemi;
        public CodeDisplayName DiyalizeGirmeSikligi;
        public CodeDisplayName AnemiTedavisiYontemi;
        public CodeDisplayName AktifVitaminDKullanimi;
        public CodeDisplayName TedavininSeyri;
    }

    public class BebekCocukIzlemMSVS
    {
        string HekimKimlikNumarasi;
        string VekaletEdilenAileHekimi;
        DateTime IslemZamani;
        string Agirlik;
        string Boy;
        string BasCevresi;
        List<CodeDisplayName> BebekSagligiIslemleri;

        public BebekCocukIzlemMSVS()
        {
            BebekSagligiIslemleri = new List<CodeDisplayName>();
        }

        ~BebekCocukIzlemMSVS()
        {
            BebekSagligiIslemleri.Clear();
        }
    }

    public class BebekCocukBeslenmeMSVS
    {
        public string HekimKimlikNumarasi;
        public string VekaletEdilenAileHekimi;
        public DateTime IslemZamani;
        public string SadeceAnneSutuAldigiSure;
        public string EkiGidayaBasladigiAy;
        public string AnneSutundenKesildigiAy;
    }

    public class GebeIzlemMSVS
    {
        public string HekimKimlikNumarasi;
        public string VekaletEdilenAileHekimi;
        public DateTime IslemZamani;
        public DateTime SonAdetTarihi;
        public string Agirlik;
        public string Nabiz;
        public string SistolikKanBasinci;
        public string DiastolikKanBasinci;
        public CodeDisplayName IdrardaProtein;
        public CodeDisplayName Hemoglobin;
        public CodeDisplayName FetusKalpSesi;
        public List<CodeDisplayName> GebelikteRiskFaktorleri;
        public List<CodeDisplayName> GebelikTehlikeIsareti;
        public List<CodeDisplayName> KadinSagligiIslemleri;

        public GebeIzlemMSVS()
        {
            GebelikteRiskFaktorleri = new List<CodeDisplayName>();
            GebelikTehlikeIsareti = new List<CodeDisplayName>();
            KadinSagligiIslemleri = new List<CodeDisplayName>();
        }

        ~GebeIzlemMSVS()
        {
            GebelikteRiskFaktorleri.Clear();
            GebelikTehlikeIsareti.Clear();
            KadinSagligiIslemleri.Clear();
        }
    }

    public class GebePsikososyalIzlemMSVS
    {
        public string HekimKimlikNumarasi;
        public DateTime IslemZamani;
        public List<CodeDisplayName> BebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler;
        public List<CodeDisplayName> BebeginCocugunPsikolojikGelisimindekiRisklereYonelikEgitimler;
        public List<CodeDisplayName> GebedeRiskFaktorlerineYapilanMudahale;
        public List<CodeDisplayName> GebedeSikIzlemeAlinanRiskAltindakiOlgununTakibi;

        public GebePsikososyalIzlemMSVS()
        {
            BebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler = new List<CodeDisplayName>();
            BebeginCocugunPsikolojikGelisimindekiRisklereYonelikEgitimler = new List<CodeDisplayName>();
            GebedeRiskFaktorlerineYapilanMudahale = new List<CodeDisplayName>();
            GebedeSikIzlemeAlinanRiskAltindakiOlgununTakibi = new List<CodeDisplayName>();
        }

        ~GebePsikososyalIzlemMSVS()
        {
            BebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler.Clear();
            BebeginCocugunPsikolojikGelisimindekiRisklereYonelikEgitimler.Clear();
            GebedeRiskFaktorlerineYapilanMudahale.Clear();
            GebedeSikIzlemeAlinanRiskAltindakiOlgununTakibi.Clear();
        }
    }

    public class LohusaIzlemMSVS
    {
        public string HekimKimlikNumarasi;
        public string VekaletEdilenAileHekimi;
        public DateTime IslemZamani;
        public DateTime GebelikSonlanmaTarihi;
        public CodeDisplayName Hemoglobin;
        public List<CodeDisplayName> GebelikLohusalikSeyrindeTehlikeIsareti;
        public List<CodeDisplayName> KomplikasyonTanisi;
        public List<CodeDisplayName> KadinSagligiIslemleri;
        public DateTime SonAdetTarihi;

        public LohusaIzlemMSVS()
        {
            GebelikLohusalikSeyrindeTehlikeIsareti = new List<CodeDisplayName>();
            KomplikasyonTanisi = new List<CodeDisplayName>();
            KadinSagligiIslemleri = new List<CodeDisplayName>();
        }

        ~LohusaIzlemMSVS()
        {
            GebelikLohusalikSeyrindeTehlikeIsareti.Clear();
            KomplikasyonTanisi.Clear();
            KadinSagligiIslemleri.Clear();
        }
    }

    public class DiyabetMSVS
    {
        public DateTime IlkTaniTarihi;
        public string Boy;
        public string Agirlik;
        public string BelCevresi;
        public CodeDisplayName Egzersiz;
        public CodeDisplayName TibbiBeslenmeTedavisineUyum;
        public string SistolikKanBasinci;
        public string DiastolikKanBasinci;
        public CodeDisplayName TiroidMuayenesi;
        public List<CodeDisplayName> BirlikteSikGorulenEkHastaliklar;

        public DiyabetMSVS()
        {
            BirlikteSikGorulenEkHastaliklar = new List<CodeDisplayName>();
        }

        ~DiyabetMSVS()
        {
            BirlikteSikGorulenEkHastaliklar.Clear();
        }
    }

    public struct AsiBilgisi
    {
        CodeDisplayName Asi;
        string LotNumarasi;
    }

    public class AsiMSVS
    {
        public string HekimKimlikNumarasi;
        public string VekaletEdilenAileHekimi;
        public DateTime IslemZamani;
        public List<AsiBilgisi> AsiBilgisi;

        public AsiMSVS()
        {
            AsiBilgisi = new List<AsiBilgisi>();
        }

        ~AsiMSVS()
        {
            AsiBilgisi.Clear();
        }
    }

    public class MaddeBagimliligiBildirimMSVS
    {
        public string HastaKodu;
        public string HekimKimlikNumarasi;
        public DateTime IslemZamani;
        public CodeDisplayName GonderenBirim;
        public CodeDisplayName KullanilanEsasMadde;
        public CodeDisplayName MaddeKullanimSikligi;
        public CodeDisplayName MaddeKullanimYolu;
        public CodeDisplayName EnjektorPaylasimDurumu;
        public List<CodeDisplayName> BulasiciHastalikDurumu;
        public string IlkMaddeKullanimYasi;
        public string DuzenliMaddeKullanimSuresi;
        public CodeDisplayName YasadigiBolge;
        public CodeDisplayName YasamBicimi;
        public CodeDisplayName GecmisteTedaviDurumu;
        public CodeDisplayName TedaviSekli;

        public MaddeBagimliligiBildirimMSVS()
        {
            BulasiciHastalikDurumu = new List<CodeDisplayName>();
        }

        ~MaddeBagimliligiBildirimMSVS()
        {
            BulasiciHastalikDurumu.Clear();
        }

    }

    public class OnbesKirkDokuzYasKadinIzlemMSVS
    {
        public string HekimKimlikNumarasi;
        public string VekaletEdilenAileHekimi;
        public DateTime IslemZamani;
        public string EvlenmeYasi;
        public string DogumSayisi;
        public string CanliDoganBebekSayisi;
        public string OluDoganBebekSayisi;
        public string KendiligindenDusukSayisi;
        public string IsteyerekDusukSayisi;
        public CodeDisplayName KonjenitalAnomaliliDogumVarligi;
        public List<CodeDisplayName> KadinSagligiIslemleri;
        public List<CodeDisplayName> KullanilanAPKorunmaYontemi;
        public CodeDisplayName APYontemiKullanmamaNedeni;
        public CodeDisplayName Hemoglobin;

        public OnbesKirkDokuzYasKadinIzlemMSVS()
        {
            KadinSagligiIslemleri = new List<CodeDisplayName>();
            KullanilanAPKorunmaYontemi = new List<CodeDisplayName>();
        }

        ~OnbesKirkDokuzYasKadinIzlemMSVS()
        {
            KadinSagligiIslemleri.Clear();
            KullanilanAPKorunmaYontemi.Clear();
        }

    }

    public struct AdresBilgisi
    {
        public CodeDisplayName AdresTipi;
        public CodeDisplayName AdresKodu;
        public CodeDisplayName AcikAdres;
    }

    public struct TelefonBilgisi
    {
        public CodeDisplayName TelefonTipi;
        public string TelefonNumarasi;
    }


    public class HastaOzlukBilgileriMSVS
    {
        public string HekimKimlikNumarasi;
        public DateTime IslemZamani;
        public CodeDisplayName DogumYeri;
        public CodeDisplayName Cinsiyet;
        public CodeDisplayName Meslek;
        public CodeDisplayName MedeniHali;
        public CodeDisplayName IsDurumu;
        public CodeDisplayName SosyalGuvenceDurumu;
        public DateTime DogumTarihi;
        public CodeDisplayName OgrenimDurumu;
        public List<AdresBilgisi> Adres;
        public List<TelefonBilgisi> Telefon;
        public string eposta;
        public CodeDisplayName KanGrubu;
        public CodeDisplayName GeziciHizmetAlmaDurumu;
        public CodeDisplayName OzurlulukDurumu;
        public CodeDisplayName SigaraKullanými;
        public CodeDisplayName AlkolKullanimi;
        public CodeDisplayName MaddeKullanimi;
        public CodeDisplayName AmeliyatGecmisi;
        public CodeDisplayName YaralanmaGecmisi;

        public HastaOzlukBilgileriMSVS()
        {
            Adres = new List<AdresBilgisi>();
            Telefon = new List<TelefonBilgisi>();
        }

        ~HastaOzlukBilgileriMSVS()
        {
            Adres.Clear();
            Telefon.Clear();
        }
    }


    public class KanserMSVS
    {
        public DateTime IlkTaniTarihi;
        public CodeDisplayName TaniYontemi;
        public CodeDisplayName TumorunYeri;
        public CodeDisplayName CogulPrimerDurumu;
        public CodeDisplayName HistolojikTip;
        public CodeDisplayName Lateralite;
        public CodeDisplayName SEEROzetEvre;
        public CodeDisplayName TedaviYontemi;
    }

    class msvs
    {
    }
}
