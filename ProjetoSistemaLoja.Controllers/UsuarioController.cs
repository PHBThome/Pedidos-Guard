using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Data;

namespace ProjetoSistemaLoja.Controllers
{
    public class UsuarioController
    {
        private readonly LojaData LojaData;
        public UsuarioController(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public bool LoginEfetuado(Usuario usuario)
        {
            if (usuario.User == "admin" && usuario.Password == "1234")
                return true;

            foreach (Usuario u in LojaData.Usuarios)
            {
                if (u.User == usuario.User && u.Password == usuario.Password)
                    return true;
            }
            return false;
        }

        public bool IsAdmin(Usuario usuario)
        {
            return usuario.User == "admin" && usuario.Password == "1234";
        }
    }
}

