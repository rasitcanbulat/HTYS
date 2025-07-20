using HTYS.BusinessLayer;
using HTYS.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTYS.WebUI.Controllers
{
    public class AvukatPanelController : Controller
    {
        private readonly AvukatYonetim _avukatYonetim;
        private readonly UrunYonetim _urunYonetim;
        private readonly IhtarYonetim _ihtarYonetim;
        private readonly IcraTakipYonetim _icraTakipYonetim;

        public AvukatPanelController(
            AvukatYonetim avukatYonetim,
            UrunYonetim urunYonetim,
            IhtarYonetim ihtarYonetim,
            IcraTakipYonetim icraTakipYonetim)
        {
            _avukatYonetim = avukatYonetim;
            _urunYonetim = urunYonetim;
            _ihtarYonetim = ihtarYonetim;
            _icraTakipYonetim = icraTakipYonetim;
        }

        public IActionResult Index()
        {

            var kullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");

            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                return RedirectToAction("Login", "Account");
            }

            var avukat = _avukatYonetim.KullaniciAdinaGoreGetir(kullaniciAdi);
            if (avukat == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.KullaniciAdi = kullaniciAdi;

            var viewModel = new AvukatPanelViewModel
            {
                MusteriSayisi = _urunYonetim.AvukataGoreMusteriSayisiGetir(avukat.Id),
                IhtarSayisi = _ihtarYonetim.AvukataGoreIhtarSayisiGetir(avukat.Id),
                IcraSayisi = _icraTakipYonetim.AvukataGoreIcraSayisiGetir(avukat.Id)
            };

            return View(viewModel);
        }
    }
}
