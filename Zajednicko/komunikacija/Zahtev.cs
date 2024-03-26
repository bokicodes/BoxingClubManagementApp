using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko
{
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public object ZahtevObject { get; set; }
    }
}
