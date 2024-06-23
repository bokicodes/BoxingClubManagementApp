using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Dodela : IDomenskiObjekat
    {
        public Trener Trener { get; set; }
        public Takmicar Takmicar { get; set; }

        public string NazivTabele => "Dodela";

        public string VrednostiZaUneti => $"{Takmicar.TakmicarId}, {Trener.TrenerId}";

        public string Joinovanje => $"d join takmicar t on d.Takmicar = t.TakmicarId join " +
            $"kategorija k on t.Kategorija = k.KategorijaId join StarosnaKategorija sk on " +
            $"t.StKategorija = sk.StKategorijaId join trener tr on d.Trener = tr.TrenerId " +
            $"join grad g on tr.Grad = g.GradId order by tr.Ime asc";

        public string VrednostiZaIzmenu => throw new NotImplementedException();

        public string BrisanjePoKoloni => $"Takmicar={Takmicar.TakmicarId} AND Trener={Trener.TrenerId}";

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            Takmicar takmicar = new Takmicar
            {
                TakmicarId = (int)reader["TakmicarId"],
                Ime = (string)reader[3],
                Prezime = (string)reader[4],
                Tezina = (int)reader["Tezina"],
                DatRodj = (DateTime)reader["DatRodj"],
                Kategorija = new Kategorija
                {
                    KategorijaId = (int)reader["KategorijaId"],
                    Naziv = (string)reader[10]
                },
                StKategorija = new StarosnaKategorija
                {
                    StKategorijaId = (int)reader["StKategorijaId"],
                    Naziv = (string)reader[12]
                },
            };

            Trener trener = new Trener
            {
                TrenerId = (int)reader["TrenerId"],
                Ime = (string)reader[14],
                Prezime = (string)reader[15],
                Grad = new Grad
                {
                    GradId = (int)reader["GradId"],
                    Naziv = (string)reader[18],
                    PostanskiBroj = (string)reader["PostanskiBroj"]
                }
            };

            Dodela d = new Dodela
            {
                Takmicar = takmicar,
                Trener = trener
            };

            return d;
        }
    }
}
