using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class IzmeniTreneraSO : SOBase
    {
        private readonly Trener t;
        public Trener T 
        {
            get 
            {
                return t;
            }
            set 
            {
                T = t;
            }
        }

        public IzmeniTreneraSO(Trener t)
        {
            this.t = t;
        }
        protected override void Execute()
        {
            broker.IzmeniTrenera(t);
        }
    }
}
