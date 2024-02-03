using Client.forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void takmičariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTakmicari frmTakmicari = new FrmTakmicari();
            frmTakmicari.ShowDialog();
        }

        private void treneriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTreneri frmTreneri = new FrmTreneri();
            frmTreneri.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dodelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDodela frmDodela = new FrmDodela();
            frmDodela.ShowDialog();
        }
    }
}
