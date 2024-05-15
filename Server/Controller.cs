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
using static System.Net.Mime.MediaTypeNames;

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
        public Broker broker;
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
            SOBase so = new UcitajListuTakmicaraSO();
            so.ExecuteTemplate();
            return ((UcitajListuTakmicaraSO)so).ListaTakmicara;
        }

        public Takmicar IzmeniTakmicara(Takmicar t)
        {
            SOBase so = new IzmeniTakmicaraSO(t);
            so.ExecuteTemplate();
            return ((IzmeniTakmicaraSO)so).t;
        }

        public List<Takmicar> NadjiTakmicare(string text)
        {
            SOBase so = new NadjiTakmicareSO(text);
            so.ExecuteTemplate();
            return ((NadjiTakmicareSO)so).ListaPronadjenihTakmicara;
        }

        public Trener ZapamtiTrenera(Trener t)
        {
            SOBase so = new ZapamtiTreneraSO(t);
            so.ExecuteTemplate();
            return ((ZapamtiTreneraSO)so).t;
        }

        public List<Grad> UcitajListuGradova()
        {
            SOBase so = new UcitajListuGradovaSO();
            so.ExecuteTemplate();
            return ((UcitajListuGradovaSO)so).ListaGradova;
        }

        public object UcitajListuTrenera()
        {
            SOBase so = new UcitajListuTreneraSO();
            so.ExecuteTemplate();
            return ((UcitajListuTreneraSO)so).ListaTrenera;
        }

        public Trener IzmeniTrenera(Trener t)
        {
            SOBase so = new IzmeniTreneraSO(t);
            so.ExecuteTemplate();
            return ((IzmeniTreneraSO)so).T;
        }

        public List<Trener> NadjiTrenere(string text)
        {
            SOBase so = new NadjiTrenereSO(text); 
            so.ExecuteTemplate();
            return ((NadjiTrenereSO)so).ListaPronadjenihTrenera;
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
