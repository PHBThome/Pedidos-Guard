using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class ProdutoRepositoryArray : RepositoryBase<Produto>
{
    protected override string FilePath => "ProdutosArray.json";
}
