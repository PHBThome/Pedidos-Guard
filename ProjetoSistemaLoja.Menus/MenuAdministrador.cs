namespace ProjetoSistemaLoja.Menus
{
    internal class MenuAdministrador
    {
        private RepositoriesData Repositories;

        public MenuAdministrador(RepositoriesData repositorios)
        {
            Repositories = repositorios;
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
                    Console.WriteLine("4. Gerenciar Usuarios");
                    Console.WriteLine("5.Gerenciar Pedidos");
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
                            new FornecedorMenu(Repositories.fornecedorRepository).ExibirMenu();
                            break;
                        case 2:
                            new ProdutoMenu(Repositories.produtoRepository, Repositories.fornecedorRepository).ExibirMenu();
                            break;
                        case 3:
                            new TransportadoraMenu(Repositories.transportadoraRepository).ExibirMenu();
                            break;
                        case 4:
                            new UsuarioMenu(Repositories.usuarioRepository).ExibirMenu();
                            break;
                        case 5:
                            new PedidosMenu(Repositories).ExibirMenu();
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

