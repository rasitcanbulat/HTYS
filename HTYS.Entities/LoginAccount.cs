using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTYS.Entities
{
    public class LoginAccount
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; } = string.Empty;
        
        public string Sifre { get; set; } = string.Empty;

        public string KullaniciTipi { get; set; } = string.Empty;


    }
}
