using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTYS.Entities
{
    public class Urun
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Borçlu seçimi zorunludur.")]
        [Display(Name = "Borçlu Müşteri")]
        public int MusteriId { get; set; }

        [Required(ErrorMessage = "Avukat seçimi zorunludur.")]
        [Display(Name = "Atanan Avukat")]
        public int AvukatId { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [StringLength(60, ErrorMessage = "Ürün adı en fazla 60 karakter olabilir.")]
        [Display(Name = "Ürün Adı")]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "Kredi birim kodu zorunludur.")]
        [StringLength(8, ErrorMessage = "Kredi birim kodu en fazla 8 karakter olabilir.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girilmelidir.")]
        [Display(Name = "Kredi Birim Kodu")]
        public string KrediBirimKodu { get; set; }

        [Required(ErrorMessage = "Takip miktarı zorunludur.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Takip Miktarı")]
        public decimal TakipMiktari { get; set; }

        [Required(ErrorMessage = "Döviz tipi zorunludur.")]
        [Display(Name = "Döviz Tipi")]
        public string DovizTipi { get; set; }

        [Required(ErrorMessage = "Aylık faiz oranı zorunludur.")]
        [Display(Name = "Aylık Faiz Oranı (%)")]
        public double AylikFaizOrani { get; set; }

        [Required(ErrorMessage = "Takip tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Takip Tarihi")]
        public DateTime TakipTarihi { get; set; }

        [Required(ErrorMessage = "Masraf bakiyesi zorunludur.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Masraf Bakiyesi")]
        public decimal MasrafBakiyesi { get; set; }

        [Required(ErrorMessage = "Faiz bakiyesi zorunludur.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Faiz Bakiyesi")]
        public decimal FaizBakiyesi { get; set; }

        [StringLength(200, ErrorMessage = "Açıklama en fazla 200 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }

        // Navigation Properties
        [ForeignKey("MusteriId")]
        public virtual Musteri Borclu { get; set; }

        [ForeignKey("AvukatId")]
        public virtual Avukat Avukat { get; set; }
    }
}
