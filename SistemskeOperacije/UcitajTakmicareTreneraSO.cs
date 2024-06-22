using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class UcitajTakmicareTreneraSO : SOBase
    {
        public List<Dodela> ListaDodela { get; private set; }
        protected override void Execute()
        {
            ListaDodela = broker.UcitajListu(new Dodela()).OfType<Dodela>().ToList();
        }
    }
}
