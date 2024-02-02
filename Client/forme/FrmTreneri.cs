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
    }
}
