using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories
{
    public class PedidoRepositoryArray : RepositoryBaseArray<Pedido>
    {
        public PedidoRepositoryArray() : base("Pedidos.json") { }
    }
}
