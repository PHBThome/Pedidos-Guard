using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories
{
    public class PedidoRepositoryArray : RepositoryBaseArray<Pedido>
    {
        protected override string FilePath => "Pedidos.json";
    }
}
