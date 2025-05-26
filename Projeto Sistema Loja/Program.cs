using Projeto_Sistema_Loja.data;
using Projeto_Sistema_Loja.menus;

namespace Projeto_Sistema_Loja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao sistema de pedidos da loja!");

            var lojaData = new LojaData();

            Seeds.Popular(lojaData);

            new MenuPrincipal(lojaData).Exibir();
        }
    }
}
