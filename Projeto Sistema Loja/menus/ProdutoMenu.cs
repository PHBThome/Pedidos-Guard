using Projeto_Sistema_Loja.controllers;
using Projeto_Sistema_Loja.models;
using System;

namespace Projeto_Sistema_Loja.menus
{
    internal class ProdutoMenu
    {
        private readonly ProdutoController produtoController;
        private readonly FornecedorController fornecedorController;

        public ProdutoMenu(ProdutoController produtoController, FornecedorController fornecedorController)
        {
            this.produtoController = produtoController;
            this.fornecedorController = fornecedorController;
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
                Console.WriteLine("4. Editar Produto"); //falta implementar
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
                        Console.WriteLine();
                        break;
                }

            } while (opcao != 0);
        }

        private void CadastrarProduto()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Valor: ");
            double valor = double.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());
            Console.Write("ID do Fornecedor: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            Produto novoProduto = new Produto(id, valor, quantidade, idFornecedor);
            string resultado = produtoController.AdicionarProduto(novoProduto);
            Console.WriteLine(resultado);
        }

        private void ConsultarProduto()
        {
            Console.WriteLine("Consultar por: ");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Informe o id:");
                int id = int.Parse(Console.ReadLine());
                var p = produtoController.ObterProdutoPorId(id);
                Console.WriteLine(p);
                return;
            }
            else
            {
                Produto[] produtos = produtoController.ObterTodosProdutos();
                foreach (Produto p in produtos)
                {
                    Console.WriteLine(p);
                }
                return;
            }
        }

        private void RemoverProduto()
        {
            Console.Write("ID do produto a remover: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = produtoController.RemoverProduto(id);
            Console.WriteLine(resultado);
        }
    }
}
