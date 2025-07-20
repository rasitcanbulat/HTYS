using HTYS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HTYS.DataAccessLayer
{
    public class AvukatIslem
    {
        private readonly HTYSDbContext _context;
        public AvukatIslem(HTYSDbContext context)
        {
            _context = context;
        }
        public void Ekle(Avukat avukat)
        {
            _context.Avukatlar.Add(avukat); _context.SaveChanges();
        }
        public void Guncelle(Avukat avukat)
        {
            _context.Avukatlar.Update(avukat); _context.SaveChanges();
        }
        public void Sil(int id)
        {
            var avukat = _context.Avukatlar.Find(id); if (avukat != null)
            {
                _context.Avukatlar.Remove(avukat); _context.SaveChanges();
            }
        }
        public Avukat? IdyeGoreGetir(int id)
        {
            return _context.Avukatlar.FirstOrDefault(a => a.Id == id);
        }
        public List<Avukat> HepsiniGetir()
        {
            return _context.Avukatlar.ToList();
        }

        public int ToplamAvukatSayisiGetir()
        {
            return _context.Avukatlar.Count();
        }
        public Avukat? KullaniciAdinaGoreGetir(string kullaniciAdi)
        {
            return _context.Avukatlar.FirstOrDefault(a => a.KullaniciAdi == kullaniciAdi);
        }
    }
}
