using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class LoginSO : SOBase
    {
        private readonly Korisnik k;
        public Korisnik K { get; set; }
        public LoginSO(Korisnik k)
        {
            this.k = k;
        }
        protected override void Execute()
        {
            K = broker.Login(k);
        }
    }
}
