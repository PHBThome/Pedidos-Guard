using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class FornecedorRepositoryArray : RepositoryBase<Fornecedor>
{
    protected override string FilePath => "FornecedoresArray.json";
}
