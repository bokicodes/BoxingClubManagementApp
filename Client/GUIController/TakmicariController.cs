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
    internal class TakmicariController
    {
        internal void ObrisiTakmicara(FrmTakmicari frmTakmicari)
        {
            if (frmTakmicari.DgvTakmicari.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali red");
                return;
            }

            Takmicar t = frmTakmicari.DgvTakmicari.SelectedRows[0].DataBoundItem as Takmicar;

            bool obrisano = Komunikacija.Instance.ObrisiTakmicara(t);
            if (obrisano)
                frmTakmicari.OsveziDgvTakmicara();
            else
                MessageBox.Show("Morate prvo u kartici 'Dodela' obrisati sve dodele sa ovim takmicarom");
        }

        internal void OsveziDgvTakmicara(FrmTakmicari frmTakmicari)
        {
            frmTakmicari.DgvTakmicari.DataSource = Komunikacija.Instance.UcitajListuTakmicara();

            frmTakmicari.DgvTakmicari.Columns[0].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[3].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[4].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[7].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[8].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[9].Visible = false;

            frmTakmicari.DgvTakmicari.Columns[6].HeaderText = "Starosna Kategorija";
        }

        internal void PretraziTakmicare(FrmTakmicari frmTakmicari)
        {
            string text = frmTakmicari.TbPretraziTakmicare.Text;
            frmTakmicari.DgvTakmicari.DataSource = Komunikacija.Instance.NadjiTakmicare(text);

            frmTakmicari.DgvTakmicari.Columns[0].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[3].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[4].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[7].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[8].Visible = false;
            frmTakmicari.DgvTakmicari.Columns[9].Visible = false;

            frmTakmicari.DgvTakmicari.Columns[6].HeaderText = "Starosna Kategorija";
            
        }

        internal void PrikaziTakmicara(FrmTakmicari frmTakmicari, FrmUnesiTakmicara frmUnesiTakmicara)
        {
            if (frmTakmicari.DgvTakmicari.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali red!");
                return;
            }

            Takmicar t = frmTakmicari.DgvTakmicari.SelectedRows[0].DataBoundItem as Takmicar;

            frmUnesiTakmicara = new FrmUnesiTakmicara(frmTakmicari, t);
            frmUnesiTakmicara.ShowDialog();
        }
    }
}
