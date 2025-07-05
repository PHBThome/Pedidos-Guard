using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Models;
using System.Linq.Expressions;
using ProjetoSistemaLoja.Repositories.Interfaces;
using Projeto_Sistema_Loja.controllers;

namespace ProjetoSistemaLoja.Menus
{
    internal class FornecedorMenu
    {

        private IRepositoryBase<Fornecedor> Repository;

        public FornecedorMenu(IRepositoryBase<Fornecedor> repositorio)
        {
            Repository = repositorio;
        }

        public void ExibirMenu()
        {
            int opcao = -1;
            do
            {
                try
                {
                    Console.WriteLine("\n--- MENU FORNECEDOR ---");
                    Console.WriteLine("1. Cadastrar Fornecedor");
                    Console.WriteLine("2. Remover Fornecedores");
                    Console.WriteLine("3. Consultar Fornecedor");
                    Console.WriteLine("4. Editar Fornecedor");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine("Opção: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out opcao))
                        throw new Exception("Digite um número válido!");

                    if (opcao <= -1 || opcao >= 5)
                        throw new Exception("Informe uma opção válida!");

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
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            } while (opcao != 0);
        }

        private void CadastrarFornecedor()
        {
            var resultado = new FornecedorService(Repository).AdicionarFornecedor();
            Console.WriteLine(resultado);
        }

        private void ConsultarFornecedor()
        {
            try
            {
                Console.WriteLine("Consultar por:");
                Console.WriteLine("1. Id");
                Console.WriteLine("2. Consulta geral");
                Console.Write("Opção: ");
                string opcaoStr = Console.ReadLine();
                if (!int.TryParse(opcaoStr, out int opcao))
                    throw new Exception("Informe uma opção válida");
                if (opcao >= 3 || opcao <= 0)
                    throw new Exception("Informe uma opção válida!");

                if (opcao == 1)
                {
                    Console.Write("Informe o id: ");
                    int id = int.Parse(Console.ReadLine());
                    var p = new FornecedorService(Repository).ObterFornecedorPorId(id);
                    Console.WriteLine(p);
                }
                else
                {
                    var fornecedores = new FornecedorService(Repository).ObterTodosFornecedores();
                    foreach (var f in fornecedores)
                    {
                        Console.WriteLine(f);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void RemoverFornecedor()
        {
            string resultado = new FornecedorService(Repository).RemoverFornecedor();
            Console.WriteLine(resultado);
        }

        private void EditarFornecedor()
        {
            string resultado = new FornecedorService(Repository).EditarFornecedor();
            Console.WriteLine(resultado);
        }
    }
}

