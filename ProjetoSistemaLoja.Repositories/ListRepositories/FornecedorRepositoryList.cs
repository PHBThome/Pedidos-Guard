using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ListRepositories;

public class FornecedorRepositoryList : RepositoryBaseList<Fornecedor>
{
    public FornecedorRepositoryList() : base("Fornecedores.json") { }
}
