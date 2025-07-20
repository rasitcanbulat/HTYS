using HTYS.DataAccessLayer;
using HTYS.Entities;
using System.Collections.Generic;

namespace HTYS.BusinessLayer
{
    public class UrunYonetim
    {
        private readonly UrunIslem _urunIslem;
        public UrunYonetim(UrunIslem urunIslem) { _urunIslem = urunIslem; }
        public List<Urun> HepsiniGetir() => _urunIslem.HepsiniGetir();
        public Urun IdyeGoreGetir(int id) => _urunIslem.IdyeGoreGetir(id);
        public void Ekle(Urun urun) => _urunIslem.Ekle(urun);
        public void Guncelle(Urun urun) => _urunIslem.Guncelle(urun);
        public void Sil(int id) => _urunIslem.Sil(id);
        public int UrunSayisiGetir() => _urunIslem.UrunSayisiGetir();
        public int AvukataGoreMusteriSayisiGetir(int avukatId) => _urunIslem.AvukataGoreMusteriSayisiGetir(avukatId);

    }
}
