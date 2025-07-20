using HTYS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTYS.DataAccessLayer
{
    public class AdresIslem
    {
        private readonly HTYSDbContext _context;

        public AdresIslem(HTYSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Il>> GetIllerAsync()
        {
            return await _context.Iller.OrderBy(i => i.Ad).ToListAsync();
        }

        public async Task<List<Ilce>> GetIlcelerByIlIdAsync(int ilId)
        {
            return await _context.Ilceler.Where(i => i.IlId == ilId).OrderBy(i => i.Ad).ToListAsync();
        }

        public async Task<List<Semt>> GetSemtlerByIlceIdAsync(int ilceId)
        {
            return await _context.Semtler.Where(s => s.IlceId == ilceId).OrderBy(s => s.Ad).ToListAsync();
        }
    }
}