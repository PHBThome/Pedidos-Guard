using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Data;
using Projeto_Sistema_Loja.controllers;
using System.Text.Json;

namespace ProjetoSistemaLoja.Menus
{
    internal class ProdutoMenu
    {
        private readonly LojaData LojaData;

        private RepositoryBase<Transportadora> Repository;

        public ProdutoMenu(RepositoryBase<Transportadora> repositorio)
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
                    Console.WriteLine("\n--- MENU PRODUTO ---");
                    Console.WriteLine("1. Cadastrar Produto");
                    Console.WriteLine("2. Remover Produto");
                    Console.WriteLine("3. Consultar Produto");
                    Console.WriteLine("4. Editar Produto");
                    Console.WriteLine("0. Voltar");
                    Console.Write("Op��o: ");
                    string opcaoStr = Console.ReadLine();
                    if (!int.TryParse(opcaoStr, out opcao))
                        throw new Exception("Informe uma op��o v�lida!");

                    switch (opcao)
                    {
                        case 0:
                            break;
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
                        case 5:
                            TesteSerializacao();
                            break;
                        default:
                            Console.WriteLine("Informe uma op��o v�lida!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            } while (opcao != 0);
        }

        private void CadastrarProduto()
        {
            string resultado = new ProdutoService(Repository).AdicionarProduto();
            Console.WriteLine(resultado);
        }

        private void ConsultarProduto()
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
                    var p = new ProdutoService(Repository).ObterProdutoPorId(id);
                    Console.WriteLine(p);
                }
                else
                {
                    var produtos = new ProdutoService(Repository).ObterTodosProdutos();
                    foreach (var p in produtos)
                    {
                        Console.WriteLine(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void RemoverProduto()
        {
            string resultado = new ProdutoService(Repository).RemoverProduto();
            Console.WriteLine(resultado);
        }

        private void EditarProduto()
        {
            string resultado = new ProdutoService(Repository).EditarProduto();
            Console.WriteLine(resultado);
        }
        private void TesteSerializacao()
        {

            Produto[] aaa = LojaData.Produtos.Where(x => x != null).ToArray();

            string todosProdutos = JsonSerializer.Serialize(aaa);
            File.WriteAllText("produtos.json", todosProdutos);

            string ProdutosLista = File.ReadAllText("produtos.json");

            Produto[] aaaa = JsonSerializer.Deserialize<Produto[]>(ProdutosLista);


            foreach (var item in aaaa)
            {
                Console.WriteLine(item);
            }

        }
    }
}

