using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class UcitajListuStKategorijaSO : SOBase
    {
        public List<StarosnaKategorija> ListaStarosnihKategorija { get; private set; }
        protected override void Execute()
        {
            ListaStarosnihKategorija =  broker.UcitajListuStKategorija();
        }
    }
}
