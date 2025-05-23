using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class ProdutoController
    {
        private Produto[] produtos = new Produto[200];
        private int produtosCount = 0;
        private FornecedorController fornecedorController;

        public ProdutoController(FornecedorController fornecedorController)
        {
            this.fornecedorController = fornecedorController;
        }

        public string AdicionarProduto(Produto novoProduto)
        {
            if (produtosCount >= produtos.Length)
                return "\nNúmero máximo de produtos atingido!";

            if (fornecedorController.ObterFornecedorPorId(novoProduto.IdFornecedor) == null)
                return "Fornecedor não encontrado!";

            foreach (Produto p in produtos)
            {
                if (p == null) continue;
                if (p.Id == novoProduto.Id)
                    return "ID do produto já existe!";
            }

            produtos[produtosCount++] = novoProduto;
            return "Produto adicionado com sucesso!";
        }

        public string RemoverProduto(int id)
        {
            for (int i = 0; i < produtosCount; i++)
            {
                if (produtos[i].Id == id)
                {
                    for (int j = i; j < produtosCount - 1; j++)
                        produtos[j] = produtos[j + 1];

                    produtos[--produtosCount] = null;
                    return "Produto removido com sucesso!";
                }
            }
            return "Produto não encontrado!";
        }

        public Produto ObterProdutoPorId(int id)
        {
            foreach (Produto p in produtos)
            {
                if (p != null && p.Id == id)
                    return p;
            }
            return null;
        }

        public Produto[] ObterTodosProdutos()
        {
            Produto[] lista = new Produto[produtosCount];
            Array.Copy(produtos, lista, produtosCount);
            return lista;
        }


        public string EditarProduto(int id)
        {
            for (int i = 0; i < produtosCount; i++)
            {
                if (produtos[i].Id == id)
                {
                    var p = produtos[i];
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

                            foreach (Produto t in produtos)
                            {
                                if (t == null) continue;
                                if (t.Nome.ToLower() == nome.ToLower())
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

                            if (fornecedorController.ObterFornecedorPorId(idfornecedor) == null)
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
