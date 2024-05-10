using Client.GUIController;
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
    public partial class FrmTreneri : Form
    {
        private TreneriController controller;
        private FrmUnesiTrenera frmUnesiTrenera;
        public FrmTreneri()
        {
            InitializeComponent();

            controller = new TreneriController();
            OsveziListuTrenera();
        }

        public void OsveziListuTrenera()
        {
            controller.OsveziListuTrenera(this);
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            frmUnesiTrenera = new FrmUnesiTrenera(this);
            frmUnesiTrenera.ShowDialog();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            controller.PrikaziTrenera(this, frmUnesiTrenera);    
        }

        private void tbPretraziTrenere_TextChanged(object sender, EventArgs e)
        {
            controller.PretraziTrenere(this);
        }

        private void btnObrisiTrenera_Click(object sender, EventArgs e)
        {
            controller.ObrisiTrenera(this);
        }
    }
}
