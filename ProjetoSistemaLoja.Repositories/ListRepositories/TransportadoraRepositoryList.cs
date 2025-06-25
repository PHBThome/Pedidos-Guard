using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ListRepositories;

public class TransportadoraRepositoryList : RepositoryBase<Transportadora>
{
    protected override string FilePath => "TransportadorasList.json";
}
