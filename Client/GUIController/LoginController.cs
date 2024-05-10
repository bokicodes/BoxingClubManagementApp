using Client.izuzeci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.domen;
using Zajednicko.komunikacija;

namespace Client.GUIController
{
    internal class LoginController
    {
        internal void Login(FrmLogin frmLogin)
        {
            string username = frmLogin.TbUsername.Text;
            string pw = frmLogin.TbPassword.Text;

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
                    frmLogin.Visible = false;
                    frmMain.ShowDialog();
                    frmLogin.Visible = true;
                }
                else
                {
                    MessageBox.Show("Korisnik sa tim parametrima ne postoji");
                    Komunikacija.Instance.Disconnect();
                }
            }
            catch (SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
                Komunikacija.Instance.Disconnect();
            }
            catch (SocketException)
            {
                MessageBox.Show("Doslo je do greske pri radu sa serverom");
            }
        }
    }
}
