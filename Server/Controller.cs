using DBBroker;
using System;
using System.Collections.Generic;
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

        public void DodajTakmicara(Takmicar t)
        {
            try
            {
                broker.OpenConnection();
                broker.DodajTakmicara(t);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Kategorija> UcitajListuKategorija()
        {
            try
            {
                broker.OpenConnection();
                return broker.UcitajListuKategorija();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<StarosnaKategorija> UcitajListuStKategorija()
        {
            try
            {
                broker.OpenConnection();
                return broker.UcitajListuStKategorija();
            }
            finally
            {
                broker.CloseConnection();
            }
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

        public void IzmeniTakmicara(Takmicar t)
        {
            try
            {
                broker.OpenConnection();
                broker.IzmeniTakmicara(t);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Takmicar> PretraziTakmicare(string text)
        {
            try
            {
                broker.OpenConnection();
                return broker.PretraziTakmicare(text);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void SacuvajTrenera(Trener t)
        {
            try
            {
                broker.OpenConnection();
                broker.SacuvajTrenera(t);
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
    }
}
