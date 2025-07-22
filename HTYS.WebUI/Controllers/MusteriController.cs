using HTYS.BusinessLayer;
using HTYS.Entities;
using HTYS.WebUI.Filters;
using HTYS.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTYS.WebUI.Controllers
{
    [AuthenticationFilter]
    public class MusteriController : Controller
    {
        private readonly MusteriYonetim _musteriYonetim;
        public MusteriController(MusteriYonetim musteriYonetim) { _musteriYonetim = musteriYonetim; }

        public IActionResult Index(string aramaTerimi, int sayfa = 1)
        {
            int sayfaBasiKayit = 5;
            var musteriler = _musteriYonetim.HepsiniGetir(aramaTerimi, sayfa, sayfaBasiKayit);
            var toplamMusteri = _musteriYonetim.MusteriSayisiGetir(aramaTerimi);

            var model = new MusteriListViewModel
            {
                Musteriler = musteriler,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = sayfa,
                    ItemsPerPage = sayfaBasiKayit,
                    TotalItems = toplamMusteri
                },
                AramaTerimi = aramaTerimi
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var musteri = _musteriYonetim.IdyeGoreGetir(id);
            if (musteri == null) return NotFound();
            return PartialView("_MusteriDetayPartial", new MusteriDetayViewModel { Musteri = musteri });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Musteri();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _musteriYonetim.Ekle(musteri);
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var musteri = _musteriYonetim.IdyeGoreGetir(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        [HttpPost]
        public IActionResult Edit(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _musteriYonetim.Guncelle(musteri);
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _musteriYonetim.Sil(id);
            return RedirectToAction("Index");
        }   
    }
}