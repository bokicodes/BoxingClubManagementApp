using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class UcitajListuTakmicaraSO : SOBase
    {
        public List<Takmicar> ListaTakmicara { get; private set; }
        protected override void Execute()
        {
            ListaTakmicara = broker.UcitajListuTakmicara();
        }
    }
}
