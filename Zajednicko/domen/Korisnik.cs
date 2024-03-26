using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}
