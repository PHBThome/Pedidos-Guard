using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.menus
{
    internal class LoginMenu
    {
        public Usuario Logar()
        {
            Console.WriteLine("Informe o usuario: ");
            string user = Console.ReadLine();
            Console.WriteLine("Informe a senha: ");
            string password = Console.ReadLine();

            return new Usuario(user, password);
        }

    }
}
