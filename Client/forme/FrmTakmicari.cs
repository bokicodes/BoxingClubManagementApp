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
    public partial class FrmTakmicari : Form
    {
        public FrmTakmicari()
        {
            InitializeComponent();

            OsveziDgvTakmicara();
            
        }
        public void OsveziDgvTakmicara()
        {
            dgvTakmicari.DataSource = Controller.Instance.UcitajListuTakmicara();

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
    }
}
