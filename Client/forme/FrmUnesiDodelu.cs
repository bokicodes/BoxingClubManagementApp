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
    public partial class FrmUnesiDodelu : Form
    {
        private UnesiDodeluController controller = new UnesiDodeluController();
        private readonly FrmDodela frmDodela;
        private readonly VrstaDodele operacija;
        public BindingList<Dodela> listaDodela;

        public FrmUnesiDodelu(FrmDodela frmDodela, VrstaDodele operacija)
        {
            InitializeComponent();

            if(operacija == VrstaDodele.IZMENA)
            {
                controller.IzmeniDodelu(this);
            }
            else if(operacija == VrstaDodele.UNOS)
            {
                controller.UnesiDodelu(this);
            }

            controller.InitData(this);

            this.frmDodela = frmDodela;
            this.operacija = operacija;
        }

        private void btnDodajUListu_Click(object sender, EventArgs e)
        {
            controller.DodajDodelu(this, listaDodela);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (operacija == VrstaDodele.IZMENA)
            {
                controller.SacuvajIzmenuDodele(this, frmDodela, listaDodela);
            }

            if(operacija == VrstaDodele.UNOS)
            {
                controller.SacuvajUnosDodele(this, frmDodela, listaDodela);
            }
        }
        private void btnObrisiDodelu_Click(object sender, EventArgs e)
        {
            controller.ObrisiDodelu(this, listaDodela);
        }
    }
}
