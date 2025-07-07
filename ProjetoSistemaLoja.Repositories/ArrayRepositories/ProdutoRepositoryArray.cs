using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class ProdutoRepositoryArray : RepositoryBaseArray<Produto>
{
    public ProdutoRepositoryArray() : base("Produtos.json") { }
}
