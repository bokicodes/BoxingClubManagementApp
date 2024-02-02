using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.domen;

namespace Client.forme
{
    public partial class FrmUnesiTrenera : Form
    {
        private readonly FrmTreneri frmTreneri;

        public FrmUnesiTrenera(FrmTreneri frmTreneri)
        {
            InitializeComponent();

            cbGrad.DataSource = Controller.Instance.UcitajListuGradova();

            this.frmTreneri = frmTreneri;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
                MessageBox.Show("Neuspesan unos trenera");
                return;
            }

            string ime = tbImeTrenera.Text;
            string prezime = tbPrezimeTrenera.Text;
            Grad grad = cbGrad.SelectedItem as Grad;

            Trener t = new Trener
            {
                Ime = ime,
                Prezime = prezime,
                Grad = grad
            };

            Controller.Instance.SacuvajTrenera(t);
            frmTreneri.OsveziListuTrenera();
            MessageBox.Show("Uspesan unos trenera");
            
        }

        public bool Validacija()
        {
            string errorMsg = "";

            string ime = tbImeTrenera.Text;
            if (string.IsNullOrEmpty(ime))
            {
                errorMsg += "Ime ne sme biti prazno\n";
            }

            string prezime = tbPrezimeTrenera.Text;
            if (string.IsNullOrEmpty(prezime))
            {
                errorMsg += "Prezime ne sme biti prazno\n";
            }

            Grad g = cbGrad.SelectedItem as Grad;
            if (g == null)
            {
                errorMsg += "Morate odabrati grad\n";
            }

            if (errorMsg != "")
            {
                MessageBox.Show(errorMsg);
                return false;
            }
            return true;
        }
    }
}
