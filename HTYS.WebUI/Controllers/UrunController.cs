using HTYS.BusinessLayer;
using HTYS.Entities;
using HTYS.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HTYS.WebUI.Controllers
{
    [AuthenticationFilter]
    public class UrunController : Controller
    {
        private readonly UrunYonetim _urunYonetim;
        private readonly MusteriYonetim _musteriYonetim;
        private readonly AvukatYonetim _avukatYonetim;

        public UrunController(UrunYonetim urunYonetim, MusteriYonetim musteriYonetim, AvukatYonetim avukatYonetim)
        {
            _urunYonetim = urunYonetim;
            _musteriYonetim = musteriYonetim;
            _avukatYonetim = avukatYonetim;
        }

        public IActionResult Index()
        {
            var model = _urunYonetim.HepsiniGetir();
            return View(model);
        }

        private void PopulateDropdowns()
        {
            var musteriler = _musteriYonetim.HepsiniGetir(null, 1, int.MaxValue)
                .Select(m => new { Id = m.Id, TamAd = $"{m.Ad} {m.Soyad} (TCKN: {m.TCKN})" });

            var avukatlar = _avukatYonetim.HepsiniGetir()
                .Select(a => new { Id = a.Id, TamAd = $"{a.Ad} {a.Soyad}" });

            ViewBag.Musteriler = new SelectList(musteriler, "Id", "TamAd");
            ViewBag.Avukatlar = new SelectList(avukatlar, "Id", "TamAd");
            ViewBag.DovizTipleri = new SelectList(new[] { "TL", "USD", "EUR" });
        }

        public IActionResult Create()
        {
            PopulateDropdowns();
            return View(new Urun { TakipTarihi = System.DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Urun urun)
        {
            ModelState.Remove("Borclu");
            ModelState.Remove("Avukat");

            if (ModelState.IsValid)
            {
                _urunYonetim.Ekle(urun);
                return RedirectToAction(nameof(Index));
            }
            PopulateDropdowns();
            return View(urun);
        }

        public IActionResult Edit(int id)
        {
            var urun = _urunYonetim.IdyeGoreGetir(id);
            if (urun == null)
            {
                return NotFound();
            }
            PopulateDropdowns();
            return View(urun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Urun urun)
        {
            if (id != urun.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Borclu");
            ModelState.Remove("Avukat");

            if (ModelState.IsValid)
            {
                _urunYonetim.Guncelle(urun);
                return RedirectToAction(nameof(Index));
            }
            PopulateDropdowns();
            return View(urun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _urunYonetim.Sil(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
