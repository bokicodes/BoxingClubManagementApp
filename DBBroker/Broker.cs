using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private SqlTransaction transaction;

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

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
        
        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
        

        public Takmicar ZapamtiTakmicara(Takmicar t)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"insert into Takmicar values(@Ime,@Prezime,@Tezina," +
                $"@DatRodj,@KategorijaId,@StKategorijaId)";

            cmd.Parameters.AddWithValue("@Ime", t.Ime);
            cmd.Parameters.AddWithValue("@Prezime", t.Prezime);
            cmd.Parameters.AddWithValue("@Tezina", t.Tezina);
            cmd.Parameters.AddWithValue("@DatRodj", t.DatRodj);
            cmd.Parameters.AddWithValue("@KategorijaId", t.Kategorija.KategorijaId);
            cmd.Parameters.AddWithValue("@StKategorijaId", t.StKategorija.StKategorijaId);

            cmd.ExecuteNonQuery();

            return t;
        }

        public List<Kategorija> UcitajListuKategorija()
        {
            SqlCommand command = new SqlCommand("", connection, transaction);

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
            SqlCommand cmd = new SqlCommand("", connection, transaction);

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
            SqlCommand cmd = new SqlCommand("", connection, transaction);

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

        public Takmicar IzmeniTakmicara(Takmicar t)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"update takmicar set ime=@ime,prezime=@prezime," +
                $"tezina=@tezina,DatRodj=@DatRodj,Kategorija=@KatId," +
                $"StKategorija=@StKatId where TakmicarId=@TId";

            cmd.Parameters.AddWithValue("@ime", t.Ime);
            cmd.Parameters.AddWithValue("@prezime", t.Prezime);
            cmd.Parameters.AddWithValue("@tezina", t.Tezina);
            cmd.Parameters.AddWithValue("@DatRodj", t.DatRodj);
            cmd.Parameters.AddWithValue("@KatId", t.Kategorija.KategorijaId);
            cmd.Parameters.AddWithValue("@StKatId", t.StKategorija.StKategorijaId);
            cmd.Parameters.AddWithValue("@TId", t.TakmicarId);

            cmd.ExecuteNonQuery();

            return t;
        }

        public List<Takmicar> NadjiTakmicare(string text)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"select * from takmicar t join kategorija k on t.Kategorija = k.KategorijaId" +
                $" join StarosnaKategorija sk on t.StKategorija = sk.StKategorijaId where Ime like '%{text}%'";

            List<Takmicar> listaNadjenihTakmicara = new List<Takmicar>();

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

                    listaNadjenihTakmicara.Add(t);
                }
            }
            return listaNadjenihTakmicara;
        }

        public Trener SacuvajTrenera(Trener t)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"insert into trener values (@ime,@prezime,@gradId)";

            cmd.Parameters.AddWithValue("@ime", t.Ime);
            cmd.Parameters.AddWithValue("@prezime", t.Prezime);
            cmd.Parameters.AddWithValue("@gradId", t.Grad.GradId);

            cmd.ExecuteNonQuery();

            return t;
        }

        public List<Grad> UcitajListuGradova()
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"select * from grad";

            List<Grad> listaGradova = new List<Grad>();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Grad grad = new Grad()
                    {
                        GradId = (int)reader["GradId"],
                        Naziv = (string)reader["Naziv"],
                        PostanskiBroj = (string)reader["PostanskiBroj"]
                    };
                    listaGradova.Add(grad);
                }
            }
            return listaGradova;
        }

        public List<Trener> UcitajListuTrenera()
        {
            SqlCommand cmd = new SqlCommand("",connection, transaction);

            cmd.CommandText = $"select * from trener t join grad g on t.Grad = g.GradId";

            List<Trener> listaTrenera = new List<Trener>();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
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
                    listaTrenera.Add(t);
                }
            }
            return listaTrenera;
        }

        public Trener IzmeniTrenera(Trener t)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"update trener set ime=@ime,prezime=@prezime,grad=@gradId" +
                $" where TrenerId = @TId";

            cmd.Parameters.AddWithValue("@ime", t.Ime);
            cmd.Parameters.AddWithValue("@prezime", t.Prezime);
            cmd.Parameters.AddWithValue("@gradId", t.Grad.GradId);
            cmd.Parameters.AddWithValue("@TId", t.TrenerId);

            cmd.ExecuteNonQuery();

            return t;
        }

        public List<Trener> PretraziTrenere(string text)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"select * from trener t join grad g on t.Grad = g.GradId where t.Ime like '%{text}%'";

            List<Trener> listaTrenera = new List<Trener>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
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
                    listaTrenera.Add(t);
                }
            }
            return listaTrenera;
        }

        public List<Dodela> UcitajTakmicareTrenera()
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"select * from dodela d join takmicar t on d.Takmicar = t.TakmicarId join kategorija k on t.Kategorija = k.KategorijaId join StarosnaKategorija sk on t.StKategorija = sk.StKategorijaId join trener tr on d.Trener = tr.TrenerId join grad g on tr.Grad = g.GradId order by tr.Ime asc";

            List<Dodela> listaDodela = new List<Dodela>();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
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

                    listaDodela.Add(d);
                }
            }
            return listaDodela;
        }

        public void SacuvajDodelu(Dodela d)
        {
            SqlCommand cmd = new SqlCommand("", connection,transaction);

            cmd.CommandText = $"insert into dodela values (@takmicarID,@trenerID)";

            cmd.Parameters.AddWithValue("@takmicarID", d.Takmicar.TakmicarId);
            cmd.Parameters.AddWithValue("@trenerID",d.Trener.TrenerId);

            cmd.ExecuteNonQuery();
        }

        public Trener ObrisiTrenera(Trener t)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"DELETE FROM Trener WHERE TrenerId=@trenerId";

            cmd.Parameters.AddWithValue("@trenerId", t.TrenerId);

            cmd.ExecuteNonQuery();

            return t;
        }

        public Takmicar ObrisiTakmicara(Takmicar t)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"DELETE FROM Takmicar WHERE TakmicarId=@takmicarId";

            cmd.Parameters.AddWithValue("@takmicarId", t.TakmicarId);

            cmd.ExecuteNonQuery();

            return t;
        }

        public void ObrisiDodelu(Dodela d)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"DELETE FROM Dodela WHERE Takmicar=@takmicarId AND Trener=@trenerId";

            cmd.Parameters.AddWithValue("@takmicarId", d.Takmicar.TakmicarId);
            cmd.Parameters.AddWithValue("@trenerId", d.Trener.TrenerId);

            cmd.ExecuteNonQuery();
        }

        public void ObrisiSveDodele()
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"DELETE FROM Dodela";

            cmd.ExecuteNonQuery();
        }

        public List<Korisnik> VratiListuKorisnika()
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"select * from korisnik";

            List<Korisnik> listaKorisnika = new List<Korisnik>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Korisnik k = new Korisnik
                    {
                        KorisnickoIme = (string)reader["KorisnickoIme"],
                        Lozinka = (string)reader["Lozinka"]
                    };

                    listaKorisnika.Add(k);
                }
            }
            return listaKorisnika;
        }

        public Korisnik Login(Korisnik k)
        {
            List<Korisnik> listaKorisnika = VratiListuKorisnika();

            foreach(Korisnik korisnik in listaKorisnika)
            {
                if (k.KorisnickoIme == korisnik.KorisnickoIme && k.Lozinka == korisnik.Lozinka)
                    return k;
            }
            return null;
        }
    }
}
