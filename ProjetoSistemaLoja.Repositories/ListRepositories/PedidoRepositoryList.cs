using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Repositories.ListRepositories
{
    public class PedidoRepositoryList : RepositoryBaseList<Pedido>
    {
        public PedidoRepositoryList() : base("Pedidos.json") { }
    }
}
