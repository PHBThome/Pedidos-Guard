using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories;

public class TransportadoraRepositoryArray : RepositoryBase<Transportadora>
{
    protected override string FilePath => "TransportadorasArray.json";
}
