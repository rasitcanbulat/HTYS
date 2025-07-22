using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTYS.Entities
{
    public class Ihtar
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Borçlu seçimi zorunludur.")]
        [Display(Name = "Borçlu")]
        public int MusteriId { get; set; }

        [Required(ErrorMessage = "Müşteri ürünü seçimi zorunludur.")]
        [Display(Name = "Müşteri Ürünleri")]
        public int UrunId { get; set; }

        [Display(Name = "Noter Adı")]
        [StringLength(100)]
        public string? NoterAdi { get; set; }

        [StringLength(10, ErrorMessage = "Yevmiye No en fazla 10 karakter olabilir.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girilmelidir.")]
        [Display(Name = "Yevmiye No")]
        public string? YevmiyeNo { get; set; }

        [Required(ErrorMessage = "İhtar tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "İhtar Tarihi")]
        public DateTime IhtarTarihi { get; set; }

        [Required(ErrorMessage = "İhtarname süresi zorunludur.")]
        [Display(Name = "İhtarname Süresi (Gün)")]
        [Range(1, 365, ErrorMessage = "Süre 1-365 gün arasında olmalıdır.")]
        public int IhtarnameSuresi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tebliğ Tarihi")]
        public DateTime? TebligTarihi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "İhtar Tebliğ Giriş Tarihi")]
        public DateTime? IhtarTebligGirisTarihi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Kat Tarihi")]
        public DateTime? KatTarihi { get; set; }

        [Required(ErrorMessage = "Nakit tutarı zorunludur.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "İhtarname Nakit Tutarı")]
        public decimal IhtarnameNakitTutari { get; set; }

        [Required(ErrorMessage = "Gayri nakit tutarı zorunludur.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "İhtarname Gayri Nakit Tutarı")]
        public decimal IhtarnameGayriNakitTutari { get; set; }

        [Required(ErrorMessage = "İhtar no zorunludur.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "İhtar No 8 haneli olmalıdır.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girilmelidir.")]
        [Display(Name = "İhtar No")]
        public string IhtarNo { get; set; }

        [ForeignKey("MusteriId")]
        public virtual Musteri? Borclu { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urun? Urun { get; set; }

        public bool AktifMi { get; set; } = true;
    }
}
