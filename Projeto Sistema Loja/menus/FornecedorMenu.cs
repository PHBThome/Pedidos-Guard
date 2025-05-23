using Projeto_Sistema_Loja.controllers;
using Projeto_Sistema_Loja.models;
using System;

namespace Projeto_Sistema_Loja.menus
{
    internal class FornecedorMenu
    {
        private readonly FornecedorController fornecedorController;
        private readonly EnderecoMenu enderecoMenu;

        public FornecedorMenu(FornecedorController controller, EnderecoMenu enderecoMenu)
        {
            fornecedorController = controller;
            this.enderecoMenu = enderecoMenu;
        }

        public void ExibirMenu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n--- MENU FORNECEDOR ---");
                Console.WriteLine("1. Cadastrar Fornecedor");
                Console.WriteLine("2. Remover Fornecedores");
                Console.WriteLine("3. Consultar Fornecedor");
                Console.WriteLine("4. Editar Fornecedor");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarFornecedor();
                        break;
                    case 2:
                        RemoverFornecedor();
                        break;
                    case 3:
                        ConsultarFornecedor();
                        break;
                    case 4:
                        EditarFornecedor();
                        break;
                }

            } while (opcao != 0);
        }

        private void CadastrarFornecedor()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Telefone: ");
            string telefone = Console.ReadLine();
            Endereco endereco = enderecoMenu.CadastrarEndereco();

            var novoFornecedor = new Fornecedor(id, nome, email, telefone, endereco);
            string resultado = fornecedorController.AdicionarFornecedor(novoFornecedor);
            Console.WriteLine(resultado);
        }

        private void ConsultarFornecedor()
        {
            Console.WriteLine("Consultar por:");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Informe o id:");
                int id = int.Parse(Console.ReadLine());
                var f = fornecedorController.ObterFornecedorPorId(id);
                Console.WriteLine(f);
            }
            else
            {
                var fornecedores = fornecedorController.ObterTodosFornecedores();
                foreach (var f in fornecedores)
                {
                    Console.WriteLine(f);
                }
            }
        }

        private void RemoverFornecedor()
        {
            Console.Write("Id do fornecedor a remover: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = fornecedorController.RemoverFornecedor(id);
            Console.WriteLine(resultado);
        }

        private void EditarFornecedor()
        {
            Console.WriteLine("Id do fornecedor a editar: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = fornecedorController.EditarFornecedor(id);
            Console.WriteLine(resultado);
        }
    }
}
