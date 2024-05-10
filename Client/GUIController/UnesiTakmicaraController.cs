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
    internal class UnesiTakmicaraController
    {
        internal void InitDataIzmeni(FrmUnesiTakmicara frmUnesiTakmicara, Takmicar t)
        {
            frmUnesiTakmicara.BtnSacuvaj.Visible = false;
            frmUnesiTakmicara.BtnIzmeni.Visible = true;
            frmUnesiTakmicara.CbKategorija.DataSource = Komunikacija.Instance.UcitajListuKategorija();
            frmUnesiTakmicara.CbStarosnaKategorija.DataSource = Komunikacija.Instance.UcitajListuStKategorija();
            frmUnesiTakmicara.TbImeTakmicara.Text = t.Ime;
            frmUnesiTakmicara.TbPrezimeTakmicara.Text = t.Prezime;
            frmUnesiTakmicara.TbTezina.Text = t.Tezina.ToString();
            frmUnesiTakmicara.CbKategorija.SelectedIndex = t.Kategorija.KategorijaId - 1;
            frmUnesiTakmicara.CbStarosnaKategorija.SelectedIndex = t.StKategorija.StKategorijaId - 1;
            frmUnesiTakmicara.DateTimePicker1.Value = t.DatRodj;
        }

        internal void InitDataUnesi(FrmUnesiTakmicara frmUnesiTakmicara)
        {
            frmUnesiTakmicara.BtnSacuvaj.Visible = true;
            frmUnesiTakmicara.BtnIzmeni.Visible = false;

            frmUnesiTakmicara.CbKategorija.DataSource = Komunikacija.Instance.UcitajListuKategorija();
            frmUnesiTakmicara.CbStarosnaKategorija.DataSource = Komunikacija.Instance.UcitajListuStKategorija();
        }

        internal void UnesiTakmicara(FrmUnesiTakmicara frmUnesiTakmicara)
        {
            if (!Validacija(frmUnesiTakmicara))
            {
                MessageBox.Show("Neuspesno cuvanje takmicara");
                return;
            }

            string ime = frmUnesiTakmicara.TbImeTakmicara.Text;
            string prezime = frmUnesiTakmicara.TbPrezimeTakmicara.Text;
            Kategorija k = frmUnesiTakmicara.CbKategorija.SelectedItem as Kategorija;
            int tezina = int.Parse(frmUnesiTakmicara.TbTezina.Text);
            StarosnaKategorija st = frmUnesiTakmicara.CbStarosnaKategorija.SelectedItem as StarosnaKategorija;
            DateTime datRodj = frmUnesiTakmicara.DateTimePicker1.Value;

            Takmicar t = new Takmicar
            {
                Ime = ime,
                Prezime = prezime,
                Kategorija = k,
                Tezina = tezina,
                StKategorija = st,
                DatRodj = datRodj
            };

            Takmicar sacuvaniTakmicar = Komunikacija.Instance.ZapamtiTakmicara(t);
            MessageBox.Show("Uspesno ste dodali takmicara!");
        }


        public bool Validacija(FrmUnesiTakmicara frmUnesiTakmicara)
        {
            string errorMsg = "";

            string ime = frmUnesiTakmicara.TbImeTakmicara.Text;
            if (string.IsNullOrEmpty(ime))
            {
                errorMsg += "Ime ne sme biti prazno\n";
            }

            string prezime = frmUnesiTakmicara.TbPrezimeTakmicara.Text;
            if (string.IsNullOrEmpty(prezime))
            {
                errorMsg += "Prezime ne sme biti prazno\n";
            }

            Kategorija k = frmUnesiTakmicara.CbKategorija.SelectedItem as Kategorija;
            if (k == null)
            {
                errorMsg += "Morate odabrati kategoriju\n";
            }

            StarosnaKategorija sk = frmUnesiTakmicara.CbStarosnaKategorija.SelectedItem as StarosnaKategorija;
            if (sk == null)
            {
                errorMsg += "Morate odabrati starosnu kategoriju\n";
            }

            if (!int.TryParse(frmUnesiTakmicara.TbTezina.Text, out _))
            {
                errorMsg += "Morate uneti ceo broj za tezinu\n";
            }

            DateTime datum = frmUnesiTakmicara.DateTimePicker1.Value;
            if (datum == null)
            {
                errorMsg += "Morate odabrati neki datum\n";
            }

            if (errorMsg != "")
            {
                MessageBox.Show(errorMsg);
                return false;
            }
            return true;
        }

        internal void IzmeniTakmicara(FrmUnesiTakmicara frmUnesiTakmicara, Takmicar t)
        {
            if (!Validacija(frmUnesiTakmicara))
            {
                MessageBox.Show("Neuspesna izmena");
                return;
            }

            Takmicar noviT = new Takmicar
            {
                TakmicarId = t.TakmicarId,
                Ime = frmUnesiTakmicara.TbImeTakmicara.Text,
                Prezime = frmUnesiTakmicara.TbPrezimeTakmicara.Text,
                DatRodj = frmUnesiTakmicara.DateTimePicker1.Value,
                Tezina = int.Parse(frmUnesiTakmicara.TbTezina.Text),
                Kategorija = frmUnesiTakmicara.CbKategorija.SelectedItem as Kategorija,
                StKategorija = frmUnesiTakmicara.CbStarosnaKategorija.SelectedItem as StarosnaKategorija
            };

            Takmicar noviTakmicar = Komunikacija.Instance.IzmeniTakmicara(noviT);
            MessageBox.Show("Uspesna izmena");
        }
    }
}
