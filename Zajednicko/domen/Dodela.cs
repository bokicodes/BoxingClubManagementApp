using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Dodela
    {
        public Trener Trener { get; set; }
        public Takmicar Takmicar { get; set; }
    }
}
