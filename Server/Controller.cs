using DBBroker;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace Server
{
    public class Controller
    {
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                    instance = new Controller();
                return instance;
            }
        }
        private Broker broker;

        private Controller()
        {
            broker = new Broker();
        }

        public Takmicar ZapamtiTakmicara(Takmicar t)
        {
            SOBase so = new ZapamtiTakmicaraSO(t);
            so.ExecuteTemplate();
            return ((ZapamtiTakmicaraSO)so).t;
        }

        public List<Kategorija> UcitajListuKategorija()
        {
            SOBase so = new UcitajListuKategorijaSO();
            so.ExecuteTemplate();
            return ((UcitajListuKategorijaSO)so).ListaKategorija;
        }

        public List<StarosnaKategorija> UcitajListuStKategorija()
        {
            SOBase so = new UcitajListuStKategorijaSO();
            so.ExecuteTemplate();
            return ((UcitajListuStKategorijaSO)so).ListaStarosnihKategorija;
        }

        public List<Takmicar> UcitajListuTakmicara()
        {
            try
            {
                broker.OpenConnection();
                return broker.UcitajListuTakmicara();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public Takmicar IzmeniTakmicara(Takmicar t)
        {
            try
            {
                broker.OpenConnection();
                return broker.IzmeniTakmicara(t);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Takmicar> NadjiTakmicare(string text)
        {
            try
            {
                broker.OpenConnection();
                return broker.NadjiTakmicare(text);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public Trener SacuvajTrenera(Trener t)
        {
            try
            {
                broker.OpenConnection();
                return broker.SacuvajTrenera(t);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Grad> UcitajListuGradova()
        {
            try
            {
                broker.OpenConnection();
                return broker.UcitajListuGradova();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public object UcitajListuTrenera()
        {
            try
            {
                broker.OpenConnection();
                return broker.UcitajListuTrenera();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public Trener IzmeniTrenera(Trener t)
        {
            try
            {
                broker.OpenConnection();
                return broker.IzmeniTrenera(t);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Trener> NadjiTrenere(string text)
        {
            try
            {
                broker.OpenConnection();
                return broker.PretraziTrenere(text);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Dodela> UcitajTakmicareTrenera()
        {
            try
            {
                broker.OpenConnection();
                return broker.UcitajTakmicareTrenera();
            }
            finally
            {
                broker.CloseConnection();
            }
        }
        public void DodeliTakmicareTreneru(BindingList<Dodela> listaDodela)
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                foreach(Dodela d in listaDodela)
                {
                    broker.SacuvajDodelu(d);
                }

                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public Trener ObrisiTrenera(Trener t)
        {
            try
            {
                broker.OpenConnection();
                return broker.ObrisiTrenera(t);
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public Takmicar ObrisiTakmicara(Takmicar t)
        {
            try
            {
                broker.OpenConnection();
                return broker.ObrisiTakmicara(t);
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void ObrisiDodelu(Dodela d)
        {
            try
            {
                broker.OpenConnection();
                broker.ObrisiDodelu(d);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void ObrisiSveDodele()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                broker.ObrisiSveDodele();

                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Korisnik> VratiListuKorisnika()
        {
            try
            {
                broker.OpenConnection();
                return broker.VratiListuKorisnika();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public Korisnik Login(Korisnik k)
        {
            try
            {
                broker.OpenConnection();
                return broker.Login(k);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
