using Client.GUIController;
using Client.izuzeci;
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
        private TakmicariController controller;
        private FrmUnesiTakmicara frmUnesiTakmicara;
        public FrmTakmicari()
        {
            InitializeComponent();
            controller = new TakmicariController();
            OsveziDgvTakmicara();
            
        }
        public void OsveziDgvTakmicara()
        {
            controller.OsveziDgvTakmicara(this);
        }
        private void btnUnesi_Click(object sender, EventArgs e)
        {
            frmUnesiTakmicara = new FrmUnesiTakmicara(this);
            frmUnesiTakmicara.ShowDialog();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            controller.PrikaziTakmicara(this, frmUnesiTakmicara);
        }

        private void tbPretraziTakmicare_TextChanged(object sender, EventArgs e)
        {
            controller.PretraziTakmicare(this);
        }

        private void btnObrisiTakmicara_Click(object sender, EventArgs e)
        {
            controller.ObrisiTakmicara(this);
        }
    }
}
