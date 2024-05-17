using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Korisnik : IDomenskiObjekat
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public string NazivTabele => "Korisnik";

        public string VrednostiZaUneti => throw new NotImplementedException();

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            Korisnik k = new Korisnik
            {
                KorisnickoIme = (string)reader["KorisnickoIme"],
                Lozinka = (string)reader["Lozinka"]
            };
            return k;
        }
    }
}
