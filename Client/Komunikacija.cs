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

        private void PosaljiZahtev(Operacija operacija, object zahtevObject = null)
        {
            try
            {
                Zahtev zahtev = new Zahtev
                {
                    Operacija = operacija,
                    ZahtevObject = zahtevObject
                };
                helper.Posalji(zahtev);
            }
            catch (IOException ex)
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
            PosaljiZahtev(Operacija.Login, k);

            return (Korisnik)VratiRezultat();
        }

        public void Disconnect()
        {
            if (socket == null) return;

            PosaljiZahtev(Operacija.Kraj);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
        }

        public List<Takmicar> UcitajListuTakmicara()
        {
            PosaljiZahtev(Operacija.UcitajListuTakmicara);

            return (List<Takmicar>)VratiRezultat();
        }

        public List<Takmicar> NadjiTakmicare(string text)
        {
            PosaljiZahtev(Operacija.NadjiTakmicare,text);

            return (List<Takmicar>)VratiRezultat();
        }

        public List<Kategorija> UcitajListuKategorija()
        {
            PosaljiZahtev(Operacija.UcitajListuKategorija);

            return (List<Kategorija>)VratiRezultat();
        }

        public object UcitajListuStKategorija()
        {
            PosaljiZahtev(Operacija.UcitajListuStKategorija);

            return (List<StarosnaKategorija>)VratiRezultat();
        }

        public Takmicar ZapamtiTakmicara(Takmicar t)
        {
            PosaljiZahtev(Operacija.ZapamtiTakmicara,t);

            return (Takmicar)VratiRezultat();
        }

        public Takmicar IzmeniTakmicara(Takmicar noviT)
        {
            PosaljiZahtev(Operacija.IzmeniTakmicara, noviT);

            return (Takmicar)VratiRezultat();
        }

        public bool ObrisiTakmicara(Takmicar t)
        {
            PosaljiZahtev(Operacija.ObrisiTakmicara,t);

            Odgovor odgovor = helper.Primi<Odgovor>();

            return odgovor.Uspesno;
        }

        public List<Trener> UcitajListuTrenera()
        {
            PosaljiZahtev(Operacija.UcitajListuTrenera);

            return (List<Trener>)VratiRezultat();
        }

        public List<Trener> NadjiTrenere(string text)
        {
            PosaljiZahtev(Operacija.NadjiTrenere,text);

            return (List<Trener>)VratiRezultat();
        }

        public bool ObrisiTrenera(Trener t)
        {
            PosaljiZahtev(Operacija.ObrisiTrenera,t);

            Odgovor odgovor = helper.Primi<Odgovor>();

            return odgovor.Uspesno;
        }

        public List<Grad> UcitajListuGradova()
        {
            PosaljiZahtev(Operacija.UcitajListuGradova);

            return (List<Grad>)VratiRezultat();
        }

        public Trener ZapamtiTrenera(Trener t)
        {
            PosaljiZahtev(Operacija.ZapamtiTrenera,t);

            return (Trener)VratiRezultat();
        }

        public Trener IzmeniTrenera(Trener noviTrener)
        {
            PosaljiZahtev(Operacija.IzmeniTrenera,noviTrener);

            return (Trener)VratiRezultat();
        }

        public List<Dodela> UcitajTakmicareTrenera()
        {
            PosaljiZahtev(Operacija.UcitajTakmicareTrenera);

            return (List<Dodela>)VratiRezultat();
        }

        public void ObrisiSveDodele()
        {
            PosaljiZahtev(Operacija.ObrisiSveDodele);

            VratiRezultat();
        }

        internal void DodeliTakmicareTreneru(BindingList<Dodela> listaDodela)
        {
            PosaljiZahtev(Operacija.DodeliTakmicareTreneru, listaDodela);

            VratiRezultat();
        }
    }
}
