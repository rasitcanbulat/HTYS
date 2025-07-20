using System.Security.Cryptography;
using System.Text;

namespace HTYS.BusinessLayer
{
    public static class SifreGuvenlik
    {
        public static string HashSifre(string sifre)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(sifre));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static bool SifreDogrula(string sifre, string hash)
        {
            string yeniHash = HashSifre(sifre);
            return yeniHash == hash;
        }
    }
}
