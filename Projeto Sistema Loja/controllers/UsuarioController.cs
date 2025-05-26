using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class UsuarioController
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
