using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ListRepositories;

public class ProdutoRepositoryList : RepositoryBaseList<Produto>
{
    protected override string FilePath => "ProdutosList.json";
}
