using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ListRepositories;

public class FornecedorRepositoryList : RepositoryBaseList<Fornecedor>
{
    protected override string FilePath => "Fornecedores.json";
}
