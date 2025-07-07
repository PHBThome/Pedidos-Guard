using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Menus
{
    public class MenuPrincipal
    {
        private RepositoriesData Repositories { get; set; }

        public MenuPrincipal(RepositoriesData repositorios)
        {
            Repositories = repositorios;
        }

        public void Exibir()
        {
            Usuario atual = null;
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Registrar");
            Console.WriteLine("0. Sair");
            bool opcaoValido = false;
            int opcao = 1;
            while (!opcaoValido)
            {
                string opcaoStr = Console.ReadLine();
                if(!int.TryParse(opcaoStr, out opcao))
                    Console.WriteLine("Informe uma opção válida!");
                else
                    opcaoValido = true;
            }

            switch (opcao)
            {
                case 1:
                    atual = new LoginMenu(Repositories.usuarioRepository).Logar();
                    break;
                case 2:
                    new LoginMenu(Repositories.usuarioRepository).Registrar();
                    atual = new LoginMenu(Repositories.usuarioRepository).Logar();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Opcão inválida!");
                    return;

            }

            if (atual.User == "admin" && atual.Password == "1234")
                new MenuAdministrador(Repositories).ExibirMenuAdministrador();
            else
                new MenuCliente(Repositories).ExibirMenuCliente(atual);
                Console.ReadKey();
        }
        
    }
}

