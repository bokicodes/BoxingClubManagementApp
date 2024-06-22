using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class UcitajListuKategorijaSO : SOBase
    {
        public List<Kategorija> ListaKategorija { get; private set; }
        protected override void Execute()
        {
            ListaKategorija = broker.UcitajListuKategorija();
        }
    }
}
