using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Dodela : IDomenskiObjekat
    {
        public Trener Trener { get; set; }
        public Takmicar Takmicar { get; set; }

        public string NazivTabele => "Dodela";

        public string VrednostiZaUneti => $"{Takmicar.TakmicarId}, {Trener.TrenerId}";
    }
}
