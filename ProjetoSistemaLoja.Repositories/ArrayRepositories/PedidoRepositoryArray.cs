using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories
{
    public class PedidoRepositoryArray : RepositoryBaseArray<Pedido>
    {
        protected override string FilePath => "Pedidos.json";
    }
}
