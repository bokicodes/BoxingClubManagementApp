﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiSveDodeleSO : SOBase
    {
        protected override void Execute()
        {
            broker.ObrisiSveDodele();
        }
    }
}
