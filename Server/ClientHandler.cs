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

namespace Server
{
    public class ClientHandler
    {
        private readonly Socket socket;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
            formatter = new BinaryFormatter();
        }

        public void HandleRequests()
        {
            try
            {
                bool kraj = false;
                while (!kraj)
                {
                    Zahtev zahtev = (Zahtev)formatter.Deserialize(stream);
                    Odgovor odgovor = new Odgovor();

                    switch (zahtev.Operacija)
                    {
                        case Operacija.Login:
                            odgovor.OdgovorObject = Controller.Instance.Login((Korisnik)zahtev.ZahtevObject);
                            if (odgovor.OdgovorObject == null)
                            {
                                odgovor.Uspesno = false;
                                odgovor.Poruka = "Korisnik ne postoji";
                            }
                            else
                            {
                                odgovor.Uspesno = true;
                            }
                            formatter.Serialize(stream, odgovor);
                            break;

                        case Operacija.Kraj:
                            kraj = true;
                            break;

                        default:
                            break;
                    }
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
    }
}
