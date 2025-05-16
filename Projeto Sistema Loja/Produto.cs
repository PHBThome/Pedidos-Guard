using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Sistema_Loja
{
    internal class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int Id { get; set; }
        public int IdFornecedor {  get; set; }

    }
}
