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

        public string Joinovanje => $"t join grad g on t.Grad = g.GradId";

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            Trener t = new Trener
            {
                TrenerId = (int)reader["TrenerId"],
                Ime = (string)reader["Ime"],
                Prezime = (string)reader["Prezime"],
                Grad = new Grad
                {
                    GradId = (int)reader["GradId"],
                    Naziv = (string)reader["Naziv"],
                    PostanskiBroj = (string)reader["PostanskiBroj"]
                }
            };

            return t;
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
