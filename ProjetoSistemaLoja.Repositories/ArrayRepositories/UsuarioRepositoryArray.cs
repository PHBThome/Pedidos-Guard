using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories
{
    public class UsuarioRepositoryArray: RepositoryBaseArray<Usuario>
    {
        protected override string FilePath => "Usuarios.json";
    }
}
