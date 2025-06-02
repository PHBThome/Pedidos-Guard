using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Menus
{
    internal class LoginMenu
    {
        public bool Logar()
        {
            Console.WriteLine("Informe o usuario: ");
            string user = Console.ReadLine();
            Console.WriteLine("Informe a senha: ");
            string password = Console.ReadLine();
            
            return new UsuarioController().LoginEfetuado(new Usuario(user, password));
        }

    }
}

