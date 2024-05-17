using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class StarosnaKategorija : IDomenskiObjekat
    {
        public int StKategorijaId { get; set; }
        public string Naziv { get; set; }

        public string NazivTabele => "StarosnaKategorija";

        public string VrednostiZaUneti => throw new NotImplementedException();

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            StarosnaKategorija sk = new StarosnaKategorija()
            {
                StKategorijaId = (int)reader["StKategorijaId"],
                Naziv = (string)reader["Naziv"]
            };
            return sk;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
