using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Repositories.ListRepositories
{
    public class UsuarioRepositoryList : RepositoryBaseList<Usuario>
    {
        public UsuarioRepositoryList() : base("Usuarios.json") { }
    }
}
