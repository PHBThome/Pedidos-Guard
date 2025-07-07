using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class TransportadoraRepositoryArray : RepositoryBaseArray<Transportadora>
{
    protected override string FilePath => "Transportadoras.json";
}
