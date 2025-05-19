namespace Projeto_Sistema_Loja
{
    internal class MenuAdministrador
    {
        public static void ExibirMenuAdministrador()
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\nMenu Administrador");
                Console.WriteLine("1. Menu Fornecedor");
                Console.WriteLine("2. Menu Produto");
                Console.WriteLine("3. Menu Transportadoras");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Fornecedor.ExibirMenuFornecedor();
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                    default:
                        return;
                }
            }
        }



    }
}
