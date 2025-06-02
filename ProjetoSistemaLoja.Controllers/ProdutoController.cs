using System.Xml;
using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Data;
using ProjetoSistemaLoja.Models;

namespace Projeto_Sistema_Loja.controllers
{
    public class ProdutoController
    {
        private readonly LojaData LojaData;

        public ProdutoController(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public string AdicionarProduto()
        {
            try
            {
                int produtoCount = LojaData.Fornecedores.Count(f => f != null);

                if (produtoCount >= LojaData.Produtos.Length)
                    return "\nNúmero máximo de produtos atingido!";

                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Informe um nome válido!");

                foreach (var p in LojaData.Produtos)
                {
                    if (p != null && p.Nome == nome)
                        throw new Exception("Nome já existente!");
                }

                Console.Write("Valor: ");
                double valor = double.Parse(Console.ReadLine());
                if (valor <= 0)
                    throw new Exception("Informe um valor válido!");

                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());
                if (quantidade < 0)
                    throw new Exception("Informe uma quantidade válida");

                Console.Write("ID do Fornecedor: ");
                int idFornecedor = int.Parse(Console.ReadLine());
                if (new FornecedorController(LojaData).ObterFornecedorPorId(idFornecedor) == null)
                    throw new Exception("Fornecedor não encontrado!");

                int id = produtoCount + 1;

                Produto novoProduto = new Produto(id, nome, valor, quantidade, idFornecedor);

                int posicaoLivre = -1;
                for (int i = 0; i < LojaData.Produtos.Length; i++)
                {
                    if (LojaData.Produtos[i] == null)
                    {
                        posicaoLivre = i;
                        break;
                    }
                }

                Produto[] novoArray = new Produto[LojaData.Produtos.Length];
                Array.Copy(LojaData.Produtos, novoArray, LojaData.Produtos.Length);
                novoArray[posicaoLivre] = novoProduto;
                LojaData.Produtos = novoArray;

                return "Produto adicionado com sucesso!";
            }
            catch(Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public string RemoverProduto()
        {
            try
            {
                Console.Write("Id do produto a remover: ");
                int id = int.Parse(Console.ReadLine());
                bool existe = false;
                foreach(Produto p in LojaData.Produtos)
                {
                    if (p == null) continue;
                    if (p.Id == id) existe = true;
                }
                if (!existe)
                    throw new Exception("Informe um id existente");

                for (int i = 0; i < LojaData.Produtos.Length; i++)
                {
                    if (LojaData.Produtos[i] != null && LojaData.Produtos[i].Id == id)
                    {
                        LojaData.Produtos[i] = null;
                        return "Produto removido com sucesso!";
                    }
                }
                return "Produto não encontrado!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Produto? ObterProdutoPorId(int id)
        {
            foreach (Produto p in LojaData.Produtos)
            {
                if (p != null && p.Id == id)
                    return p;
            }
            return null;
        }

        public Produto[] ObterTodosProdutos()
        {
            return LojaData.Produtos.Where(p => p != null).ToArray();
        }

        public string EditarProduto()
        {
            try
            {
                Console.WriteLine("Id do produto a editar: ");
                int id = int.Parse(Console.ReadLine());
                bool existe = false;
                foreach(Produto p in LojaData.Produtos)
                {
                    if (p == null) continue;
                    if (p.Id == id) existe = true;
                }
                if (!existe)
                    throw new Exception("Informe um id existente!");

                for (int i = 0; i < LojaData.Produtos.Length; i++)
                {
                    if (LojaData.Produtos[i] != null && LojaData.Produtos[i].Id == id)
                    {
                        var p = LojaData.Produtos[i];
                        Console.WriteLine($"Produto atual:\n{p}");

                        Console.WriteLine($"Deseja alterar o nome? (s/n)");
                        string nome = " ";
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            bool nomeValido = false;

                            while (!nomeValido)
                            {
                                Console.WriteLine("Novo nome: ");
                                nome = Console.ReadLine();

                                bool nomeExistente = false;

                                foreach (Produto t in LojaData.Produtos)
                                {
                                    if (t != null && t.Nome.ToLower() == nome.ToLower())
                                    {
                                        Console.WriteLine("Nome já existente! Tente novamente.");
                                        nomeExistente = true;
                                        break;
                                    }
                                }

                                if (!nomeExistente)
                                {
                                    nomeValido = true;
                                }
                            }
                            p.Nome = nome;
                        }

                        Console.WriteLine("Deseja editar o valor? (s/n)");
                        double valor = 0;
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            bool valorValido = false;

                            while (!valorValido)
                            {
                                Console.WriteLine("Novo valor: ");
                                string valorStr = Console.ReadLine();
                                if (!double.TryParse(valorStr, out valor))
                                    Console.WriteLine("Informe um valor válido");
                                else
                                    valorValido = true;
                            }
                            p.Valor = valor;
                        }

                        Console.WriteLine("Deseja editar a quantidade? (s/n)");
                        int quantidade = 0;
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            bool quantidadeValida = false;

                            while (!quantidadeValida)
                            {
                                Console.WriteLine("Nova quantidade: ");
                                string quantidadeStr = Console.ReadLine();
                                if(!int.TryParse(quantidadeStr,out quantidade))
                                    Console.WriteLine("Informe um quantidade válida!");
                                else
                                    quantidadeValida = true;
                            }
                            p.Quantidade = quantidade;
                        }

                        Console.WriteLine("Deseja editar o id do fornecedor? (s/n)");
                        int idfornecedor = 0;
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            bool idValido = false;

                            while (!idValido)
                            {
                                Console.WriteLine("Novo id do fornecedor: ");
                                string idfornecedorStr = Console.ReadLine();
                                while (!idValido)
                                {
                                    if (!int.TryParse(idfornecedorStr, out idfornecedor))
                                        Console.WriteLine("Informe um id de fornecedor válido!");
                                    else
                                        idValido = true;
                                }

                                if (new FornecedorController(LojaData).ObterFornecedorPorId(idfornecedor) == null)
                                {
                                    Console.WriteLine("Fornecedor não encontrado! Tente novamente.");
                                    idValido = false;
                                }
                                else
                                {
                                    idValido = true;
                                }
                            }
                        }
                        p.IdFornecedor = idfornecedor;
                        return "Produto editado com sucesso";
                    }
                }
                return "Produto não encontrado";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }
    }
}