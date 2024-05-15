using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class UcitajListuTreneraSO : SOBase
    {
        public List<Trener> ListaTrenera { get; private set; }
        protected override void Execute()
        {
            ListaTrenera = broker.UcitajListuTrenera();
        }
    }
}
