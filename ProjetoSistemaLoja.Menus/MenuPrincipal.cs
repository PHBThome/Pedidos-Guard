using ProjetoSistemaLoja;
using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Data;
using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Menus
{
    public class MenuPrincipal
    {
        private readonly LojaData LojaData;

        public MenuPrincipal(LojaData lojaData)
        {
            LojaData = lojaData;

        }

        public void Exibir()
        {
            Usuario atual = new LoginMenu(LojaData).Logar();
            bool estaLogado = new UsuarioService(LojaData).LoginEfetuado(atual);

            if(estaLogado)
            {
                if (new UsuarioService(LojaData).IsAdmin(atual))
                    new MenuAdministrador(LojaData).ExibirMenuAdministrador();
                Console.WriteLine("Aqui sera a implementação do menu usuario");
                Console.ReadKey();
            }
           
        }
        
    }
}

