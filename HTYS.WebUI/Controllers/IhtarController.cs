using HTYS.BusinessLayer;
using HTYS.Entities;
using HTYS.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HTYS.WebUI.Controllers
{
    [AuthenticationFilter]
    public class IhtarController : Controller
    {
        private readonly IhtarYonetim _ihtarYonetim;
        private readonly MusteriYonetim _musteriYonetim;
        private readonly UrunYonetim _urunYonetim;

        public IhtarController(IhtarYonetim ihtarYonetim, MusteriYonetim musteriYonetim, UrunYonetim urunYonetim)
        {
            _ihtarYonetim = ihtarYonetim;
            _musteriYonetim = musteriYonetim;
            _urunYonetim = urunYonetim;
        }

        public IActionResult Index()
        {
            var model = _ihtarYonetim.HepsiniGetir();
            return View(model);
        }

        private void PopulateMusteriDropdown(object selectedMusteri = null)
        {
            var musteriler = _musteriYonetim.HepsiniGetirListe()
                .Select(m => new { Id = m.Id, TamAd = $"{m.Ad} {m.Soyad} (TCKN: {m.TCKN})" });
            ViewBag.Musteriler = new SelectList(musteriler, "Id", "TamAd", selectedMusteri);
        }

        public IActionResult Create()
        {
            PopulateMusteriDropdown();
            var model = new Ihtar { IhtarTarihi = DateTime.Now };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ihtar ihtar)
        {
            if (ModelState.IsValid)
            {
                _ihtarYonetim.Ekle(ihtar);
                return RedirectToAction(nameof(Index));
            }
            PopulateMusteriDropdown(ihtar.MusteriId);
            return View(ihtar);
        }

        public IActionResult Edit(int id)
        {
            var ihtar = _ihtarYonetim.IdyeGoreGetir(id);
            if (ihtar == null)
            {
                return NotFound();
            }
            PopulateMusteriDropdown(ihtar.MusteriId);
            ViewBag.Urunler = new SelectList(_urunYonetim.HepsiniGetir().Where(u => u.MusteriId == ihtar.MusteriId), "Id", "UrunAdi", ihtar.UrunId);
            return View(ihtar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ihtar ihtar)
        {
            if (id != ihtar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _ihtarYonetim.Guncelle(ihtar);
                return RedirectToAction(nameof(Index));
            }
            PopulateMusteriDropdown(ihtar.MusteriId);
            ViewBag.Urunler = new SelectList(_urunYonetim.HepsiniGetir().Where(u => u.MusteriId == ihtar.MusteriId), "Id", "UrunAdi", ihtar.UrunId);
            return View(ihtar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ihtarYonetim.Sil(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public JsonResult GetUrunlerByMusteriId(int musteriId)
        {
            var urunler = _urunYonetim.HepsiniGetir()
                                     .Where(u => u.MusteriId == musteriId)
                                     .Select(u => new { u.Id, u.UrunAdi });
            return Json(urunler);
        }

        [HttpGet]
        public JsonResult GetMusteriInfo(int musteriId)
        {
            var musteri = _musteriYonetim.IdyeGoreGetir(musteriId);
            if (musteri == null)
            {
                return Json(null);
            }
            return Json(new { noterAdi = musteri.VergiDairesi });
        }
    }
}
