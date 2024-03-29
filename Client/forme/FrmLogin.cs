﻿using Client.izuzeci;
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
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string pw = tbPassword.Text;

            try
            {
                Korisnik k = new Korisnik
                {
                    KorisnickoIme = username,
                    Lozinka = pw
                };

                Komunikacija.Instance.Connect();
                Komunikacija.Instance.Login(k);


                if (k != null)
                {                 
                    FrmMain frmMain = new FrmMain();
                    this.Visible = false;
                    frmMain.ShowDialog();
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show("Korisnik sa tim parametrima ne postoji");
                    Komunikacija.Instance.Disconnect();
                }
            }catch(SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
                Komunikacija.Instance.Disconnect();
            }catch(SocketException)
            {
                MessageBox.Show("Doslo je do greske pri radu sa serverom");
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Komunikacija.Instance.Disconnect();
        }
    }
}
