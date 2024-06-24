using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;
using static System.Net.Mime.MediaTypeNames;

namespace DBBroker
{
    public class Broker
    {
        private DbKonekcija konekcija;

        public Broker()
        {
            konekcija = new DbKonekcija();
        }

        public void CloseConnection()
        {
            konekcija.CloseConnection();
        }

        public void OpenConnection()
        {
            konekcija.OpenConnection();
        }

        public void Rollback()
        {
            konekcija.Rollback();
        }

        public void Commit()
        {
            konekcija.Commit();
        }

        public void BeginTransaction()
        {
            konekcija.BeginTransaction();
        }

        public IDomenskiObjekat Zapamti(IDomenskiObjekat obj)
        {
            SqlCommand cmd = konekcija.CreateCommand();

            cmd.CommandText = $"insert into {obj.NazivTabele} values({obj.VrednostiZaUneti})";

            cmd.ExecuteNonQuery();

            return obj;
        }

        public List<IDomenskiObjekat> UcitajListu(IDomenskiObjekat obj)
        {
            SqlCommand command = konekcija.CreateCommand();

            command.CommandText = $"select * from {obj.NazivTabele} {obj.Joinovanje}";

            List<IDomenskiObjekat> listaObjekta = new List<IDomenskiObjekat>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    IDomenskiObjekat domenskiObj = obj.KreirajObjekat(reader);
                    listaObjekta.Add(domenskiObj);
                }
            }
            return listaObjekta;
        }

        public IDomenskiObjekat Izmeni(IDomenskiObjekat obj)
        {
            SqlCommand cmd = konekcija.CreateCommand();

            cmd.CommandText = $"update {obj.NazivTabele} set {obj.VrednostiZaIzmenu}";

            cmd.ExecuteNonQuery();

            return obj;
        }

        public List<IDomenskiObjekat> Pretrazi(IDomenskiObjekat obj, string search)
        {
            SqlCommand cmd = konekcija.CreateCommand();

            cmd.CommandText = $"select * from {obj.NazivTabele} {obj.Joinovanje} where Ime like '%{search}%'";

            List<IDomenskiObjekat> listaNadjenihObjekta = new List<IDomenskiObjekat>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    IDomenskiObjekat domenskiObjekat = obj.KreirajObjekat(reader);

                    listaNadjenihObjekta.Add(domenskiObjekat);
                }
            }
            return listaNadjenihObjekta;
        }

        public IDomenskiObjekat Obrisi(IDomenskiObjekat obj)
        {
            SqlCommand cmd = konekcija.CreateCommand();

            cmd.CommandText = $"DELETE FROM {obj.NazivTabele} WHERE {obj.BrisanjePoKoloni}";

            cmd.ExecuteNonQuery();

            return obj;
        }

        public void ObrisiSve(IDomenskiObjekat obj)
        {
            SqlCommand cmd = konekcija.CreateCommand();

            cmd.CommandText = $"DELETE FROM {obj.NazivTabele}";

            cmd.ExecuteNonQuery();
        }
    }
}
