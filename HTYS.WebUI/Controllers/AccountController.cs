using HTYS.BusinessLayer;
using HTYS.Entities;
using HTYS.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;

namespace HTYS.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginYonetim _loginYonetim;
        private readonly AvukatYonetim _avukatYonetim;
        private const string CaptchaSessionKey = "CaptchaCode";

        public AccountController(LoginYonetim loginYonetim, AvukatYonetim avukatYonetim)
        {
            _loginYonetim = loginYonetim;
            _avukatYonetim = avukatYonetim;
        }

        [HttpGet]
        public IActionResult CaptchaImage()
        {
            var code = GenerateCaptchaCode();
            HttpContext.Session.SetString(CaptchaSessionKey, code);

#pragma warning disable CA1416
            var bmp = new Bitmap(200, 60);
            var gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.FromArgb(240, 240, 240));
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            gfx.TextRenderingHint = TextRenderingHint.AntiAlias;

            var font = new Font("Arial", 30, FontStyle.Bold | FontStyle.Italic);
            gfx.DrawString(code, font, Brushes.DarkSlateGray, new PointF(10, 5));

            var random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x1 = random.Next(bmp.Width);
                int y1 = random.Next(bmp.Height);
                int x2 = random.Next(bmp.Width);
                int y2 = random.Next(bmp.Height);
                gfx.DrawLine(new Pen(Color.Gray), x1, y1, x2, y2);
            }

            using (var memStream = new MemoryStream())
            {
                bmp.Save(memStream, ImageFormat.Png);
                return File(memStream.ToArray(), "image/png");
            }
#pragma warning restore CA1416
        }

        private string GenerateCaptchaCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpGet]
        public IActionResult Register(string kullaniciTipi)
        {
            if (string.IsNullOrEmpty(kullaniciTipi) || kullaniciTipi != "Bankaci")
            {
                return RedirectToAction("Login");
            }
            var model = new RegisterViewModel { KullaniciTipi = kullaniciTipi };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            var sessionCaptcha = HttpContext.Session.GetString(CaptchaSessionKey);

            if (sessionCaptcha == null || model.CaptchaCode != sessionCaptcha)
            {
                ModelState.AddModelError("CaptchaCode", "Doğrulama kodu hatalı.");
            }

            if (model.KullaniciTipi != "Bankaci")
            {
                ModelState.AddModelError("", "Bu kullanıcı tipi için kayıt işlemi yapılamaz.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var sonuc = _loginYonetim.KullaniciOlustur(model.KullaniciAdi, model.Sifre, model.KullaniciTipi);
                if (sonuc)
                {
                    return RedirectToAction("Login", new { message = "Kaydınız başarıyla oluşturuldu. Giriş yapabilirsiniz." });
                }
                else
                {
                    ModelState.AddModelError("KullaniciAdi", "Bu kullanıcı adı zaten alınmış.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? message)
        {
            HttpContext.Session.Clear();
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.SuccessMessage = message;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var kullanici = _loginYonetim.KullaniciyiDogrula(model.KullaniciAdi, model.Sifre);
                if (kullanici != null)
                {
                    HttpContext.Session.SetString("KullaniciAdi", kullanici.KullaniciAdi);
                    HttpContext.Session.SetString("KullaniciTipi", kullanici.KullaniciTipi);

                    if (kullanici.KullaniciTipi == "Bankaci")
                    {
                        return RedirectToAction("Index", "BankaPanel");
                    }
                    else if (kullanici.KullaniciTipi == "Avukat")
                    {
                        return RedirectToAction("Index", "AvukatPanel");
                    }
                }
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            ViewData["ActiveForm"] = model.KullaniciTipi;
            return View(model);
        }
    }
}
