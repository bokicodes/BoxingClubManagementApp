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

namespace Client.forme
{
    public partial class FrmDodela : Form
    {
        public FrmDodela()
        {
            InitializeComponent();

            OsveziListuDodela();
        }

        public void OsveziListuDodela()
        {
            dgvDodela.DataSource = Controller.Instance.UcitajListuDodela();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            FrmUnesiDodelu frmUnesiDodelu = new FrmUnesiDodelu(this);
            frmUnesiDodelu.ShowDialog();
        }

        private void btnObrisiDodelu_Click(object sender, EventArgs e)
        {
            if (dgvDodela.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali red");
                return;
            }

            Dodela d = dgvDodela.SelectedRows[0].DataBoundItem as Dodela;

            Controller.Instance.ObrisiDodelu(d);
            OsveziListuDodela();
        }
    }
}
