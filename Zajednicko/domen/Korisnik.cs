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

        public string Joinovanje => throw new NotImplementedException();

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
