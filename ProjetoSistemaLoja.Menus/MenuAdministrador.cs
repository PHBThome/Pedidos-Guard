using ProjetoSistemaLoja;
using ProjetoSistemaLoja.Data;

namespace ProjetoSistemaLoja.Menus
{
    internal class MenuAdministrador
    {
        private readonly LojaData LojaData;
        private RepositoriesData Repositorios;

        public MenuAdministrador(LojaData lojaData, RepositoriesData repositorios)
        {
            LojaData = lojaData;
            Repositorios = repositorios;
        }

        public void ExibirMenuAdministrador()
        {
            int opcao = -1;
            do
            {
                try
                {
                    Console.WriteLine("\n--- MENU ADMINISTRADOR ---");
                    Console.WriteLine("1. Gerenciar Fornecedores");
                    Console.WriteLine("2. Gerenciar Produtos");
                    Console.WriteLine("3. Gerenciar Transportadoras");
                    Console.WriteLine("0. Sair");
                    Console.WriteLine("Opção: ");
                    string opcaoStr = Console.ReadLine();
                    if (!int.TryParse(opcaoStr, out opcao))
                        throw new Exception("Informe uma opção válida!");

                    switch (opcao)
                    {
                        case 0:
                            break;
                        case 1:
                            new FornecedorMenu(LojaData, Repositorios.fornecedorRepository).ExibirMenu();
                            break;
                        case 2:
                            new ProdutoMenu(LojaData, Repositorios.produtoRepository).ExibirMenu();
                            break;
                        case 3:
                            new TransportadoraMenu(LojaData, Repositorios.transportadoraRepository).ExibirMenu();
                            break;
                        default:
                            Console.WriteLine("Informe uma opção válida!");
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

            } while (opcao != 0);
        }
    }
}

