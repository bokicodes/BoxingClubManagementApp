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
    public partial class FrmUnesiTakmicara : Form
    {
        private readonly FrmTakmicari frmTakmicari;
        private Takmicar t;
        public FrmUnesiTakmicara(FrmTakmicari frmTakmicari)
        {
            InitializeComponent();

            btnSacuvaj.Visible = true;
            btnIzmeni.Visible = false;

            cbKategorija.DataSource = Komunikacija.Instance.UcitajListuKategorija();
            cbStarosnaKategorija.DataSource = Komunikacija.Instance.UcitajListuStKategorija();
            
            this.frmTakmicari = frmTakmicari;
            
        }

        public FrmUnesiTakmicara(FrmTakmicari frmTakmicari, Takmicar t)
        {
            InitializeComponent();

            btnSacuvaj.Visible = false;
            btnIzmeni.Visible = true;
            cbKategorija.DataSource = Komunikacija.Instance.UcitajListuKategorija();
            cbStarosnaKategorija.DataSource = Komunikacija.Instance.UcitajListuStKategorija();
            this.frmTakmicari = frmTakmicari;
            this.t = t;

            tbImeTakmicara.Text = t.Ime;
            tbPrezimeTakmicara.Text = t.Prezime;
            tbTezina.Text = t.Tezina.ToString();
            cbKategorija.SelectedIndex = t.Kategorija.KategorijaId - 1;
            cbStarosnaKategorija.SelectedIndex = t.StKategorija.StKategorijaId - 1;
            dateTimePicker1.Value = t.DatRodj;
            
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
                MessageBox.Show("Neuspesno cuvanje takmicara");
                return;
            }
 
            string ime = tbImeTakmicara.Text;
            string prezime = tbPrezimeTakmicara.Text;
            Kategorija k = cbKategorija.SelectedItem as Kategorija;
            int tezina = int.Parse(tbTezina.Text);
            StarosnaKategorija st = cbStarosnaKategorija.SelectedItem as StarosnaKategorija;
            DateTime datRodj = dateTimePicker1.Value;

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
            frmTakmicari.OsveziDgvTakmicara();           
        }

        public bool Validacija()
        {
            string errorMsg = "";

            string ime = tbImeTakmicara.Text;
            if(string.IsNullOrEmpty(ime) )
            {
                errorMsg += "Ime ne sme biti prazno\n";
            }

            string prezime = tbPrezimeTakmicara.Text;
            if (string.IsNullOrEmpty(prezime))
            {
                errorMsg += "Prezime ne sme biti prazno\n";
            }

            Kategorija k = cbKategorija.SelectedItem as Kategorija;
            if(k == null)
            {
                errorMsg += "Morate odabrati kategoriju\n";
            }

            StarosnaKategorija sk = cbStarosnaKategorija.SelectedItem as StarosnaKategorija;
            if (sk == null)
            {
                errorMsg += "Morate odabrati starosnu kategoriju\n";
            }

            if(!int.TryParse(tbTezina.Text, out _))
            {
                errorMsg += "Morate uneti ceo broj za tezinu\n";
            }

            DateTime datum = dateTimePicker1.Value;
            if(datum == null)
            {
                errorMsg += "Morate odabrati neki datum\n";
            }

            if(errorMsg != "")
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
                MessageBox.Show("Neuspesna izmena");
                return;
            }

            Takmicar noviT = new Takmicar
            {
                TakmicarId = t.TakmicarId,
                Ime = tbImeTakmicara.Text,
                Prezime = tbPrezimeTakmicara.Text,
                DatRodj = dateTimePicker1.Value,
                Tezina = int.Parse(tbTezina.Text),
                Kategorija = cbKategorija.SelectedItem as Kategorija,
                StKategorija = cbStarosnaKategorija.SelectedItem as StarosnaKategorija
            };

            Takmicar noviTakmicar = Komunikacija.Instance.IzmeniTakmicara(noviT);
            MessageBox.Show("Uspesna izmena");
            frmTakmicari.OsveziDgvTakmicara();
            this.Close();
        }
    }
}
