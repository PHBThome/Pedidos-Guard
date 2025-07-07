using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class FornecedorRepositoryArray : RepositoryBaseArray<Fornecedor>
{
    protected override string FilePath => "Fornecedores.json";
}
