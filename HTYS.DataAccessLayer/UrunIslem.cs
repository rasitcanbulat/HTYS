using HTYS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HTYS.DataAccessLayer
{
    public class UrunIslem
    {
        private readonly HTYSDbContext _context;
        public UrunIslem(HTYSDbContext context) { _context = context; }

        public List<Urun> HepsiniGetir()
        {
            return _context.Urunler.Include(u => u.Borclu).Include(u => u.Avukat).ToList();
        }

        public Urun IdyeGoreGetir(int id)
        {
            return _context.Urunler.Include(u => u.Borclu).Include(u => u.Avukat).FirstOrDefault(u => u.Id == id);
        }

        public void Ekle(Urun urun)
        {
            _context.Urunler.Add(urun);
            _context.SaveChanges();
        }

        public void Guncelle(Urun urun)
        {
            _context.Urunler.Update(urun);
            _context.SaveChanges();
        }

        public void Sil(int id)
        {
            var urun = _context.Urunler.Find(id);
            if (urun != null)
            {
                _context.Urunler.Remove(urun);
                _context.SaveChanges();
            }
        }

        public int UrunSayisiGetir()
        {
            return _context.Urunler.Count();
        }
        public int AvukataGoreMusteriSayisiGetir(int avukatId)
        {
            return _context.Urunler
                           .Where(u => u.AvukatId == avukatId)
                           .Select(u => u.MusteriId)
                           .Distinct()
                           .Count();
        }
    }
}