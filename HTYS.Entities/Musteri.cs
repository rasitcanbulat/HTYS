using System.ComponentModel.DataAnnotations;

namespace HTYS.Entities
{
    public class Musteri
    {
        public int Id { get; set; }

        [Display(Name = "Müşteri No")]
        [Required(ErrorMessage = "Müşteri Numarası zorunludur.")]
        [StringLength(8, ErrorMessage = "Müşteri Numarası en fazla 8 karakter olabilir.")]
        public string MusteriNo { get; set; } = string.Empty;

        [Display(Name = "Ad / Ünvan")]
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(30, ErrorMessage = "Ad en fazla 30 karakter olabilir.")]
        public string? Ad { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string? Soyad { get; set; }

        [Display(Name = "T.C. Kimlik No")]
        [Required(ErrorMessage = "TCKN zorunludur.")]
        [RegularExpression(@"^[1-9]{1}[0-9]{9}[0,2,4,6,8]{1}$", ErrorMessage = "Geçersiz TCKN formatı.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TCKN 11 haneli olmalıdır.")]
        public string? TCKN { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }

        [Display(Name = "Doğum Yeri")]
        [StringLength(30, ErrorMessage = "Doğum Yeri en fazla 30 karakter olabilir.")]
        public string? DogumYeri { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet seçimi zorunludur.")]
        public string? Cinsiyet { get; set; }

        [Display(Name = "Medeni Durum")]
        [Required(ErrorMessage = "Medeni durum seçimi zorunludur.")]
        public string? MedeniDurum { get; set; }

        [Display(Name = "Baba Adı")]
        public string? BabaAdi { get; set; }

        [Display(Name = "Anne Adı")]
        public string? AnneAdi { get; set; }

        [Display(Name = "Pasaport No")]
        [StringLength(8, ErrorMessage = "Pasaport No en fazla 8 karakter olabilir.")]
        public string? PasaportNo { get; set; }

        [Display(Name = "Nüfusa Kayıtlı İl")]
        [StringLength(30, ErrorMessage = "Nüfusa Kayıtlı İl en fazla 30 karakter olabilir.")]
        public string? NufusaKayitliIl { get; set; }

        [Display(Name = "Cilt No")]
        [StringLength(2, ErrorMessage = "Cilt No en fazla 2 karakter olabilir.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Lütfen sadece sayı giriniz.")]
        public string? CiltNo { get; set; }

        [Display(Name = "Aile Sıra No")]
        [StringLength(3, ErrorMessage = "Aile Sıra No en fazla 3 karakter olabilir.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Lütfen sadece sayı giriniz.")]
        public string? AileSiraNo { get; set; }

        [Display(Name = "Kütük Sıra No")]
        [StringLength(3, ErrorMessage = "Kütük Sıra No en fazla 3 karakter olabilir.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Lütfen sadece sayı giriniz.")]
        public string? KutukSiraNo { get; set; }

        [Display(Name = "Şehir")]
        public string? Sehir { get; set; }

        [Display(Name = "İlçe")]
        public string? Ilce { get; set; }

        [Display(Name = "Semt / Mahalle")]
        [StringLength(50, ErrorMessage = "Semt / Mahalle en fazla 50 karakter olabilir.")]
        public string? Semt { get; set; }

        [Display(Name = "Adres Detayı")]
        public string? AdresDetay { get; set; }

        [Display(Name = "Vergi Dairesi")]
        [StringLength(30, ErrorMessage = "Vergi Dairesi en fazla 30 karakter olabilir.")]
        public string? VergiDairesi { get; set; }

        [Display(Name = "Vergi No")]
        [StringLength(8, ErrorMessage = "Vergi No en fazla 8 karakter olabilir.")]
        public string? VergiNo { get; set; }

        [Display(Name = "Hayatta Mı?")]
        public bool HayattaMi { get; set; } = true;

        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

        [Display(Name = "Aktif Mi?")]
        public bool AktifMi { get; set; } = true;
    }
}
