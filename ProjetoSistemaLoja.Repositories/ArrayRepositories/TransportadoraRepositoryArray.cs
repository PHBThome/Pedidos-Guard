using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class TransportadoraRepositoryArray : RepositoryBaseArray<Transportadora>
{
    public TransportadoraRepositoryArray() : base("Transportadoras.json") { }
}
