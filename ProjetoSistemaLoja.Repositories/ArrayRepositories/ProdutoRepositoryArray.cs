using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class ProdutoRepositoryArray : RepositoryBaseArray<Produto>
{
    protected override string FilePath => "Produtos.json";
}
