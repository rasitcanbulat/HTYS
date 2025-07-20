using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTYS.Entities
{
    public class IcraTakip
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Borçlu seçimi zorunludur.")]
        [Display(Name = "Borçlu")]
        public int MusteriId { get; set; }

        [Required(ErrorMessage = "Avukat seçimi zorunludur.")]
        [Display(Name = "Avukat")]
        public int AvukatId { get; set; }

        [Display(Name = "Avukat TCKN")]
        [NotMapped]
        public string? AvukatTCKN { get; set; }

        [Required(ErrorMessage = "Takip tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Takip Tarihi")]
        public DateTime TakipTarihi { get; set; }

        [Required(ErrorMessage = "Takip tipi zorunludur.")]
        [Display(Name = "Takip Tipi")]
        public string TakipTipi { get; set; }

        [Required(ErrorMessage = "İhtar seçimi zorunludur.")]
        [Display(Name = "İhtarlar")]
        public int IhtarId { get; set; }

        [Required(ErrorMessage = "Ürün seçimi zorunludur.")]
        [Display(Name = "İhtar Konusu Ürünler")]
        public int UrunId { get; set; }

        [Required(ErrorMessage = "İcra müdürlüğü zorunludur.")]
        [StringLength(50)]
        [Display(Name = "İcra Müdürlüğü")]
        public string IcraMudurugu { get; set; }

        [Required(ErrorMessage = "İcra dosya no zorunludur.")]
        [StringLength(8, ErrorMessage = "İcra Dosya No en fazla 8 rakam olabilir.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girilmelidir.")]
        [Display(Name = "İcra Dosya No")]
        public string IcraDosyaNo { get; set; }

        [Required(ErrorMessage = "Mahiyet kodu zorunludur.")]
        [StringLength(12, ErrorMessage = "Mahiyet Kodu en fazla 12 rakam olabilir.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girilmelidir.")]
        [Display(Name = "Mahiyet Kodu")]
        public string MahiyetKodu { get; set; }

        [ForeignKey("MusteriId")]
        public virtual Musteri? Borclu { get; set; }

        [ForeignKey("AvukatId")]
        public virtual Avukat? Avukat { get; set; }

        [ForeignKey("IhtarId")]
        public virtual Ihtar? Ihtar { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urun? Urun { get; set; }
    }
}
