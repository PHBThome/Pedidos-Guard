using ProjetoSistemaLoja.Menus;
using ProjetoSistemaLoja.Data;

namespace ProjetoSistemaLoja
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

