using Client.forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.domen;
using Zajednicko.komunikacija;

namespace Client.GUIController
{
    internal class UnesiDodeluController
    {
        internal void DodajDodelu(FrmUnesiDodelu frmUnesiDodelu, BindingList<Dodela> listaDodela)
        {
            List<Dodela> sacuvanaListaDodela = Komunikacija.Instance.UcitajTakmicareTrenera();

            Trener trener = frmUnesiDodelu.CbTreneri.SelectedItem as Trener;
            Takmicar takmicar = frmUnesiDodelu.CbTakmicari.SelectedItem as Takmicar;

            if (trener == null || takmicar == null)
            {
                MessageBox.Show("Morate izabrati i trenera i takmicara");
                return;
            }

            foreach (Dodela d in sacuvanaListaDodela)
            {
                if (d.Trener.TrenerId == trener.TrenerId && d.Takmicar.TakmicarId == takmicar.TakmicarId)
                {
                    MessageBox.Show("Ta kombinacija trenera i takmicara je vec sacuvana!");
                    return;
                }
            }

            foreach (Dodela d in listaDodela)
            {
                if (d.Trener.TrenerId == trener.TrenerId && d.Takmicar.TakmicarId == takmicar.TakmicarId)
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

        internal void InitData(FrmUnesiDodelu frmUnesiDodelu)
        {
            frmUnesiDodelu.CbTreneri.DataSource = Komunikacija.Instance.UcitajListuTrenera();
            frmUnesiDodelu.CbTakmicari.DataSource = Komunikacija.Instance.UcitajListuTakmicara();
        }

        internal void IzmeniDodelu(FrmUnesiDodelu frmUnesiDodelu)
        {
            frmUnesiDodelu.listaDodela = new BindingList<Dodela>(Komunikacija.Instance.UcitajTakmicareTrenera());
            frmUnesiDodelu.DgvDodela.DataSource = frmUnesiDodelu.listaDodela;
            frmUnesiDodelu.DgvDodela.Columns[2].Visible = false;
            frmUnesiDodelu.DgvDodela.Columns[3].Visible = false;
            frmUnesiDodelu.BtnObrisiDodelu.Visible = true;
            frmUnesiDodelu.BtnSacuvaj.Text = "Sačuvaj izmene";
        }

        internal void ObrisiDodelu(FrmUnesiDodelu frmUnesiDodelu, BindingList<Dodela> listaDodela)
        {
            if (frmUnesiDodelu.DgvDodela.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali red");
                return;
            }

            Dodela d = frmUnesiDodelu.DgvDodela.SelectedRows[0].DataBoundItem as Dodela;

            listaDodela.Remove(d);
            frmUnesiDodelu.DgvDodela.DataSource = listaDodela;
        }

        internal void SacuvajIzmenuDodele(FrmUnesiDodelu frmUnesiDodelu, FrmDodela frmDodela, BindingList<Dodela> listaDodela)
        {
            try
            {
                Komunikacija.Instance.ObrisiSveDodele();
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
                Komunikacija.Instance.DodeliTakmicareTreneru(listaDodela);
                frmDodela.OsveziListuDodela();
                MessageBox.Show("Uspešno ste izmenili dodele takmičara i trenera");
            }
            catch (Exception)
            {
                MessageBox.Show("Došlo je do greske prilikom izmene dodela!");
            }
        }

        internal void SacuvajUnosDodele(FrmUnesiDodelu frmUnesiDodelu, FrmDodela frmDodela, BindingList<Dodela> listaDodela)
        {
            if (listaDodela.Count == 0)
            {
                MessageBox.Show("Morate prvo dodati u listu nekog trenera i takmičara");
                return;
            }

            try
            {
                Komunikacija.Instance.DodeliTakmicareTreneru(listaDodela);
                frmDodela.OsveziListuDodela();
                frmUnesiDodelu.DgvDodela.Rows.Clear();

                MessageBox.Show("Uspešno ste dodelili takmičare trenerima");
            }
            catch (Exception)
            {
                MessageBox.Show("Došlo je do greške prilikom čuvanja dodela!");
            }
        }

        internal void UnesiDodelu(FrmUnesiDodelu frmUnesiDodelu)
        {
            frmUnesiDodelu.listaDodela = new BindingList<Dodela>();
            frmUnesiDodelu.DgvDodela.DataSource = frmUnesiDodelu.listaDodela;
            frmUnesiDodelu.DgvDodela.Columns[2].Visible = false;
            frmUnesiDodelu.DgvDodela.Columns[3].Visible = false;
            frmUnesiDodelu.BtnObrisiDodelu.Visible = false;
            frmUnesiDodelu.BtnSacuvaj.Text = "Sačuvaj";
        }
    }
}
