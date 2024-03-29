using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.domen;
using Zajednicko.komunikacija;

namespace Client.forme
{
    public partial class FrmTakmicari : Form
    {
        public FrmTakmicari()
        {
            InitializeComponent();

            OsveziDgvTakmicara();
            
        }
        public void OsveziDgvTakmicara()
        {      
            dgvTakmicari.DataSource = Komunikacija.Instance.UcitajListuTakmicara();

            dgvTakmicari.Columns[0].Visible = false;
            dgvTakmicari.Columns[3].Visible = false;
            dgvTakmicari.Columns[4].Visible = false;

            dgvTakmicari.Columns[6].HeaderText = "Starosna Kategorija";
        }
        private void btnUnesi_Click(object sender, EventArgs e)
        {
            FrmUnesiTakmicara frmUnesiTakmicara = new FrmUnesiTakmicara(this);
            frmUnesiTakmicara.ShowDialog();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if(dgvTakmicari.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali red!");
                return;
            }

            Takmicar t = dgvTakmicari.SelectedRows[0].DataBoundItem as Takmicar;

            FrmUnesiTakmicara frmUnesiTakmicara = new FrmUnesiTakmicara(this,t);
            frmUnesiTakmicara.ShowDialog();

        }

        private void tbPretraziTakmicare_TextChanged(object sender, EventArgs e)
        {
            string text = tbPretraziTakmicare.Text;
            dgvTakmicari.DataSource =  Komunikacija.Instance.NadjiTakmicare(text);
            
            dgvTakmicari.Columns[0].Visible = false;
            dgvTakmicari.Columns[3].Visible = false;
            dgvTakmicari.Columns[4].Visible = false;

            dgvTakmicari.Columns[6].HeaderText = "Starosna Kategorija";
        }

        private void btnObrisiTakmicara_Click(object sender, EventArgs e)
        {
            if (dgvTakmicari.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali red");
                return;
            }

            Takmicar t = dgvTakmicari.SelectedRows[0].DataBoundItem as Takmicar;

            bool obrisano = Komunikacija.Instance.ObrisiTakmicara(t);
            if(obrisano)
                OsveziDgvTakmicara();
            else
                MessageBox.Show("Morate prvo u kartici 'Dodela' obrisati sve dodele sa ovim takmicarom");

        }
    }
}
