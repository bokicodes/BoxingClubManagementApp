using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class UcitajListuKorisnikaSO : SOBase
    {
        public List<Korisnik> ListaKorisnika { get; private set; }
        protected override void Execute()
        {
            ListaKorisnika = broker.VratiListuKorisnika();
        }
    }
}
