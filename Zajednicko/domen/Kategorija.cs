using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Kategorija : IDomenskiObjekat
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public string NazivTabele => "Kategorija";

        public string VrednostiZaUneti => throw new NotImplementedException();

        public string Joinovanje => string.Empty;

        public string VrednostiZaIzmenu => throw new NotImplementedException();

        public string BrisanjePoKoloni => throw new NotImplementedException();

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            Kategorija k = new Kategorija()
            {
                KategorijaId = (int)reader["KategorijaId"],
                Naziv = (string)reader["Naziv"],
            };

            return k;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
