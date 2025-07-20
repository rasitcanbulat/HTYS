using HTYS.DataAccessLayer;
using HTYS.Entities;
using System.Collections.Generic;

namespace HTYS.BusinessLayer
{
    public class IcraTakipYonetim
    {
        private readonly IcraTakipIslem _icraTakipIslem;
        public IcraTakipYonetim(IcraTakipIslem icraTakipIslem) { _icraTakipIslem = icraTakipIslem; }

        public List<IcraTakip> HepsiniGetir() => _icraTakipIslem.HepsiniGetir();
        public IcraTakip IdyeGoreGetir(int id) => _icraTakipIslem.IdyeGoreGetir(id);
        public void Ekle(IcraTakip icraTakip) => _icraTakipIslem.Ekle(icraTakip);
        public void Guncelle(IcraTakip icraTakip) => _icraTakipIslem.Guncelle(icraTakip);
        public void Sil(int id) => _icraTakipIslem.Sil(id);
        public int IcraSayisiGetir() => _icraTakipIslem.IcraSayisiGetir();
        public int AvukataGoreIcraSayisiGetir(int avukatId) => _icraTakipIslem.AvukataGoreIcraSayisiGetir(avukatId);
        public List<IcraTakip> AvukataGoreGetir(int avukatId)
        {
            return _icraTakipIslem.AvukataGoreGetir(avukatId);
        }

    }
}
