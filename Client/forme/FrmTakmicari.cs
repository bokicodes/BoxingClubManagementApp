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
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            FrmUnesiTakmicara frmUnesiTakmicara = new FrmUnesiTakmicara();
            frmUnesiTakmicara.ShowDialog();
        }
    }
}
