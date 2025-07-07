using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ListRepositories;

public class ProdutoRepositoryList : RepositoryBaseList<Produto>
{
    public ProdutoRepositoryList() : base("Produtos.json") { }
}
