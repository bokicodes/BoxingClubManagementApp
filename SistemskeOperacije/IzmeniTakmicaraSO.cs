using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class IzmeniTakmicaraSO : SOBase
    {
        public readonly Takmicar t;

        public IzmeniTakmicaraSO(Takmicar t)
        {
            this.t = t;
        }
        protected override void Execute()
        {
            broker.IzmeniTakmicara(t);
        }
    }
}
