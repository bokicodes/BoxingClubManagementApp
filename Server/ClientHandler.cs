using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.domen;
using Zajednicko.komunikacija;

namespace Server
{
    public class ClientHandler
    {
        private readonly Socket socket;

        private Helper helper;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            helper = new Helper(socket);
        }

        private bool kraj = false;

        public void HandleRequests()
        {
            try
            {
                while (!kraj)
                {
                    Zahtev zahtev = helper.Primi<Zahtev>();
                    Odgovor odgovor = KreirajOdgovor(zahtev);
                    helper.Posalji(odgovor);
                }
            }
            catch (IOException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
            finally
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            
        }

        public Odgovor KreirajOdgovor(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            try
            {
                switch (zahtev.Operacija)
                {
                    case Operacija.Login:
                        odgovor.OdgovorObject = Controller.Instance.Login((Korisnik)zahtev.ZahtevObject);
                        if (odgovor.OdgovorObject == null)
                        {
                            odgovor.Uspesno = false;
                            odgovor.Poruka = "Korisnik ne postoji";
                        }
                        break;

                    case Operacija.UcitajListuTakmicara:
                        odgovor.OdgovorObject = Controller.Instance.UcitajListuTakmicara();
                        break;

                    case Operacija.NadjiTakmicare:
                        odgovor.OdgovorObject = Controller.Instance.NadjiTakmicare(zahtev.ZahtevObject.ToString());
                        break;

                    case Operacija.Kraj:
                        kraj = true;
                        break;

                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
                odgovor.Uspesno = false;
                odgovor.Poruka = ex.Message;
            }
            return odgovor;
        }
    }
}
