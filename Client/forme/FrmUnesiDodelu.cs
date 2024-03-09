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

namespace Client.forme
{
    public partial class FrmUnesiDodelu : Form
    {
        BindingList<Dodela> listaDodela;
        public FrmUnesiDodelu()
        {
            InitializeComponent();

            listaDodela = new BindingList<Dodela>();
            dgvDodela.DataSource = listaDodela;

            cbTreneri.DataSource = Controller.Instance.UcitajListuTrenera();
            cbTakmicari.DataSource = Controller.Instance.UcitajListuTakmicara();

        }

        private void btnDodajUListu_Click(object sender, EventArgs e)
        {
            Trener trener = cbTreneri.SelectedItem as Trener;
            Takmicar takmicar = cbTakmicari.SelectedItem as Takmicar;

            if(trener == null || takmicar == null)
            {
                MessageBox.Show("Morate izabrati i trenera i takmicara");
                return;
            }
            
            foreach(Dodela d in listaDodela)
            {
                if(d.Trener.TrenerId == trener.TrenerId && d.Takmicar.TakmicarId == takmicar.TakmicarId)
                {
                    MessageBox.Show("Vec postoji u listi ta kombinacija");
                    return;
                }
            }

            Dodela dodela = new Dodela
            {
                Takmicar = takmicar,
                Trener = trener
            };

            listaDodela.Add(dodela);
        }
    }
}
