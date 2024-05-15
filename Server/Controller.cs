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
            SOBase so = new UcitajTakmicareTreneraSO();
            so.ExecuteTemplate();
            return ((UcitajTakmicareTreneraSO)so).ListaDodela;
        }
        public void DodeliTakmicareTreneru(BindingList<Dodela> listaDodela)
        {
            SOBase so = new DodeliTakmicareTreneruSO(listaDodela);
            so.ExecuteTemplate();
        }

        public Trener ObrisiTrenera(Trener t)
        {
            SOBase so = new ObrisiTreneraSO(t);
            so.ExecuteTemplate();
            return ((ObrisiTreneraSO)so).T;
        }

        public Takmicar ObrisiTakmicara(Takmicar t)
        {
            SOBase so = new ObrisiTakmicaraSO(t);
            so.ExecuteTemplate();
            return ((ObrisiTakmicaraSO)so).T;
        }

        public void ObrisiDodelu(Dodela d)
        {
            SOBase so = new ObrisiDodeluSO(d);
            so.ExecuteTemplate();
        }

        public void ObrisiSveDodele()
        {
            SOBase so = new ObrisiSveDodeleSO();
            so.ExecuteTemplate();
        }

        public List<Korisnik> VratiListuKorisnika()
        {
            SOBase so = new UcitajListuKorisnikaSO();
            so.ExecuteTemplate();
            return ((UcitajListuKorisnikaSO)so).ListaKorisnika;
        }

        public Korisnik Login(Korisnik k)
        {
            SOBase so = new LoginSO(k);
            so.ExecuteTemplate();
            return ((LoginSO)so).K;
        }
    }
}
