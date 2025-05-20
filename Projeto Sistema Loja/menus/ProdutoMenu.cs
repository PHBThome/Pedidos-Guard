using Projeto_Sistema_Loja.models;
using Projeto_Sistema_Loja.controllers;

namespace Projeto_Sistema_Loja.menus
{
    internal class ProdutoMenu
    {
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
                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        IncluirProduto();
                        break;
                    case 2:
                        RemoverProduto();
                        break;
                    case 3:
                        EditarProduto();
                        break;
                    case 4:
                        ConsultarProduto();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void IncluirProduto()
        {
            Console.Write("\nNome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Valor: ");
            double valor = double.Parse(Console.ReadLine());

            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("ID do fornecedor: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            Produto novoProduto = new Produto
            {
                Nome = nome,
                Valor = valor,
                Quantidade = quantidade,
                Id = id,
                IdFornecedor = idFornecedor
            };

            Console.WriteLine(ProdutoController.AdicionarProduto(novoProduto));
        }

        private static void RemoverProduto()
        {
            Console.Write("\nID do produto a remover: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(ProdutoController.RemoverProduto(id));
        }

        private static void ConsultarProduto()
        {
            Console.WriteLine("\nConsultar por:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Todos");
            Console.Write("Escolha: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("\nID do produto: ");
                    int id = int.Parse(Console.ReadLine());
                    Produto p = ProdutoController.ObterProdutoPorId(id);

                    if (p != null)
                        ExibirDetalhesProduto(p);
                    else
                        Console.WriteLine("Produto não encontrado!");
                    break;

                case 2:
                    Produto[] todos = ProdutoController.ObterTodosProdutos();
                    foreach (Produto produto in todos)
                        ExibirDetalhesProduto(produto);
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        private static void EditarProduto()
        {
            Console.Write("\nID do produto a editar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();

            Console.Write("Novo valor: ");
            double valor = double.Parse(Console.ReadLine());

            Console.Write("Nova quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Novo ID do fornecedor: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            Produto dadosAtualizados = new Produto
            {
                Nome = nome,
                Valor = valor,
                Quantidade = quantidade,
                Id = id,
                IdFornecedor = idFornecedor
            };

            Console.WriteLine(ProdutoController.EditarProduto(id, dadosAtualizados));
        }

        private static void ExibirDetalhesProduto(Produto produto)
        {
            Console.WriteLine("\n--------------------------");
            Console.WriteLine($"ID: {produto.Id}");
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Valor: {produto.Valor:C}");
            Console.WriteLine($"Quantidade: {produto.Quantidade}");
            Console.WriteLine($"Fornecedor ID: {produto.IdFornecedor}");
            Console.WriteLine("--------------------------");
        }
    }
}