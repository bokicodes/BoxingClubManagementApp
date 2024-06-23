using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class ObrisiSveDodeleSO : SOBase
    {
        protected override void Execute()
        {
            broker.ObrisiSve(new Dodela());
        }
    }
}
