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
    public partial class FrmUnesiDodelu : Form
    {
        private readonly FrmDodela frmDodela;
        private readonly VrstaDodele operacija;
        BindingList<Dodela> listaDodela;

        public FrmUnesiDodelu(FrmDodela frmDodela, VrstaDodele operacija)
        {
            InitializeComponent();

            if(operacija == VrstaDodele.IZMENA)
            {
                listaDodela = new BindingList<Dodela>(Controller.Instance.UcitajListuDodela());
                dgvDodela.DataSource = listaDodela;
                btnObrisiDodelu.Visible = true;
                btnSacuvaj.Text = "Sačuvaj izmene";
            }
            else if(operacija == VrstaDodele.UNOS)
            {
                listaDodela = new BindingList<Dodela>();
                dgvDodela.DataSource = listaDodela;
                btnObrisiDodelu.Visible = false;
                btnSacuvaj.Text = "Sačuvaj";
            }      

            cbTreneri.DataSource = Controller.Instance.UcitajListuTrenera();
            cbTakmicari.DataSource = Controller.Instance.UcitajListuTakmicara();
            this.frmDodela = frmDodela;
            this.operacija = operacija;
        }

        private void btnDodajUListu_Click(object sender, EventArgs e)
        {
            List<Dodela> sacuvanaListaDodela = Controller.Instance.UcitajListuDodela();

            Trener trener = cbTreneri.SelectedItem as Trener;
            Takmicar takmicar = cbTakmicari.SelectedItem as Takmicar;

            if(trener == null || takmicar == null)
            {
                MessageBox.Show("Morate izabrati i trenera i takmicara");
                return;
            }
            
            foreach(Dodela d in sacuvanaListaDodela)
            {
                if (d.Trener.TrenerId == trener.TrenerId && d.Takmicar.TakmicarId == takmicar.TakmicarId)
                {
                    MessageBox.Show("Ta kombinacija trenera i takmicara je vec sacuvana!");
                    return;
                }
            }

            foreach(Dodela d in listaDodela)
            {
                if(d.Trener.TrenerId == trener.TrenerId && d.Takmicar.TakmicarId == takmicar.TakmicarId)
                {
                    MessageBox.Show("Vec postoji u listi ta kombinacija");
                    return;
                }
            }

            Dodela dodela = new Dodela
            {
                Takmicar = takmicar,
                Trener = trener
            };

            listaDodela.Add(dodela);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (operacija == VrstaDodele.IZMENA)
            {
                try
                {
                    Controller.Instance.ObrisiSveDodele();
                }
                catch (Exception)
                {
                    MessageBox.Show("Došlo je do greške prilikom brisanja dodela");
                    return;
                }

                if (listaDodela.Count == 0)
                {
                    frmDodela.OsveziListuDodela();
                    MessageBox.Show("Uspešno ste izmenili dodele takmičara i trenera");
                    return;
                }


                try
                {
                    Controller.Instance.SacuvajDodelu(listaDodela);
                    frmDodela.OsveziListuDodela();
                    MessageBox.Show("Uspešno ste izmenili dodele takmičara i trenera");
                }
                catch (Exception)
                {
                    MessageBox.Show("Došlo je do greske prilikom izmene dodela!");
                }
            }

            if(operacija == VrstaDodele.UNOS)
            {
                if (listaDodela.Count == 0)
                {
                    MessageBox.Show("Morate prvo dodati u listu nekog trenera i takmičara");
                    return;
                }

                try
                {
                    Controller.Instance.SacuvajDodelu(listaDodela);
                    frmDodela.OsveziListuDodela();
                    dgvDodela.Rows.Clear();

                    MessageBox.Show("Uspešno ste dodelili takmičare trenerima");
                }
                catch (Exception)
                {
                    MessageBox.Show("Došlo je do greške prilikom čuvanja dodela!");
                }
            }
        }
        private void btnObrisiDodelu_Click(object sender, EventArgs e)
        {
            if (dgvDodela.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali red");
                return;
            }

            Dodela d = dgvDodela.SelectedRows[0].DataBoundItem as Dodela;

            listaDodela.Remove(d);
            dgvDodela.DataSource = listaDodela;
        }
    }
}
