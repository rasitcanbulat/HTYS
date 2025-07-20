using HTYS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HTYS.DataAccessLayer
{
    public class IcraTakipIslem
    {
        private readonly HTYSDbContext _context;
        public IcraTakipIslem(HTYSDbContext context) { _context = context; }
        public List<IcraTakip> HepsiniGetir()
        {
            return _context.IcraTakipleri
                .Include(i => i.Borclu)
                .Include(i => i.Avukat)
                .ToList();
        }
        public IcraTakip IdyeGoreGetir(int id)
        {
            return _context.IcraTakipleri.FirstOrDefault(i => i.Id == id);
        }
        public void Ekle(IcraTakip icraTakip)
        {
            _context.IcraTakipleri.Add(icraTakip);
            _context.SaveChanges();
        }
        public void Guncelle(IcraTakip icraTakip)
        {
            _context.IcraTakipleri.Update(icraTakip);
            _context.SaveChanges();
        }
        public void Sil(int id)
        {
            var icraTakip = _context.IcraTakipleri.Find(id);
            if (icraTakip != null)
            {
                _context.IcraTakipleri.Remove(icraTakip);
                _context.SaveChanges();
            }
        }
        public int IcraSayisiGetir()
        {
            return _context.IcraTakipleri.Count();
        }
        public int AvukataGoreIcraSayisiGetir(int avukatId)
        {
            return _context.IcraTakipleri.Count(i => i.AvukatId == avukatId);
        }
        public List<IcraTakip> AvukataGoreGetir(int avukatId)
        {
            return _context.IcraTakipleri
                           .Include(i => i.Borclu)
                           .Include(i => i.Avukat)
                           .Where(i => i.AvukatId == avukatId)
                           .ToList();
        }
    }
}
