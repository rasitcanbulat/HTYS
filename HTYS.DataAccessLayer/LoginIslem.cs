using HTYS.Entities;

namespace HTYS.DataAccessLayer
{
    public class LoginIslem
    {
        private readonly HTYSDbContext _context;
        public LoginIslem(HTYSDbContext context)
        {
            _context = context;
        }

        public void Ekle(LoginAccount account)
        {
            _context.LoginAccounts.Add(account);
            _context.SaveChanges();
        }

        public LoginAccount? KullaniciGetir(string kullaniciAdi)
        {
            return _context.LoginAccounts.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi);
        }
    }
}
