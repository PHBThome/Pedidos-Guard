using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ListRepositories;

public class TransportadoraRepositoryList : RepositoryBaseList<Transportadora>
{
    public TransportadoraRepositoryList() : base("Transportadoras.json") { }
}
