using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Repositories.ArrayRepositories
{
    public class UsuarioRepositoryArray: RepositoryBaseArray<Usuario>
    {
        protected override string FilePath => "Usuarios.json";
    }
}
