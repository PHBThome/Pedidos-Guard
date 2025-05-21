using Projeto_Sistema_Loja.controllers;
using Projeto_Sistema_Loja.menus;

namespace Projeto_Sistema_Loja
{
    internal class Menu
    {
        private readonly MenuAdministrador menuAdministrador;

        public Menu()
        {
            var enderecoMenu = new EnderecoMenu();
            var fornecedorController = new FornecedorController();
            var produtoController = new ProdutoController(fornecedorController);
            var transportadoraController = new TransportadoraController();
            menuAdministrador = new MenuAdministrador(
                new FornecedorMenu(fornecedorController, enderecoMenu),
                new ProdutoMenu(produtoController, fornecedorController),
                new TransportadoraMenu(transportadoraController, enderecoMenu)
            );
        }

        public void Exibir()
        {
            menuAdministrador.ExibirMenu();
        }
    }
}
