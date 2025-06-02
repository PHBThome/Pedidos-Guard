using ProjetoSistemaLoja;
using ProjetoSistemaLoja.Data;

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
            bool estaLogado = new LoginMenu().Logar();

            if(estaLogado)
            {
                new MenuAdministrador(LojaData).ExibirMenuAdministrador();
            }
        }
        
    }
}

