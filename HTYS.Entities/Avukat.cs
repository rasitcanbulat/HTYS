using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTYS.Entities
{
    public class Avukat
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(30, ErrorMessage = "Ad en fazla 30 karakter olabilir.")]
        public string Ad { get; set; } = string.Empty;

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(50)]
        public string Soyad { get; set; } = string.Empty;

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [StringLength(15)]
        public string KullaniciAdi { get; set; } = string.Empty;

        [Display(Name = "T.C. Kimlik No")]
        [Required(ErrorMessage = "TCKN zorunludur.")]
        [StringLength(11)]
        public string? TCKN { get; set; }

        [Display(Name = "Vergi No")]
        [StringLength(8)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Lütfen sadece sayı giriniz.")]
        public string? VergiNo { get; set; }

        [Display(Name = "Vergi Dairesi")]
        [StringLength(30, ErrorMessage = "Vergi Dairesi en fazla 30 karakter olabilir.")]
        public string? VergiDairesi { get; set; }

        [Display(Name = "Cep Telefonu")]
        [Phone(ErrorMessage = "Geçersiz telefon numarası formatı.")]
        public string? CepTelefonu { get; set; }

        [Display(Name = "İş Telefonu")]
        [Phone(ErrorMessage = "Geçersiz telefon numarası formatı.")]
        public string? IsTelefonu { get; set; }

        [Display(Name = "Faks No")]
        [Phone(ErrorMessage = "Geçersiz telefon numarası formatı.")]
        public string? FaksNo { get; set; }

        [Display(Name = "E-Mail Adresi")]
        [Required(ErrorMessage = "E-Mail adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-mail formatı.")]
        [RegularExpression(@"^[\w-\.]+@halkbank\.com\.tr$", ErrorMessage = "E-mail adresi @halkbank.com.tr ile bitmelidir.")]
        public string? EmailAdresi { get; set; }

        [Display(Name = "Avukat Tipi")]
        [Required(ErrorMessage = "Avukat tipi seçimi zorunludur.")]
        public string? AvukatTipi { get; set; }

        [Display(Name = "Halkbank Vadesiz IBAN")]
        [StringLength(30, ErrorMessage = "IBAN, 'TR' ile başlamalı ve toplam 26 karakter olmalıdır.")]
        public string? HalkbankVadesizIBAN { get; set; }

        [Display(Name = "Diğer Banka IBAN")]
        [StringLength(30, ErrorMessage = "IBAN, 'TR' ile başlamalı ve toplam 26 karakter olmalıdır.")]
        public string? DigerBankaIBAN { get; set; }

        [Display(Name = "Şehir")]
        public string? Sehir { get; set; }

        [Display(Name = "İlçe")]
        public string? Ilce { get; set; }

        [Display(Name = "Semt / Mahalle")]
        [StringLength(50)]
        public string? Semt { get; set; }

        [Display(Name = "Tam Adres")]
        public string? TamAdres { get; set; }

        [Display(Name = "Hesap Aktif Mi?")]
        public bool HesapAktifMi { get; set; } = true;


        [NotMapped]
        public decimal? AvansAsimLimiti { get; set; }
    }
}
