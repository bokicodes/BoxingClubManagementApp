using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class ObrisiDodeluSO : SOBase
    {
        private readonly Dodela d;

        public ObrisiDodeluSO(Dodela d)
        {
            this.d = d;
        }
        protected override void Execute()
        {
            broker.ObrisiDodelu(d);
        }
    }
}
