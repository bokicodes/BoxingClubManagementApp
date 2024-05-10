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
    public partial class FrmUnesiTakmicara : Form
    {
        private UnesiTakmicaraController controller = new UnesiTakmicaraController();
        private readonly FrmTakmicari frmTakmicari;
        private Takmicar t;
        public FrmUnesiTakmicara(FrmTakmicari frmTakmicari)
        {
            InitializeComponent();

            controller.InitDataUnesi(this);       
            this.frmTakmicari = frmTakmicari;
            
        }

        public FrmUnesiTakmicara(FrmTakmicari frmTakmicari, Takmicar t)
        {
            InitializeComponent();

            controller.InitDataIzmeni(this, t);
           
            this.frmTakmicari = frmTakmicari;
            this.t = t;      
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            controller.UnesiTakmicara(this);
            frmTakmicari.OsveziDgvTakmicara();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            controller.IzmeniTakmicara(this, t);
            frmTakmicari.OsveziDgvTakmicara();
            this.Close();
        }
    }
}
