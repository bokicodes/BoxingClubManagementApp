using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko;
using Zajednicko.domen;
using Zajednicko.komunikacija;

namespace Server
{
    public class ClientHandler
    {
        private Socket socket;

        private Helper helper;

        public EventHandler OdjavljenKlijent;

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
                CloseSocket();
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

                    case Operacija.UcitajListuKategorija:
                        odgovor.OdgovorObject = Controller.Instance.UcitajListuKategorija();
                        break;

                    case Operacija.UcitajListuStKategorija:
                        odgovor.OdgovorObject = Controller.Instance.UcitajListuStKategorija();
                        break;

                    case Operacija.ZapamtiTakmicara:
                        odgovor.OdgovorObject = Controller.Instance.ZapamtiTakmicara((Takmicar)zahtev.ZahtevObject);
                        break;

                    case Operacija.IzmeniTakmicara:
                        odgovor.OdgovorObject = Controller.Instance.IzmeniTakmicara((Takmicar)zahtev.ZahtevObject);
                        break;

                    case Operacija.ObrisiTakmicara:
                        odgovor.OdgovorObject = Controller.Instance.ObrisiTakmicara((Takmicar)zahtev.ZahtevObject);
                        break;

                    case Operacija.UcitajListuTrenera:
                        odgovor.OdgovorObject = Controller.Instance.UcitajListuTrenera();
                        break;

                    case Operacija.NadjiTrenere:
                        odgovor.OdgovorObject = Controller.Instance.NadjiTrenere(zahtev.ZahtevObject.ToString());
                        break;

                    case Operacija.ObrisiTrenera:
                        odgovor.OdgovorObject = Controller.Instance.ObrisiTrenera((Trener)zahtev.ZahtevObject);
                        break;

                    case Operacija.UcitajListuGradova:
                        odgovor.OdgovorObject = Controller.Instance.UcitajListuGradova();
                        break;

                    case Operacija.ZapamtiTrenera:
                        odgovor.OdgovorObject = Controller.Instance.ZapamtiTrenera((Trener)zahtev.ZahtevObject);
                        break;

                    case Operacija.IzmeniTrenera:
                        odgovor.OdgovorObject = Controller.Instance.IzmeniTrenera((Trener)zahtev.ZahtevObject);
                        break;

                    case Operacija.UcitajTakmicareTrenera:
                        odgovor.OdgovorObject = Controller.Instance.UcitajTakmicareTrenera();
                        break;

                    case Operacija.ObrisiSveDodele:
                        Controller.Instance.ObrisiSveDodele();
                        break;

                    case Operacija.DodeliTakmicareTreneru:
                        Controller.Instance.DodeliTakmicareTreneru((BindingList<Dodela>)zahtev.ZahtevObject);
                        break;

                    case Operacija.Kraj:
                        kraj = true;
                        break;



                    default:
                        break;

                }
            }
            catch (SqlException)
            {
                odgovor.Uspesno = false;
                odgovor.Poruka = "SqlException";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
                odgovor.Uspesno = false;
                odgovor.Poruka = ex.Message;
            }
            return odgovor;
        }

        private object lockObject = new object();
        internal void CloseSocket()
        {
            lock (lockObject)
            {
                if (socket != null)
                {
                    kraj = true;
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket = null;
                    OdjavljenKlijent?.Invoke(this, EventArgs.Empty);
                }
            }
            
            
        }
    }
}
