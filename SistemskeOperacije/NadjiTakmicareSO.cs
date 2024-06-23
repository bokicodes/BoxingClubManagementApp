using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;
using static System.Net.Mime.MediaTypeNames;

namespace SistemskeOperacije
{
    public class NadjiTakmicareSO : SOBase
    {
        private readonly string search;
        public List<Takmicar> ListaPronadjenihTakmicara { get; private set; }

        public NadjiTakmicareSO(string search)
        {
            this.search = search;
        }
        protected override void Execute()
        {
            ListaPronadjenihTakmicara = broker.Pretrazi(new Takmicar(), search).OfType<Takmicar>().ToList();
        }
    }
}
