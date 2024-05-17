using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Grad : IDomenskiObjekat
    {
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public string NazivTabele => "Grad";

        public string VrednostiZaUneti => throw new NotImplementedException();

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            Grad grad = new Grad()
            {
                GradId = (int)reader["GradId"],
                Naziv = (string)reader["Naziv"],
                PostanskiBroj = (string)reader["PostanskiBroj"]
            };
            return grad;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
