using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Controllers
{
    public class UsuarioController
    {
        public bool LoginEfetuado(Usuario usuario)
        {
            if (usuario.User == "admin" && usuario.Password == "1234")
            {
                return true;
            }

            return false;
        }
    }
}

