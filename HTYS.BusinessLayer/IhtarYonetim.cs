using HTYS.DataAccessLayer;
using HTYS.Entities;
using System.Collections.Generic;

namespace HTYS.BusinessLayer
{
    public class IhtarYonetim
    {
        private readonly IhtarIslem _ihtarIslem;
        public IhtarYonetim(IhtarIslem ihtarIslem) { _ihtarIslem = ihtarIslem; }

        public List<Ihtar> HepsiniGetir() => _ihtarIslem.HepsiniGetir();
        public Ihtar IdyeGoreGetir(int id) => _ihtarIslem.IdyeGoreGetir(id);
        public void Ekle(Ihtar ihtar) => _ihtarIslem.Ekle(ihtar);
        public void Guncelle(Ihtar ihtar) => _ihtarIslem.Guncelle(ihtar);
        public void Sil(int id) => _ihtarIslem.Sil(id);
        public int IhtarSayisiGetir() => _ihtarIslem.IhtarSayisiGetir();
        public int AvukataGoreIhtarSayisiGetir(int avukatId) => _ihtarIslem.AvukataGoreIhtarSayisiGetir(avukatId);
        public List<Ihtar> AvukataGoreGetir(int avukatId)
        {
            return _ihtarIslem.AvukataGoreGetir(avukatId);
        }


    }
}
