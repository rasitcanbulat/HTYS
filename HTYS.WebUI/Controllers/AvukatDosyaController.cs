using HTYS.BusinessLayer;
using HTYS.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HTYS.WebUI.Controllers
{
    [AuthenticationFilter]
    public class AvukatDosyaController : Controller
    {
        private readonly IhtarYonetim _ihtarYonetim;
        private readonly IcraTakipYonetim _icraTakipYonetim;
        private readonly AvukatYonetim _avukatYonetim;

        public AvukatDosyaController(IhtarYonetim ihtarYonetim, IcraTakipYonetim icraTakipYonetim, AvukatYonetim avukatYonetim)
        {
            _ihtarYonetim = ihtarYonetim;
            _icraTakipYonetim = icraTakipYonetim;
            _avukatYonetim = avukatYonetim;
        }
        public IActionResult Ihtarlarim()
        {
            var kullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            if (string.IsNullOrEmpty(kullaniciAdi)) return RedirectToAction("Login", "Account");

            var avukat = _avukatYonetim.KullaniciAdinaGoreGetir(kullaniciAdi);
            if (avukat == null) return RedirectToAction("Login", "Account");

            ViewBag.KullaniciAdi = kullaniciAdi;
            var model = _ihtarYonetim.AvukataGoreGetir(avukat.Id);
            return View(model);
        }

        public IActionResult Iclarim()
        {
            var kullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            if (string.IsNullOrEmpty(kullaniciAdi)) return RedirectToAction("Login", "Account");

            var avukat = _avukatYonetim.KullaniciAdinaGoreGetir(kullaniciAdi);
            if (avukat == null) return RedirectToAction("Login", "Account");

            ViewBag.KullaniciAdi = kullaniciAdi;
            var model = _icraTakipYonetim.AvukataGoreGetir(avukat.Id);
            return View(model);
        }
    }
}
