using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;
using static System.Net.Mime.MediaTypeNames;

namespace SistemskeOperacije
{
    public class NadjiTrenereSO : SOBase
    {
        private readonly string search;

        public List<Trener> ListaPronadjenihTrenera { get; private set; }
        public NadjiTrenereSO(string search)
        {
            this.search = search;
        }
        protected override void Execute()
        {
            ListaPronadjenihTrenera = broker.PretraziTrenere(search);
        }
    }
}
