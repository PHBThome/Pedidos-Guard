using System;

namespace Projeto_Sistema_Loja.menus
{
    internal class MenuAdministrador
    {
        private readonly FornecedorMenu fornecedorMenu;
        private readonly ProdutoMenu produtoMenu;
        private readonly TransportadoraMenu transportadoraMenu;

        public MenuAdministrador(
            FornecedorMenu fornecedorMenu,
            ProdutoMenu produtoMenu,
            TransportadoraMenu transportadoraMenu)
        {
            this.fornecedorMenu = fornecedorMenu;
            this.produtoMenu = produtoMenu;
            this.transportadoraMenu = transportadoraMenu;
        }

        public void ExibirMenuAdministrador()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n--- MENU ADMINISTRADOR ---");
                Console.WriteLine("1. Gerenciar Fornecedores");
                Console.WriteLine("2. Gerenciar Produtos");
                Console.WriteLine("3. Gerenciar Transportadoras");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        fornecedorMenu.ExibirMenu();
                        break;
                    case 2:
                        produtoMenu.ExibirMenu();
                        break;
                    case 3:
                        transportadoraMenu.ExibirMenu();
                        break;
                }

            } while (opcao != 0);
        }
    }
}
