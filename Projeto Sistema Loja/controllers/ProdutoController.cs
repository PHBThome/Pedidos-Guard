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

    }
}
