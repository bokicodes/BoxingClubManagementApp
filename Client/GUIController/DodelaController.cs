﻿using Client.forme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.komunikacija;

namespace Client.GUIController
{
    internal class DodelaController
    {
        internal void OsveziListuDodela(FrmDodela frmDodela)
        {
            frmDodela.DgvDodela.DataSource = Komunikacija.Instance.UcitajTakmicareTrenera();
        }
    }
}