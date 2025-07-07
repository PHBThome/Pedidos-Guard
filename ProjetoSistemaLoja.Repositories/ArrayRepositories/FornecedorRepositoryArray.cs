using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class FornecedorRepositoryArray : RepositoryBaseArray<Fornecedor>
{
    public FornecedorRepositoryArray() : base("Fornecedores.json") { }
}
