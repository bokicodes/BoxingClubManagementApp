using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Trener : IDomenskiObjekat
    {
        public int TrenerId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Grad Grad { get; set; }
        public List<Dodela> ListaDodela { get; set; }

        public string NazivTabele => "Trener";

        public string VrednostiZaUneti => $"'{Ime}', '{Prezime}', {Grad.GradId}";

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
