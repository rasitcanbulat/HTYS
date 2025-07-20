using HTYS.DataAccessLayer;
using HTYS.Entities;
using System.Collections.Generic;

namespace HTYS.BusinessLayer
{
    public class MusteriYonetim
    {
        private readonly MusteriIslem _musteriIslem;

        public MusteriYonetim(MusteriIslem musteriIslem)
        {
            _musteriIslem = musteriIslem;
        }
        public void Ekle(Musteri musteri)
        {
            _musteriIslem.Ekle(musteri);
        }
        public void Guncelle(Musteri musteri)
        {
            _musteriIslem.Guncelle(musteri);
        }
        public void Sil(int id)
        {
            _musteriIslem.Sil(id);
        }
        public List<Musteri> HepsiniGetir(string arama, int sayfa, int sayfaBasiKayit)
        {
            return _musteriIslem.HepsiniGetir(arama, sayfa, sayfaBasiKayit);
        }
        public int MusteriSayisiGetir(string arama)
        {
            return _musteriIslem.MusteriSayisiGetir(arama);
        }
        public Musteri? IdyeGoreGetir(int id)
        {
            return _musteriIslem.IdyeGoreGetir(id);
        }
        public List<Musteri> HepsiniGetirListe()
        {
            return _musteriIslem.HepsiniGetirListe();
        }
    }
}
