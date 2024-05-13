using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.domen;
using static System.Net.Mime.MediaTypeNames;

namespace SistemskeOperacije
{
    public class NadjiTakmicareSO : SOBase
    {
        private readonly string text;
        public List<Takmicar> ListaPronadjenihTakmicara { get; set; }

        public NadjiTakmicareSO(string text)
        {
            this.text = text;
        }
        protected override void Execute()
        {
            ListaPronadjenihTakmicara = broker.NadjiTakmicare(text);
        }
    }
}
