using Projeto_Sistema_Loja.controllers;
using Projeto_Sistema_Loja.menus;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja
{
    internal class Menu
    {
        private readonly MenuAdministrador menuAdministrador;
        private readonly LoginMenu login;
        private readonly UsuarioController usuarioController;

        public Menu()
        {
            var enderecoMenu = new EnderecoMenu();
            var fornecedorController = new FornecedorController();
            var produtoController = new ProdutoController(fornecedorController);
            var transportadoraController = new TransportadoraController();
            
            usuarioController = new UsuarioController();
            login = new LoginMenu();
            menuAdministrador = new MenuAdministrador(
                new FornecedorMenu(fornecedorController, enderecoMenu),
                new ProdutoMenu(produtoController, fornecedorController),
                new TransportadoraMenu(transportadoraController, enderecoMenu)
            );
        }

        public void Exibir()
        {
            var usuario = login.Logar();
            int opcao = usuarioController.LoginEfetuado(usuario);

            if(opcao == 1)
            {
                menuAdministrador.ExibirMenuAdministrador();
            }
            
        }
        
    }
}
