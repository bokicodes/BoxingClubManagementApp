using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class ZapamtiTreneraSO : SOBase
    {
        public readonly Trener t;

        public ZapamtiTreneraSO(Trener t)
        {
            this.t = t;
        }
        protected override void Execute()
        {
            broker.Zapamti(t);
        }
    }
}
