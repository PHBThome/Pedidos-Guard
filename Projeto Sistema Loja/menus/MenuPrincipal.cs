using Projeto_Sistema_Loja.data;

namespace Projeto_Sistema_Loja.menus
{
    internal class MenuPrincipal
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
