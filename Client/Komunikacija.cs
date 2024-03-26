using Client.izuzeci;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        public object VratiRezultat()
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
        } 

        public Korisnik Login(Korisnik k)
        {
            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.Login,
                ZahtevObject = k
            };
            helper.Posalji(zahtev);

            return (Korisnik)VratiRezultat();
        }

        public void Disconnect()
        {
            if (socket == null) return;

            Zahtev zahtev = new Zahtev
            {
                Operacija = Operacija.Kraj,
            };
            helper.Posalji(zahtev);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
        }
    }
}
