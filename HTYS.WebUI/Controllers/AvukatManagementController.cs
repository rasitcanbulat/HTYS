using HTYS.BusinessLayer;
using HTYS.Entities;
using HTYS.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HTYS.WebUI.Controllers
{
    [AuthenticationFilter]
    public class AvukatManagementController : Controller
    {
        private readonly AvukatYonetim _avukatYonetim;

        public AvukatManagementController(AvukatYonetim avukatYonetim)
        {
            _avukatYonetim = avukatYonetim;
        }
        public IActionResult Index(string searchTerm, int page = 1)
        {
            ViewBag.KullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            int pageSize = 10;
            var avukatlar = _avukatYonetim.HepsiniGetir();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var lowerTerm = searchTerm.ToLower();
                avukatlar = avukatlar.Where(a =>
                    a.Ad.ToLower().Contains(lowerTerm) ||
                    a.Soyad.ToLower().Contains(lowerTerm) ||
                    (a.TCKN != null && a.TCKN.Contains(lowerTerm))
                ).ToList();
            }

            var pagedAvukatlar = avukatlar.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.TotalPages = (int)System.Math.Ceiling(avukatlar.Count / (double)pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.SearchTerm = searchTerm;

            return View(pagedAvukatlar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Avukat());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Avukat avukat)
        {
            if (ModelState.IsValid)
            {
                _avukatYonetim.Ekle(avukat);
                return RedirectToAction(nameof(Index));
            }
            return View(avukat);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.KullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");

            var avukat = _avukatYonetim.IdyeGoreGetir(id);
            if (avukat == null)
            {
                return NotFound();
            }
            return View(avukat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Avukat avukat)
        {
            if (id != avukat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _avukatYonetim.Guncelle(avukat);
                return RedirectToAction(nameof(Index));
            }
            return View(avukat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _avukatYonetim.Sil(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
