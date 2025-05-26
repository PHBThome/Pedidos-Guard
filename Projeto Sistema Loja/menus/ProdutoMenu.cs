using Projeto_Sistema_Loja.controllers;
using Projeto_Sistema_Loja.data;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.menus
{
    internal class ProdutoMenu
    {
        private readonly LojaData LojaData;

        public ProdutoMenu(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public void ExibirMenu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n--- MENU PRODUTO ---");
                Console.WriteLine("1. Cadastrar Produto");
                Console.WriteLine("2. Remover Produto");
                Console.WriteLine("3. Consultar Produto");
                Console.WriteLine("4. Editar Produto");
                Console.WriteLine("0. Voltar");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        RemoverProduto();
                        break;
                    case 3:
                        ConsultarProduto();
                        break;
                    case 4:
                        EditarProduto();
                        break;
                }

            } while (opcao != 0);
        }

        private void CadastrarProduto()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Valor: ");
            double valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());
            Console.Write("ID do Fornecedor: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            Produto novoProduto = new Produto(id, nome, valor, quantidade, idFornecedor);
            string resultado = new ProdutoController(LojaData).AdicionarProduto(novoProduto);
            Console.WriteLine(resultado);
        }

        private void ConsultarProduto()
        {
            Console.WriteLine("Consultar por:");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());

            ProdutoController produtoController = new ProdutoController(LojaData);

            if (opcao == 1)
            {
                Console.Write("Informe o id: ");
                int id = int.Parse(Console.ReadLine());
                var p = produtoController.ObterProdutoPorId(id);
                Console.WriteLine(p);
            }
            else
            {
                var produtos = produtoController.ObterTodosProdutos();
                foreach (var p in produtos)
                {
                    Console.WriteLine(p);
                }
            }
        }

        private void RemoverProduto()
        {
            Console.Write("Id do produto a remover: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = new ProdutoController(LojaData).RemoverProduto(id);
            Console.WriteLine(resultado);
        }

        private void EditarProduto()
        {
            Console.Write("Id do produto a editar: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = new ProdutoController(LojaData).EditarProduto(id);
            Console.WriteLine(resultado);
        }
    }
}
