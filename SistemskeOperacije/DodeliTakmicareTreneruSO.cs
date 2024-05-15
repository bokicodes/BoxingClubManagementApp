using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class DodeliTakmicareTreneruSO : SOBase
    {
        private readonly BindingList<Dodela> listaDodela;

        public DodeliTakmicareTreneruSO(BindingList<Dodela> listaDodela)
        {
            this.listaDodela = listaDodela;
        }
        protected override void Execute()
        {
            foreach (Dodela d in listaDodela)
            {
                broker.SacuvajDodelu(d);
            }
        }
    }
}
