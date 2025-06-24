using ProjetoSistemaLoja;
using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Data;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Menus
{
    public class MenuPrincipal
    {
        private readonly LojaData LojaData;

        private Repositories Repositorios;

        public MenuPrincipal(LojaData lojaData, Repositories repositorios)
        {
            LojaData = lojaData;
            Repositorios = repositorios;
        }

        public void Exibir()
        {
            Usuario atual = new LoginMenu(LojaData).Logar();
            bool estaLogado = new UsuarioController(LojaData).LoginEfetuado(atual);

            if(estaLogado)
            {
                if (new UsuarioController(LojaData).IsAdmin(atual))
                    new MenuAdministrador(LojaData, Repositorios).ExibirMenuAdministrador();
                Console.WriteLine("Aqui sera a implementação do menu usuario");
                Console.ReadKey();
            }
           
        }
        
    }
}

