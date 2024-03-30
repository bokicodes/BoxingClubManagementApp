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
using Zajednicko.komunikacija;

namespace Client.forme
{
    public partial class FrmUnesiTrenera : Form
    {
        private readonly FrmTreneri frmTreneri;
        private readonly Trener t;

        public FrmUnesiTrenera(FrmTreneri frmTreneri)
        {
            InitializeComponent();

            cbGrad.DataSource = Komunikacija.Instance.UcitajListuGradova();

            this.frmTreneri = frmTreneri;

            btnSacuvaj.Visible = true;
            btnIzmeni.Visible = false;
        }

        public FrmUnesiTrenera(FrmTreneri frmTreneri, Trener t)
        {
            InitializeComponent();

            this.frmTreneri = frmTreneri;
            this.t = t;

            btnSacuvaj.Visible = false;
            btnIzmeni.Visible = true;

            cbGrad.DataSource = Komunikacija.Instance.UcitajListuGradova();
            tbImeTrenera.Text = t.Ime;
            tbPrezimeTrenera.Text = t.Prezime;
            cbGrad.SelectedIndex = t.Grad.GradId - 1;
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

            Trener zapamcenTrener = Komunikacija.Instance.ZapamtiTrenera(t);
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

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
                MessageBox.Show("Neuspesna izmena trenera");
                return;
            }

            Trener noviTrener = new Trener
            {
                TrenerId = t.TrenerId,
                Ime = tbImeTrenera.Text,
                Prezime = tbPrezimeTrenera.Text,
                Grad = cbGrad.SelectedItem as Grad
            };

            Komunikacija.Instance.IzmeniTrenera(noviTrener);
            frmTreneri.OsveziListuTrenera();
            MessageBox.Show("Uspesna izmena trenera");
            this.Close();
        }
    }
}
