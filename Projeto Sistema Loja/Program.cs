using Projeto_Sistema_Loja.menus;

namespace Projeto_Sistema_Loja
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao sistema de pedidos da loja!");
            var menu = new Menu();
            menu.Exibir();
            
        }
    }
}
