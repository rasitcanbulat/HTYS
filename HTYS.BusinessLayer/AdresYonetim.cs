using HTYS.DataAccessLayer;
using HTYS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTYS.BusinessLayer
{
    public class AdresYonetim
    {
        private readonly AdresIslem _adresIslem;

        public AdresYonetim(AdresIslem adresIslem)
        {
            _adresIslem = adresIslem;
        }

        public async Task<List<Il>> GetIllerAsync()
        {
            return await _adresIslem.GetIllerAsync();
        }

        public async Task<List<Ilce>> GetIlcelerByIlIdAsync(int ilId)
        {
            return await _adresIslem.GetIlcelerByIlIdAsync(ilId);
        }

        public async Task<List<Semt>> GetSemtlerByIlceIdAsync(int ilceId)
        {
            return await _adresIslem.GetSemtlerByIlceIdAsync(ilceId);
        }
    }
}