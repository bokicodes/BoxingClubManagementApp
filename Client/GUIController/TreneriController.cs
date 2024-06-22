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
    internal class TreneriController
    {
        internal void PrikaziTrenera(FrmTreneri frmTreneri, FrmUnesiTrenera frmUnesiTrenera)
        {
            if (frmTreneri.DgvTreneri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali red");
                return;
            }

            Trener t = frmTreneri.DgvTreneri.SelectedRows[0].DataBoundItem as Trener;

            frmUnesiTrenera = new FrmUnesiTrenera(frmTreneri, t);
            frmUnesiTrenera.ShowDialog();
        }

        internal void OsveziListuTrenera(FrmTreneri frmTreneri)
        {
            frmTreneri.DgvTreneri.DataSource = Komunikacija.Instance.UcitajListuTrenera();
            frmTreneri.DgvTreneri.Columns[0].Visible = false;
            frmTreneri.DgvTreneri.Columns[4].Visible = false;
            frmTreneri.DgvTreneri.Columns[5].Visible = false;
            frmTreneri.DgvTreneri.Columns[6].Visible = false;

            frmTreneri.DgvTreneri.Columns[3].HeaderText = "Mesto življenja";
        }

        internal void PretraziTrenere(FrmTreneri frmTreneri)
        {
            string text = frmTreneri.TbPretraziTrenere.Text;


            frmTreneri.DgvTreneri.DataSource = Komunikacija.Instance.NadjiTrenere(text);

            frmTreneri.DgvTreneri.Columns[0].Visible = false;
            frmTreneri.DgvTreneri.Columns[4].Visible = false;
            frmTreneri.DgvTreneri.Columns[5].Visible = false;
            frmTreneri.DgvTreneri.Columns[6].Visible = false;

            frmTreneri.DgvTreneri.Columns[3].HeaderText = "Mesto življenja";
        }

        internal void ObrisiTrenera(FrmTreneri frmTreneri)
        {
            if (frmTreneri.DgvTreneri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali red");
                return;
            }

            Trener t = frmTreneri.DgvTreneri.SelectedRows[0].DataBoundItem as Trener;

            bool obrisano = Komunikacija.Instance.ObrisiTrenera(t);
            if (obrisano)
                OsveziListuTrenera(frmTreneri);
            else
                MessageBox.Show("Morate prvo u kartici 'Dodela' obrisati sve dodele sa ovim trenerom");
        }
    }
}
