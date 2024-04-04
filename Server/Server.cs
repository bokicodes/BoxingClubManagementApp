using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket socket;
        private List<ClientHandler> listaKlijenta = new List<ClientHandler>();

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            socket.Bind(endpoint);
            socket.Listen(5);
        }

        public void Listen()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSocket = socket.Accept();
                    ClientHandler klijent = new ClientHandler(klijentskiSocket);
                    listaKlijenta.Add(klijent);
                    Thread nit = new Thread(klijent.HandleRequests);
                    nit.Start();
                }
            }catch(SocketException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
            
        }

        public void Stop()
        {
            socket.Close();
            foreach(ClientHandler klijent in listaKlijenta)
            {
                klijent.CloseSocket();
            }
        }
    }
}
