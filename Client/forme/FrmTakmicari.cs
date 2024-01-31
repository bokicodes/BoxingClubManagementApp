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
    public partial class FrmTakmicari : Form
    {
        public FrmTakmicari()
        {
            InitializeComponent();

            OsveziDgvTakmicara();
            
        }
        public void OsveziDgvTakmicara()
        {
            BindingList<Takmicar> takmicari = new BindingList<Takmicar>(Controller.Instance.UcitajListuTakmicara());
            dgvTakmicari.DataSource = takmicari;

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
    }
}
