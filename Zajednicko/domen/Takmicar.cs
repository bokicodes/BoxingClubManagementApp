using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    public class Takmicar
    {
        public int TakmicarId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Tezina { get; set; }
        public DateTime DatRodj { get; set; }
        public Kategorija Kategorija { get; set; }
        public StarosnaKategorija StKategorija { get; set; }
        public List<Dodela> ListaDodela { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
