using HTYS.BusinessLayer;
using HTYS.WebUI.Filters;
using HTYS.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTYS.WebUI.Controllers
{
    [AuthenticationFilter]
    public class BankaPanelController : Controller
    {
        private readonly AvukatYonetim _avukatYonetim;
        private readonly MusteriYonetim _musteriYonetim;
        private readonly UrunYonetim _urunYonetim;
        private readonly IhtarYonetim _ihtarYonetim;
        private readonly IcraTakipYonetim _icraTakipYonetim;

        public BankaPanelController(AvukatYonetim avukatYonetim, MusteriYonetim musteriYonetim, UrunYonetim urunYonetim, IhtarYonetim ihtarYonetim, IcraTakipYonetim icraTakipYonetim)
        {
            _avukatYonetim = avukatYonetim;
            _musteriYonetim = musteriYonetim;
            _urunYonetim = urunYonetim;
            _ihtarYonetim = ihtarYonetim;
            _icraTakipYonetim = icraTakipYonetim;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("KullaniciAdi")))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.KullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");

            var viewModel = new BankaPanelViewModel
            {
                AvukatSayisi = _avukatYonetim.ToplamAvukatSayisiGetir(),
                MusteriSayisi = _musteriYonetim.MusteriSayisiGetir(null),
                UrunSayisi = _urunYonetim.UrunSayisiGetir(),
                IhtarSayisi = _ihtarYonetim.IhtarSayisiGetir(),
                IcraSayisi = _icraTakipYonetim.IcraSayisiGetir()
            };

            return View(viewModel);
        }
    }
}
