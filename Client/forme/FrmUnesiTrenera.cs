using Client.GUIController;
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
using Zajednicko.komunikacija;

namespace Client.forme
{
    public partial class FrmUnesiTrenera : Form
    {
        private UnesiTreneraController controller = new UnesiTreneraController();
        private readonly FrmTreneri frmTreneri;
        private readonly Trener t;

        public FrmUnesiTrenera(FrmTreneri frmTreneri)
        {
            InitializeComponent();

            controller.InitDataUnesi(this);
            this.frmTreneri = frmTreneri;
        }

        public FrmUnesiTrenera(FrmTreneri frmTreneri, Trener t)
        {
            InitializeComponent();

            this.frmTreneri = frmTreneri;
            this.t = t;
            controller.InitDataIzmeni(this, t);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            controller.UnesiTrenera(this);
            frmTreneri.OsveziListuTrenera();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            controller.IzmeniTrenera(this, t);
            frmTreneri.OsveziListuTrenera();
            this.Close();
        }
    }
}
