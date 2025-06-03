using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Data;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Menus
{
    internal class LoginMenu
    {
        private readonly LojaData LojaData;
        public LoginMenu(LojaData lojaData)
        {
            LojaData = lojaData;
        }
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

