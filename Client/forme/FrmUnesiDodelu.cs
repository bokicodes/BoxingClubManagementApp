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
        private readonly FrmDodela frmDodela;
        BindingList<Dodela> listaDodela;

        public FrmUnesiDodelu(FrmDodela frmDodela)
        {
            InitializeComponent();

            listaDodela = new BindingList<Dodela>();
            dgvDodela.DataSource = listaDodela;

            cbTreneri.DataSource = Controller.Instance.UcitajListuTrenera();
            cbTakmicari.DataSource = Controller.Instance.UcitajListuTakmicara();
            this.frmDodela = frmDodela;
        }

        private void btnDodajUListu_Click(object sender, EventArgs e)
        {
            List<Dodela> sacuvanaListaDodela = Controller.Instance.UcitajListuDodela();

            Trener trener = cbTreneri.SelectedItem as Trener;
            Takmicar takmicar = cbTakmicari.SelectedItem as Takmicar;

            if(trener == null || takmicar == null)
            {
                MessageBox.Show("Morate izabrati i trenera i takmicara");
                return;
            }
            
            foreach(Dodela d in sacuvanaListaDodela)
            {
                if (d.Trener.TrenerId == trener.TrenerId && d.Takmicar.TakmicarId == takmicar.TakmicarId)
                {
                    MessageBox.Show("Ta kombinacija trenera i takmicara je vec sacuvana!");
                    return;
                }
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

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (listaDodela.Count == 0)
            {
                MessageBox.Show("Morate prvo dodati u listu nekog trenera i takmičara");
                return;
            }

            try
            {
                Controller.Instance.SacuvajDodelu(listaDodela);
                frmDodela.OsveziListuDodela();
                MessageBox.Show("Uspesno ste dodelili takmicare trenerima");
            }
            catch (Exception)
            {
                MessageBox.Show("Doslo je do greske prilikom cuvanja dodela!");
            }
        }
    }
}
