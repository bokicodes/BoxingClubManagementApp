using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class ZapamtiTakmicaraSO : SOBase
    {
        public readonly Takmicar t;

        public ZapamtiTakmicaraSO(Takmicar t)
        {
            this.t = t;
        }
        protected override void Execute()
        {
            broker.ZapamtiTakmicara(t);
        }
    }
}
