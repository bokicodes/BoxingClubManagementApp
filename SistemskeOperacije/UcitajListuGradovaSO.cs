﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;

namespace SistemskeOperacije
{
    public class UcitajListuGradovaSO : SOBase
    {
        public List<Grad> ListaGradova { get; private set; }
        protected override void Execute()
        {
            ListaGradova = broker.UcitajListu(new Grad()).OfType<Grad>().ToList();
        }
    }
}
