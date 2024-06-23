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
        
        public IDomenskiObjekat Zapamti(IDomenskiObjekat obj)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"insert into {obj.NazivTabele} values({obj.VrednostiZaUneti})";

            cmd.ExecuteNonQuery();

            return obj;
        }

        public List<IDomenskiObjekat> UcitajListu(IDomenskiObjekat obj)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);

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
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"update {obj.NazivTabele} set {obj.VrednostiZaIzmenu}";

            cmd.ExecuteNonQuery();

            return obj;
        }

        public List<IDomenskiObjekat> Pretrazi(IDomenskiObjekat obj, string search)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

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
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"DELETE FROM {obj.NazivTabele} WHERE {obj.BrisanjePoKoloni}";

            cmd.ExecuteNonQuery();

            return obj;
        }

        public void ObrisiSve(IDomenskiObjekat obj)
        {
            SqlCommand cmd = new SqlCommand("", connection, transaction);

            cmd.CommandText = $"DELETE FROM {obj.NazivTabele}";

            cmd.ExecuteNonQuery();
        }
    }
}
