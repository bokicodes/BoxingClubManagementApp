using Client.forme;
using Client.izuzeci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.komunikacija;

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
            try
            {
                FrmTakmicari frmTakmicari = new FrmTakmicari();
                frmTakmicari.ShowDialog();
            }
            catch (ServerCommunicationException)
            {
                MessageBox.Show("Server je ugasen");
                this.Close();
            }
            
        }

        private void treneriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTreneri frmTreneri = new FrmTreneri();
                frmTreneri.ShowDialog();
            }catch (ServerCommunicationException)
            {
                MessageBox.Show("Server je ugasen");
                this.Close();
            }
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dodelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDodela frmDodela = new FrmDodela();
                frmDodela.ShowDialog();
            }
            catch (ServerCommunicationException)
            {
                MessageBox.Show("Server je ugasen");
                this.Close();
            }
           
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Komunikacija.Instance.Disconnect();
            }catch(IOException ex)
            {
                Debug.WriteLine(">>>FormClosed>>>" + ex.Message);
            }
            catch (ServerCommunicationException)
            {
                Debug.WriteLine(">>>ServerUgasen>>>");
            }
        }
    }
}
