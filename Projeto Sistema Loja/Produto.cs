namespace Projeto_Sistema_Loja
{
    internal class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int Id { get; set; }
        public int IdFornecedor { get; set; }


        public static Produto[] produtos = new Produto[200];
        public static int produtosCount = 0;

        public static void ExibirMenuProduto()
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\nMenu Produto");
                Console.WriteLine("1. Incluir produto");
                Console.WriteLine("2. Remover produto");
                Console.WriteLine("3. Editar produto");
                Console.WriteLine("4. Consultar produto");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Escolha uma opção:");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine();
                        break;
                    default:
                        return;
                }
            }
        }

        public static void IncluirProduto()
        {
            if (produtosCount >= produtos.Length)
            {
                Console.WriteLine("\nNumero máximo de produtos atingido!");
                return;
            }

            Console.WriteLine("Informe o nome do produto:");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o valor do produto:");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o quantidade:");
            int quantidade = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o id do produto:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o id do fornecedor:");
            int idfornecedor = int.Parse(Console.ReadLine());

            for (int i = 0; i < Fornecedor.fornecedorCount; i++)
            {
                if (idfornecedor == Fornecedor.fornecedores[i].Id)
                {
                    continue;
                }
                Console.WriteLine("Id de fornecedor nao existente!");
                return;
            }

            produtos[produtosCount++] = new Produto()
            {
                Nome = nome,
                Valor = valor,
                Quantidade = quantidade,
                Id = id,
                IdFornecedor = idfornecedor
            };
            Console.WriteLine("Produto incluido com sucesso!");
        }

        public static void RemoverProduto()
        {
            Console.WriteLine("Informe o id do produto a ser removido:");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < produtosCount; i++)
            {
                if (produtos[i].Id != id)
                {
                    for (int j = i; j < produtosCount - 1; j++)
                    {
                        produtos[j] = produtos[j + 1];
                    }

                    produtos[--produtosCount] = null;
                    Console.WriteLine("Produto removido!");
                    return;
                }
            }
        }

        public static void ConsultarProduto()
        {
            Console.WriteLine("Consultar por:");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o id:");
                    int id = int.Parse(Console.ReadLine());

                    for (int i = 0; i < produtosCount; i++)
                    {
                        if (produtos[i].Id == id)
                        {
                            Console.WriteLine($"Nome: {produtos[i].Nome}");
                            Console.WriteLine($"Valor: {produtos[i].Valor}");
                            Console.WriteLine($"Quantidade: {produtos[i].Quantidade}");
                            Console.WriteLine($"Id: {produtos[i].Id}");
                            Console.WriteLine($"Id fornecedor: {produtos[i].IdFornecedor}");
                            return;
                        }
                    }

                    Console.WriteLine("Produto não encontrado.");
                    break;

                case 2:
                    for (int i = 0; i < produtosCount; i++)
                    {
                        Console.WriteLine($"\nNome: {produtos[i].Nome}");
                        Console.WriteLine($"Valor: {produtos[i].Valor}");
                        Console.WriteLine($"Quantidade: {produtos[i].Quantidade}");
                        Console.WriteLine($"Id: {produtos[i].Id}");
                        Console.WriteLine($"Id fornecedor: {produtos[i].IdFornecedor}");
                    }
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }


        public static void EditarProduto()
        {

        }
    }
}
