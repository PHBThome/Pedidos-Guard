using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories
{
    public class UsuarioRepositoryArray: RepositoryBaseArray<Usuario>
    {
        public UsuarioRepositoryArray() : base("Usuarios.json") { }
    }
}
