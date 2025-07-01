using ProjetoSistemaLoja;
using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Data;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Menus
{
    public class MenuPrincipal
    {
        private readonly LojaData LojaData;

        private RepositoriesData Repositories { get; set; }

        public MenuPrincipal(LojaData lojaData, RepositoriesData repositorios)
        {
            LojaData = lojaData;
            Repositories = repositorios;
        }

        public void Exibir()
        {
            Usuario atual = new LoginMenu(LojaData).Logar();
            bool estaLogado = new UsuarioService(LojaData).LoginEfetuado(atual);

            if(estaLogado)
            {
                if (new UsuarioService(LojaData).IsAdmin(atual))
                    new MenuAdministrador(Repositories).ExibirMenuAdministrador();
                Console.WriteLine("Aqui sera a implementao do menu usuario");
                Console.ReadKey();
            }
           
        }
        
    }
}

