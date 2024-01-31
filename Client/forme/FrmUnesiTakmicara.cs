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
    public partial class FrmUnesiTakmicara : Form
    {
        private readonly FrmTakmicari frmTakmicari;

        public FrmUnesiTakmicara(FrmTakmicari frmTakmicari)
        {
            InitializeComponent();

            cbKategorija.DataSource = Controller.Instance.UcitajListuKategorija();
            cbStarosnaKategorija.DataSource = Controller.Instance.UcitajListuStKategorija();
            
            this.frmTakmicari = frmTakmicari;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
            {
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
                Kategorija = new Kategorija
                {
                    KategorijaId = k.KategorijaId,
                    Naziv = k.Naziv
                },
                Tezina = tezina,
                StKategorija = new StarosnaKategorija
                {
                    StKategorijaId = st.StKategorijaId,
                    Naziv = st.Naziv
                },
                DatRodj = datRodj
            };

            Controller.Instance.DodajTakmicara(t);
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
    }
}
