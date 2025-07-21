using HTYS.BusinessLayer;
using HTYS.Entities;
using HTYS.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace HTYS.WebUI.Controllers
{
    [AuthenticationFilter]
    public class IcraTakipController : Controller
    {
        private readonly IcraTakipYonetim _icraTakipYonetim;
        private readonly MusteriYonetim _musteriYonetim;
        private readonly AvukatYonetim _avukatYonetim;
        private readonly IhtarYonetim _ihtarYonetim;
        private readonly UrunYonetim _urunYonetim;

        public IcraTakipController(IcraTakipYonetim icraTakipYonetim, MusteriYonetim musteriYonetim, AvukatYonetim avukatYonetim, UrunYonetim urunYonetim, IhtarYonetim ihtarYonetim)
        {
            _icraTakipYonetim = icraTakipYonetim;
            _musteriYonetim = musteriYonetim;
            _avukatYonetim = avukatYonetim;
            _urunYonetim = urunYonetim;
            _ihtarYonetim = ihtarYonetim;
        }

        public IActionResult Index()
        {
            ViewBag.KullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            var model = _icraTakipYonetim.HepsiniGetir();
            return View(model);
        }

        private void PopulateDropdowns(IcraTakip? model = null)
        {
            var musteriler = _musteriYonetim.HepsiniGetirListe()
                .Select(m => new { Id = m.Id, DisplayText = $"{m.Ad} {m.Soyad} (TCKN: {m.TCKN})" });
            var avukatlar = _avukatYonetim.HepsiniGetir()
                .Select(a => new { Id = a.Id, DisplayText = $"{a.Ad} {a.Soyad} (TCKN: {a.TCKN})" });

            ViewBag.Musteriler = new SelectList(musteriler, "Id", "DisplayText", model?.MusteriId);
            ViewBag.Avukatlar = new SelectList(avukatlar, "Id", "DisplayText", model?.AvukatId);

            if (model?.MusteriId > 0)
            {
                ViewBag.Urunler = new SelectList(_urunYonetim.HepsiniGetir().Where(u => u.MusteriId == model.MusteriId), "Id", "UrunAdi", model.UrunId);
                ViewBag.Ihtarlar = new SelectList(_ihtarYonetim.HepsiniGetir().Where(i => i.MusteriId == model.MusteriId), "Id", "IhtarNo", model.IhtarId);
            }
        }

        public IActionResult Create()
        {
            ViewBag.KullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            PopulateDropdowns();
            var model = new IcraTakip { TakipTarihi = DateTime.Now };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IcraTakip icraTakip)
        {
            if (ModelState.IsValid)
            {
                _icraTakipYonetim.Ekle(icraTakip);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.KullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            PopulateDropdowns(icraTakip);
            return View(icraTakip);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.KullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            var icraTakip = _icraTakipYonetim.IdyeGoreGetir(id);
            if (icraTakip == null) return NotFound();

            PopulateDropdowns(icraTakip);
            return View(icraTakip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IcraTakip icraTakip)
        {
            if (id != icraTakip.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _icraTakipYonetim.Guncelle(icraTakip);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.KullaniciAdi = HttpContext.Session.GetString("KullaniciAdi");
            PopulateDropdowns(icraTakip);
            return View(icraTakip);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _icraTakipYonetim.Sil(id);
            return RedirectToAction(nameof(Index));
        }

        // --- API Endpoints ---
        [HttpGet]
        public JsonResult GetAvukatInfo(int avukatId)
        {
            var avukat = _avukatYonetim.IdyeGoreGetir(avukatId);
            if (avukat == null) return Json(null);
            return Json(new { tckn = avukat.TCKN });
        }

        [HttpGet]
        public JsonResult GetIhtarlarByMusteriId(int musteriId)
        {
            var ihtarlar = _ihtarYonetim.HepsiniGetir()
                .Where(i => i.MusteriId == musteriId)
                .Select(i => new { i.Id, i.IhtarNo });
            return Json(ihtarlar);
        }

        [HttpGet]
        public JsonResult GetUrunlerByMusteriId(int musteriId)
        {
            var urunler = _urunYonetim.HepsiniGetir()
                                     .Where(u => u.MusteriId == musteriId)
                                     .Select(u => new { u.Id, u.UrunAdi });
            return Json(urunler);
        }
    }
}
