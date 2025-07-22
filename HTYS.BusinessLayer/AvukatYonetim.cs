using HTYS.DataAccessLayer;
using HTYS.Entities;

namespace HTYS.BusinessLayer
{
    public class AvukatYonetim
    {
        private readonly AvukatIslem _avukatIslem;
        public AvukatYonetim(AvukatIslem avukatIslem)

        {
            _avukatIslem = avukatIslem;
        }
        public void Ekle(Avukat avukat)
        {
            _avukatIslem.Ekle(avukat);
        }
        public void Guncelle(Avukat avukat)
        {
            _avukatIslem.Guncelle(avukat);
        }
        public void Sil(int id)
        {
            _avukatIslem.Sil(id);
        }
        public Avukat? IdyeGoreGetir(int id)
        {
            return _avukatIslem.IdyeGoreGetir(id);
        }
        public List<Avukat> HepsiniGetir()
        {
            return _avukatIslem.HepsiniGetir();
        }

        public int ToplamAvukatSayisiGetir()
        {
            return _avukatIslem.ToplamAvukatSayisiGetir();
        }
        public Avukat? KullaniciAdinaGoreGetir(string kullaniciAdi)
        {
            return _avukatIslem.KullaniciAdinaGoreGetir(kullaniciAdi);
        }
    }
}
