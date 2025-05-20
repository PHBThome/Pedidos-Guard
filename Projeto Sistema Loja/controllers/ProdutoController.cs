using Projeto_Sistema_Loja.models;
using Projeto_Sistema_Loja.controllers;

namespace Projeto_Sistema_Loja.controllers
{
    internal class ProdutoController
    {
        private static Produto[] produtos = new Produto[200];
        private static int produtosCount = 0;

        public static string AdicionarProduto(Produto novoProduto)
        {
            if (produtosCount >= produtos.Length)
                return "\nNúmero máximo de produtos atingido!";

            if (FornecedorController.ObterFornecedorPorId(novoProduto.IdFornecedor) == null)
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

        public static string RemoverProduto(int id)
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

        public static Produto ObterProdutoPorId(int id)
        {
            foreach (Produto p in produtos)
            {
                if (p != null && p.Id == id)
                    return p;
            }
            return null;
        }

        public static Produto[] ObterTodosProdutos()
        {
            Produto[] lista = new Produto[produtosCount];
            Array.Copy(produtos, lista, produtosCount);
            return lista;
        }

        public static string EditarProduto(int id, Produto dadosAtualizados)
        {
            for (int i = 0; i < produtosCount; i++)
            {
                if (produtos[i].Id == id)
                {
                    if (FornecedorController.ObterFornecedorPorId(dadosAtualizados.IdFornecedor) == null)
                        return "Fornecedor inválido!";

                    produtos[i] = dadosAtualizados;
                    return "Produto atualizado com sucesso!";
                }
            }
            return "Produto não encontrado!";
        }
    }
}