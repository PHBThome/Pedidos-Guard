using Projeto_Sistema_Loja.data;

namespace Projeto_Sistema_Loja.menus
{
    internal class MenuAdministrador
    {
        private readonly LojaData LojaData;

        public MenuAdministrador(LojaData lojaData)
        {
            LojaData = lojaData;
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
                        new FornecedorMenu(LojaData).ExibirMenu();
                        break;
                    case 2:
                        new ProdutoMenu(LojaData).ExibirMenu();
                        break;
                    case 3:
                        new TransportadoraMenu(LojaData).ExibirMenu();
                        break;
                }

            } while (opcao != 0);
        }
    }
}
