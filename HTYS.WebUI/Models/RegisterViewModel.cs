using System.ComponentModel.DataAnnotations;

namespace HTYS.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]
        public string Sifre { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string SifreTekrar { get; set; }

        public string KullaniciTipi { get; set; }

        [Required(ErrorMessage = "Doğrulama kodu zorunludur.")]
        [Display(Name = "Doğrulama Kodu")]
        public string CaptchaCode { get; set; }
    }
}
