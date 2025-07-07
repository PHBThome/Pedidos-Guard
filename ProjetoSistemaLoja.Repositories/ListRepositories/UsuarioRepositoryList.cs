using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Repositories.ListRepositories
{
    public class UsuarioRepositoryList : RepositoryBaseList<Usuario>
    {
        protected override string FilePath => "Usuarios.json";
    }
}
