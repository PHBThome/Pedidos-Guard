using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaLoja.Models
{
    public class PedidoItem
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
    }
}
