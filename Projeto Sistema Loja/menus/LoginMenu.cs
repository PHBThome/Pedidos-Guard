using Projeto_Sistema_Loja.controllers;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.menus
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
