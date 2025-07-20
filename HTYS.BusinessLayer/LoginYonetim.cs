using HTYS.DataAccessLayer;
using HTYS.Entities;

namespace HTYS.BusinessLayer
{
    public class LoginYonetim
    {
        private readonly LoginIslem _loginIslem;
        public LoginYonetim(LoginIslem loginIslem)
        {
            _loginIslem = loginIslem;
        }

        public LoginAccount? KullaniciyiDogrula(string kullaniciAdi, string sifre)
        {
            var kullanici = _loginIslem.KullaniciGetir(kullaniciAdi);
            if (kullanici == null)
            {
                return null;
            }

            if (SifreGuvenlik.SifreDogrula(sifre, kullanici.Sifre))
            {
                return kullanici;
            }

            return null;
        }
        public bool KullaniciOlustur(string kullaniciAdi, string sifre, string kullaniciTipi)
        {
            if (_loginIslem.KullaniciGetir(kullaniciAdi) != null)
            {
                return false;
            }

            var yeniKullanici = new LoginAccount
            {
                KullaniciAdi = kullaniciAdi,
                Sifre = SifreGuvenlik.HashSifre(sifre),
                KullaniciTipi = kullaniciTipi
            };

            _loginIslem.Ekle(yeniKullanici);
            return true;
        }
    }
}
