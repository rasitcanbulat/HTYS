using HTYS.BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace HTYS.WebUI.Controllers
{
    public class AdresController : Controller
    {
        private readonly AdresYonetim _adresYonetim;

        public AdresController(AdresYonetim adresYonetim)
        {
            _adresYonetim = adresYonetim;
        }

        [HttpGet]
        public async Task<JsonResult> GetIller()
        {
            var iller = await _adresYonetim.GetIllerAsync();
            return Json(iller);
        }

        [HttpGet]
        public async Task<JsonResult> GetIlceler(int ilId)
        {
            var ilceler = await _adresYonetim.GetIlcelerByIlIdAsync(ilId);
            return Json(ilceler);
        }
    }
}