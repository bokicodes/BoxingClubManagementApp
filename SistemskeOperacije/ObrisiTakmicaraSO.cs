using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class ObrisiTakmicaraSO : SOBase
    {
        private readonly Takmicar t;
        public Takmicar T { get { return t; } set { T = t; }}
        public ObrisiTakmicaraSO(Takmicar t)
        {
            this.t = t;
        }
        protected override void Execute()
        {
            broker.ObrisiTakmicara(t);
        }
    }
}
