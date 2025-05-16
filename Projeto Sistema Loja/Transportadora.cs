using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Sistema_Loja
{
    internal class Transportadora : Endereco
    {
        public string Nome { get; set; }
        public double Valorkm { get; set; }
        public int Id { get; set; }

    }
}
