using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.komunikacija
{
    public class Komunikacija
    {
        private Socket socket;

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
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect()
        {
            socket.Connect("127.0.0.1", 9999);
        }
    }
}
