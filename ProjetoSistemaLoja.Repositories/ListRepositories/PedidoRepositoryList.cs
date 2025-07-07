using System;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Repositories.ListRepositories
{
    public class PedidoRepositoryList : RepositoryBaseList<Pedido>
    {
        protected override string FilePath => "Pedidos.json";
    }
}
