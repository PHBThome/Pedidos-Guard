using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ListRepositories;

public class FornecedorRepositoryList : RepositoryBase<Fornecedor>
{
    protected override string FilePath => "FornecedoresList.json";
}
