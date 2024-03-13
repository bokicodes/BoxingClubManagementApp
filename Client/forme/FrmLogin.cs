using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.domen;

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

            List<Korisnik> listaKorisnika = Controller.Instance.VratiListuKorisnika();

            bool postoji = false;

            foreach(Korisnik k in listaKorisnika)
            {
                if(k.KorisnickoIme == username && k.Lozinka == pw)
                {
                    postoji = true;
                    break;
                }
            }

            if (!postoji)
            {
                MessageBox.Show("Korisnik sa tim parametrima ne postoji");
                return;
            }
            else
            {
                FrmMain frmMain = new FrmMain();
                this.Visible = false;
                frmMain.ShowDialog();
                this.Visible = true;
            }      
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
