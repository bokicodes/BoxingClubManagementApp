using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    public interface IDomenskiObjekat
    {
        string NazivTabele { get; }
        string VrednostiZaUneti { get; }
        string Joinovanje { get; }
        string VrednostiZaIzmenu { get; }
        string BrisanjePoKoloni { get; }

        IDomenskiObjekat KreirajObjekat(SqlDataReader reader);
    }
}
