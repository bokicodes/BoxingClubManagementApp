using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    public class Trener
    {
        public int TrenerId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Grad Grad { get; set; }
        public List<Dodela> ListaDodela { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
