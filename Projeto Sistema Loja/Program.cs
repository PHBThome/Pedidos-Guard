namespace Projeto_Sistema_Loja
{
    internal class Program
    {
        static Produto[] produtos = new Produto[100];
        static Transportadora[] transportadoras = new Transportadora[100];

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao sistema de pedidos da loja!");
            Menu.Login();
        }
    }
}
