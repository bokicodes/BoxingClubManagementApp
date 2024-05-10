using Client.GUIController;
using Client.izuzeci;
using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.domen;
using Zajednicko.komunikacija;

namespace Client
{
    public partial class FrmLogin : Form
    {
        private LoginController controller;
        public FrmLogin()
        {
            InitializeComponent();
            controller = new LoginController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            controller.Login(this);
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Komunikacija.Instance.Disconnect();
        }
    }
}
