using Client.forme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.domen;
using Zajednicko.komunikacija;

namespace Client.GUIController
{
    internal class UnesiTreneraController
    {
        internal void InitDataIzmeni(FrmUnesiTrenera frmUnesiTrenera, Trener t)
        {
            frmUnesiTrenera.BtnSacuvaj.Visible = false;
            frmUnesiTrenera.BtnIzmeni.Visible = true;
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

>>>>>>> f345773ed77b1a1f8f87b1048d9d191955524fd9
>>>>>>> 99bff36ba669f1cbae798374727bf75962ff0816
            frmUnesiTrenera.CbGrad.DataSource = Komunikacija.Instance.UcitajListuGradova();
            frmUnesiTrenera.TbImeTrenera.Text = t.Ime;
            frmUnesiTrenera.TbPrezimeTrenera.Text = t.Prezime;
            frmUnesiTrenera.CbGrad.SelectedIndex = t.Grad.GradId - 1;
        }

        internal void InitDataUnesi(FrmUnesiTrenera frmUnesiTrenera)
        {
            frmUnesiTrenera.CbGrad.DataSource = Komunikacija.Instance.UcitajListuGradova();
            frmUnesiTrenera.BtnSacuvaj.Visible = true;
            frmUnesiTrenera.BtnIzmeni.Visible = false;
        }

        internal void UnesiTrenera(FrmUnesiTrenera frmUnesiTrenera)
        {
            if (!Validacija(frmUnesiTrenera))
            {
                MessageBox.Show("Neuspesan unos trenera");
                return;
            }

            string ime = frmUnesiTrenera.TbImeTrenera.Text;
            string prezime = frmUnesiTrenera.TbPrezimeTrenera.Text;
            Grad grad = frmUnesiTrenera.CbGrad.SelectedItem as Grad;

            Trener t = new Trener
            {
                Ime = ime,
                Prezime = prezime,
                Grad = grad
            };

            Trener zapamcenTrener = Komunikacija.Instance.ZapamtiTrenera(t);          
            MessageBox.Show("Uspesan unos trenera");
        }

        public bool Validacija(FrmUnesiTrenera frmUnesiTrenera)
        {
            string errorMsg = "";

            string ime = frmUnesiTrenera.TbImeTrenera.Text;
            if (string.IsNullOrEmpty(ime))
            {
                errorMsg += "Ime ne sme biti prazno\n";
            }

            string prezime = frmUnesiTrenera.TbPrezimeTrenera.Text;
            if (string.IsNullOrEmpty(prezime))
            {
                errorMsg += "Prezime ne sme biti prazno\n";
            }

            Grad g = frmUnesiTrenera.CbGrad.SelectedItem as Grad;
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

        internal void IzmeniTrenera(FrmUnesiTrenera frmUnesiTrenera, Trener t)
        {
            if (!Validacija(frmUnesiTrenera))
            {
                MessageBox.Show("Neuspesna izmena trenera");
                return;
            }

            Trener noviTrener = new Trener
            {
                TrenerId = t.TrenerId,
                Ime = frmUnesiTrenera.TbImeTrenera.Text,
                Prezime = frmUnesiTrenera.TbPrezimeTrenera.Text,
                Grad = frmUnesiTrenera.CbGrad.SelectedItem as Grad
            };

            Komunikacija.Instance.IzmeniTrenera(noviTrener);
            MessageBox.Show("Uspesna izmena trenera");
        }
    }
}
