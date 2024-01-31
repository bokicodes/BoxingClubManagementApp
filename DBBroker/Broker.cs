using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace DBBroker
{
    public class Broker
    {
        private SqlConnection connection;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-C1E55NG\SQLEXPRESS;Initial Catalog=BoxingClubDB;Integrated Security=True;");
        }

        public void OpenConnection()
        {
            connection?.Open();
        }

        public void CloseConnection()
        {
            connection?.Close();
        }

        
        public void DodajTakmicara(Takmicar t)
        {
            SqlCommand cmd = new SqlCommand("", connection);

            cmd.CommandText = $"insert into Takmicar values(@Ime,@Prezime,@Tezina," +
                $"@DatRodj,@KategorijaId,@StKategorijaId)";

            cmd.Parameters.AddWithValue("@Ime", t.Ime);
            cmd.Parameters.AddWithValue("@Prezime", t.Prezime);
            cmd.Parameters.AddWithValue("@Tezina", t.Tezina);
            cmd.Parameters.AddWithValue("@DatRodj", t.DatRodj);
            cmd.Parameters.AddWithValue("@KategorijaId", t.Kategorija.KategorijaId);
            cmd.Parameters.AddWithValue("@StKategorijaId", t.StKategorija.StKategorijaId);

            cmd.ExecuteNonQuery();
        }

        public List<Kategorija> UcitajListuKategorija()
        {
            SqlCommand command = new SqlCommand("", connection);

            command.CommandText = "select * from kategorija";

            List<Kategorija> sveKategorije = new List<Kategorija>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Kategorija k = new Kategorija()
                    {
                        KategorijaId = (int)reader["KategorijaId"],
                        Naziv = (string)reader["Naziv"],
                    };
                    sveKategorije.Add(k);
                }
            }
            return sveKategorije;
        }

        public List<StarosnaKategorija> UcitajListuStKategorija()
        {
            SqlCommand cmd = new SqlCommand("", connection);

            cmd.CommandText = $"select * from starosnakategorija";

            List<StarosnaKategorija> sveStKategorije = new List<StarosnaKategorija>();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    StarosnaKategorija sk = new StarosnaKategorija()
                    {
                       StKategorijaId = (int)reader["StKategorijaId"],
                        Naziv = (string)reader["Naziv"]
                    };

                    sveStKategorije.Add(sk);
                }
            }
            return sveStKategorije;
        }

        public List<Takmicar> UcitajListuTakmicara()
        {
            SqlCommand cmd = new SqlCommand("", connection);

            cmd.CommandText = $"select * from Takmicar t join " +
                $"Kategorija k on (t.Kategorija = k.KategorijaId) " +
                $"join StarosnaKategorija sk on (t.StKategorija = sk.StKategorijaId)";

            List<Takmicar> listaTakm = new List<Takmicar>();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
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

                    listaTakm.Add(t);
                }
            }
            return listaTakm;
        }
    }
}
