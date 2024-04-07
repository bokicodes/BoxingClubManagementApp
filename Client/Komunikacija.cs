using Client.izuzeci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace Zajednicko.komunikacija
{
    public class Komunikacija
    {
        private Socket socket;

        private Helper helper;

        private static Komunikacija instance;
        public static Komunikacija Instance
        {
            get
            {
                if(instance == null)
                    instance = new Komunikacija();
                return instance;
            }
        }

        private Komunikacija()
        {
        }

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            helper = new Helper(socket);
        }

        private void PosaljiZahtev(Zahtev zahtev)
        {
            try
            {
                helper.Posalji(zahtev);
            }catch(IOException ex)
            {
                throw new ServerCommunicationException(ex.Message);
            }
        }

        public object VratiRezultat()
        {
            try
            {
                Odgovor odgovor = helper.Primi<Odgovor>();

                if (odgovor.Uspesno)
                {
                    return odgovor.OdgovorObject;
                }
                else
                {
                    throw new SystemOperationException(odgovor.Poruka);
                }
            }catch(IOException ex)
            {
                throw new ServerCommunicationException(ex.Message);
            }
            
        } 

        public Korisnik Login(Korisnik k)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.Login,
                ZahtevObject = k
            };
            PosaljiZahtev(zahtev);

            return (Korisnik)VratiRezultat();
        }

        public void Disconnect()
        {
            if (socket == null) return;

            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.Kraj,
            };
            PosaljiZahtev(zahtev);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
        }

        public List<Takmicar> UcitajListuTakmicara()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UcitajListuTakmicara
            };
            PosaljiZahtev(zahtev);

            return (List<Takmicar>)VratiRezultat();
        }

        public List<Takmicar> NadjiTakmicare(string text)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.NadjiTakmicare,
                ZahtevObject = text
            };
            PosaljiZahtev(zahtev);

            return (List<Takmicar>)VratiRezultat();
        }

        public List<Kategorija> UcitajListuKategorija()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UcitajListuKategorija
            };
            PosaljiZahtev(zahtev);

            return (List<Kategorija>)VratiRezultat();
        }

        public object UcitajListuStKategorija()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UcitajListuStKategorija
            };
            PosaljiZahtev(zahtev);

            return (List<StarosnaKategorija>)VratiRezultat();
        }

        public Takmicar ZapamtiTakmicara(Takmicar t)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.ZapamtiTakmicara,
                ZahtevObject = t
            };
            PosaljiZahtev(zahtev);

            return (Takmicar)VratiRezultat();
        }

        public Takmicar IzmeniTakmicara(Takmicar noviT)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.IzmeniTakmicara,
                ZahtevObject = noviT
            };
            PosaljiZahtev(zahtev);

            return (Takmicar)VratiRezultat();
        }

        public bool ObrisiTakmicara(Takmicar t)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.ObrisiTakmicara,
                ZahtevObject = t
            };
            PosaljiZahtev(zahtev);

            Odgovor odgovor = helper.Primi<Odgovor>();

            return odgovor.Uspesno;
        }

        public List<Trener> UcitajListuTrenera()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UcitajListuTrenera
            };
            PosaljiZahtev(zahtev);

            return (List<Trener>)VratiRezultat();
        }

        public List<Trener> NadjiTrenere(string text)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.NadjiTrenere,
                ZahtevObject = text
            };
            PosaljiZahtev(zahtev);

            return (List<Trener>)VratiRezultat();
        }

        public bool ObrisiTrenera(Trener t)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.ObrisiTrenera,
                ZahtevObject = t
            };
            PosaljiZahtev(zahtev);

            Odgovor odgovor = helper.Primi<Odgovor>();

            return odgovor.Uspesno;
        }

        public List<Grad> UcitajListuGradova()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UcitajListuGradova
            };
            PosaljiZahtev(zahtev);

            return (List<Grad>)VratiRezultat();
        }

        public Trener ZapamtiTrenera(Trener t)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.ZapamtiTrenera,
                ZahtevObject = t
            };
            PosaljiZahtev(zahtev);

            return (Trener)VratiRezultat();
        }

        public Trener IzmeniTrenera(Trener noviTrener)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.IzmeniTrenera,
                ZahtevObject = noviTrener
            };
            PosaljiZahtev(zahtev);

            return (Trener)VratiRezultat();
        }

        public List<Dodela> UcitajTakmicareTrenera()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.UcitajTakmicareTrenera
            };
            PosaljiZahtev(zahtev);

            return (List<Dodela>)VratiRezultat();
        }

        public void ObrisiSveDodele()
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.ObrisiSveDodele
            };
            PosaljiZahtev(zahtev);

            VratiRezultat();
        }

        internal void DodeliTakmicareTreneru(BindingList<Dodela> listaDodela)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.DodeliTakmicareTreneru,
                ZahtevObject = listaDodela,
            };
            PosaljiZahtev(zahtev);

            VratiRezultat();
        }
    }
}
