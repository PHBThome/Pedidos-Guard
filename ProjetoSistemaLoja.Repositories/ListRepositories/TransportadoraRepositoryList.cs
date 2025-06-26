using System;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Repositories.ListRepositories;

public class TransportadoraRepositoryList : RepositoryBaseList<Transportadora>
{
    protected override string FilePath => "TransportadorasList.json";
}
