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
    public partial class FrmDodela : Form
    {
        public FrmDodela()
        {
            InitializeComponent();

            dgvDodela.DataSource = Controller.Instance.UcitajListuDodela();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            FrmUnesiDodelu frmUnesiDodelu = new FrmUnesiDodelu();
            frmUnesiDodelu.ShowDialog();
        }
    }
}
