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
    public partial class FrmTreneri : Form
    {
        public FrmTreneri()
        {
            InitializeComponent();

            OsveziListuTrenera();
        }

        public void OsveziListuTrenera()
        {
            dgvTreneri.DataSource = Controller.Instance.UcitajListuTrenera();
            dgvTreneri.Columns[0].Visible = false;
            dgvTreneri.Columns[3].HeaderText = "Mesto življenja";
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            FrmUnesiTrenera frmUnesiTrenera = new FrmUnesiTrenera(this);
            frmUnesiTrenera.ShowDialog();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if(dgvTreneri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali red");
                return;
            }

            Trener t = dgvTreneri.SelectedRows[0].DataBoundItem as Trener;

            FrmUnesiTrenera frmUnesiTrenera = new FrmUnesiTrenera(this, t);
            frmUnesiTrenera.ShowDialog();
        }
    }
}
