using HTYS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HTYS.DataAccessLayer
{
    public class IhtarIslem
    {
        private readonly HTYSDbContext _context;
        public IhtarIslem(HTYSDbContext context) { _context = context; }

        public List<Ihtar> HepsiniGetir()
        {
            return _context.Ihtarlar.Include(i => i.Borclu).Include(i => i.Urun).ToList();
        }
        public Ihtar IdyeGoreGetir(int id)
        {
            return _context.Ihtarlar.Include(i => i.Borclu).Include(i => i.Urun).FirstOrDefault(i => i.Id == id);
        }
        public void Ekle(Ihtar ihtar)
        {
            _context.Ihtarlar.Add(ihtar);
            _context.SaveChanges();
        }
        public void Guncelle(Ihtar ihtar)
        {
            _context.Ihtarlar.Update(ihtar);
            _context.SaveChanges();
        }
        public void Sil(int id)
        {
            var ihtar = _context.Ihtarlar.Find(id);
            if (ihtar != null)
            {
                _context.Ihtarlar.Remove(ihtar);
                _context.SaveChanges();
            }
        }
        public int IhtarSayisiGetir()
        {
            return _context.Ihtarlar.Count();
        }
        public int AvukataGoreIhtarSayisiGetir(int avukatId)
        {
            return _context.Ihtarlar
                           .Include(i => i.Urun)
                           .Count(i => i.Urun.AvukatId == avukatId);
        }
        public List<Ihtar> AvukataGoreGetir(int avukatId)
        {
            return _context.Ihtarlar
                           .Include(i => i.Borclu)
                           .Include(i => i.Urun)
                           .Where(i => i.Urun.AvukatId == avukatId)
                           .ToList();
        }

    }
}
