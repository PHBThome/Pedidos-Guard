using ProjetoSistemaLoja.Menus;

namespace ProjetoSistemaLoja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int isArray = 0;

            while(isArray != 1 && isArray !=2){
                Console.WriteLine("Quer salvar em Array ou em List? \n 1 - Array \n 2 - List");
                isArray = int.Parse(Console.ReadLine());
            }

            RepositoriesData repositorios = new RepositoriesData(isArray);
            
            Console.WriteLine("Bem vindo ao sistema de pedidos da loja!");

            new MenuPrincipal(repositorios).Exibir();
        }
    }
}

