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
    public enum VrstaDodele
    {
        UNOS,
        IZMENA
    }
    public partial class FrmDodela : Form
    {
        public FrmDodela()
        {
            InitializeComponent();

            OsveziListuDodela();
        }

        public void OsveziListuDodela()
        {
            dgvDodela.DataSource = Komunikacija.Instance.UcitajTakmicareTrenera();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            FrmUnesiDodelu frmUnesiDodelu = new FrmUnesiDodelu(this, VrstaDodele.UNOS);
            frmUnesiDodelu.ShowDialog();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            FrmUnesiDodelu frmUnesiDodelu = new FrmUnesiDodelu(this, VrstaDodele.IZMENA);
            frmUnesiDodelu.ShowDialog();
        }
    }
}
