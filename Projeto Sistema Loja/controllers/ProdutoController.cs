using Projeto_Sistema_Loja.data;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class ProdutoController
    {
        private readonly LojaData LojaData;

        public ProdutoController(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public string AdicionarProduto(Produto novoProduto)
        {
            if (new FornecedorController(LojaData).ObterFornecedorPorId(novoProduto.IdFornecedor) == null)
                return "Fornecedor não encontrado!";

            int posicaoLivre = -1;
            for (int i = 0; i < LojaData.Produtos.Length; i++)
            {
                if (LojaData.Produtos[i] == null)
                {
                    posicaoLivre = i;
                    break;
                }
            }

            if (posicaoLivre == -1)
                return "\nNúmero máximo de produtos atingido!";

            foreach (var p in LojaData.Produtos)
            {
                if (p != null && p.Id == novoProduto.Id)
                    return "ID do produto já existe!";
            }

            Produto[] novoArray = new Produto[LojaData.Produtos.Length];
            Array.Copy(LojaData.Produtos, novoArray, LojaData.Produtos.Length);
            novoArray[posicaoLivre] = novoProduto;
            LojaData.Produtos = novoArray;

            return "Produto adicionado com sucesso!";
        }

        public string RemoverProduto(int id)
        {
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

        public string EditarProduto(int id)
        {
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
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        Console.WriteLine("Novo valor: ");
                        p.Valor = double.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Deseja editar a quantidade? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        Console.WriteLine("Nova quantidade: ");
                        p.Quantidade = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Deseja editar o id do fornecedor? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        int idfornecedor = 0;
                        bool idValido = false;

                        while (!idValido)
                        {
                            Console.WriteLine("Novo id do fornecedor: ");
                            idfornecedor = int.Parse(Console.ReadLine());

                            if (new FornecedorController(LojaData).ObterFornecedorPorId(idfornecedor) == null)
                            {
                                Console.WriteLine("Fornecedor não encontrado! Tente novamente.");
                            }
                            else
                            {
                                idValido = true;
                            }
                        }

                        p.IdFornecedor = idfornecedor;
                    }
                    return "Produto editado com sucesso";
                }
            }
            return "Produto não encontrado";
        }
    }
}
