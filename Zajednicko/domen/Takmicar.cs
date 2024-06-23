using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.domen
{
    [Serializable]
    public class Takmicar : IDomenskiObjekat
    {
        public int TakmicarId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Tezina { get; set; }
        public DateTime DatRodj { get; set; }
        public Kategorija Kategorija { get; set; }
        public StarosnaKategorija StKategorija { get; set; }
        public List<Dodela> ListaDodela { get; set; }

        public string NazivTabele => "Takmicar";

        public string VrednostiZaUneti => $"'{Ime}', '{Prezime}', {Tezina}, '{DatRodj}'," +
            $"{Kategorija.KategorijaId}, {StKategorija.StKategorijaId}";

        public string Joinovanje => $"t join " +
                $"Kategorija k on (t.Kategorija = k.KategorijaId) " +
                $"join StarosnaKategorija sk on (t.StKategorija = sk.StKategorijaId)";

        public string VrednostiZaIzmenu => $"ime='{Ime}',prezime='{Prezime}'," +
                $"tezina={Tezina},DatRodj='{DatRodj}',Kategorija={Kategorija.KategorijaId}," +
                $"StKategorija={StKategorija.StKategorijaId} where TakmicarId={TakmicarId}";

        public string BrisanjePoKoloni => $"TakmicarId={TakmicarId}";

        public IDomenskiObjekat KreirajObjekat(SqlDataReader reader)
        {
            Takmicar t = new Takmicar
            {
                TakmicarId = (int)reader["TakmicarId"],
                Ime = (string)reader["Ime"],
                Prezime = (string)reader["Prezime"],
                Tezina = (int)reader["Tezina"],
                DatRodj = (DateTime)reader["DatRodj"],
                Kategorija = new Kategorija
                {
                    KategorijaId = (int)reader["KategorijaId"],
                    Naziv = (string)reader[8]
                },
                StKategorija = new StarosnaKategorija
                {
                    StKategorijaId = (int)reader["StKategorijaId"],
                    Naziv = (string)reader[10]
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
