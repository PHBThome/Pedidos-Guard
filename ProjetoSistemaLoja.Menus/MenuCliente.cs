using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Controllers;

namespace ProjetoSistemaLoja.Menus
{
    internal class MenuCliente
    {
        private RepositoriesData Repositories;

        public MenuCliente(RepositoriesData repositorios)
        {
            Repositories = repositorios;
        }

        public void ExibirMenuCliente(Usuario atual)
        {
            int opcao = -1;
            do
            {
                try
                {
                    Console.WriteLine("\n--- MENU ---");
                    Console.WriteLine("1. Fazer Pedido");
                    Console.WriteLine("2. Ver meus Pedidos");
                    Console.WriteLine("0. Sair");
                    Console.WriteLine("Opção: ");
                    string opcaoStr = Console.ReadLine();
                    if (!int.TryParse(opcaoStr, out opcao))
                        throw new Exception("Informe uma opção válida!");

                    switch (opcao)
                    {
                        case 0:
                            return;
                        case 1:
                            new PedidoService(Repositories.pedidoRepository, Repositories.produtoRepository, 
                                Repositories.transportadoraRepository,atual).FazerPedido();
                            break;
                        case 2:
                            new PedidoService(Repositories.pedidoRepository, Repositories.produtoRepository, 
                                Repositories.transportadoraRepository, atual).MeusPedidos();
                            break;
                        default:
                            Console.WriteLine("Informe uma opção válida!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

            } while (opcao != 0);
        }
    }
}
