using HTYS.Entities;

namespace HTYS.DataAccessLayer
{
    public class MusteriIslem
    {
        private readonly HTYSDbContext _context;
        public MusteriIslem(HTYSDbContext context)
        {
            _context = context;
        }

        public void Ekle(Musteri musteri) { _context.Musteriler.Add(musteri); _context.SaveChanges(); }
        public void Guncelle(Musteri musteri) { _context.Musteriler.Update(musteri); _context.SaveChanges(); }

        public void Sil(int id)
        {
            var musteri = _context.Musteriler.Find(id);
            if (musteri != null)
            {
                musteri.AktifMi = false;
                _context.Musteriler.Update(musteri);
                _context.SaveChanges();
            }
        }

        public Musteri? IdyeGoreGetir(int id) { return _context.Musteriler.FirstOrDefault(m => m.Id == id); }

        public List<Musteri> HepsiniGetir(string arama, int sayfa, int sayfaBasiKayit)
        {
            var query = _context.Musteriler.Where(m => m.AktifMi).AsQueryable();
            if (!string.IsNullOrEmpty(arama))
            {
                query = query.Where(m => m.Ad.Contains(arama) || m.Soyad.Contains(arama));
            }
            return query.Skip((sayfa - 1) * sayfaBasiKayit).Take(sayfaBasiKayit).ToList();
        }
        public int MusteriSayisiGetir(string arama)
        {
            var query = _context.Musteriler.Where(m => m.AktifMi).AsQueryable();
            if (!string.IsNullOrEmpty(arama))
            {
                query = query.Where(m => m.Ad.Contains(arama) || m.Soyad.Contains(arama));
            }
            return query.Count();
        }

        public List<Musteri> HepsiniGetirListe()
        {
            return _context.Musteriler.Where(m => m.AktifMi).OrderBy(m => m.Ad).ThenBy(m => m.Soyad).ToList();
        }

        public (int UrunSayisi, int IhtarSayisi, int IcraSayisi) MusteriBaglantiKontrol(int musteriId)
        {
            var urunSayisi = _context.Urunler.Count(u => u.MusteriId == musteriId);
            var ihtarSayisi = _context.Ihtarlar.Count(i => i.MusteriId == musteriId);
            var icraSayisi = _context.IcraTakipleri.Count(it => it.MusteriId == musteriId);
            return (urunSayisi, ihtarSayisi, icraSayisi);
        }
    }
}
