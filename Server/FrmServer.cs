using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;

        public FrmServer()
        {
            InitializeComponent();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            
            server = new Server();      
            server.Start();
            Thread nit = new Thread(server.Listen);
            nit.Start();                 
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.Stop();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
