using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class FornecedorController
    {
        private static Fornecedor[] fornecedores = new Fornecedor[100];
        private static int fornecedorCount = 0;

        public static string AdicionarFornecedor(Fornecedor novoFornecedor)
        {
            if (fornecedorCount >= fornecedores.Length)
                return "\nNúmero máximo de fornecedores atingido!";

            foreach (Fornecedor f in fornecedores)
            {
                if (f == null) continue;
                if (f.Id == novoFornecedor.Id)
                    return "Código já existente!";
                if (f.Nome == novoFornecedor.Nome)
                    return "Nome já existente!";
            }

            fornecedores[fornecedorCount++] = novoFornecedor;
            return "Fornecedor incluído com sucesso!";
        }

        public static string RemoverFornecedor(int id)
        {
            for (int i = 0; i < fornecedorCount; i++)
            {
                if (fornecedores[i].Id == id)
                {
                    for (int j = i; j < fornecedorCount - 1; j++)
                        fornecedores[j] = fornecedores[j + 1];

                    fornecedores[--fornecedorCount] = null;
                    return "Fornecedor excluído com sucesso!";
                }
            }
            return "Fornecedor não encontrado!";
        }

        public static Fornecedor ObterFornecedorPorId(int id)
        {
            foreach (Fornecedor f in fornecedores)
            {
                if (f != null && f.Id == id)
                    return f;
            }
            return null;
        }

        public static Fornecedor[] ObterTodosFornecedores()
        {
            Fornecedor[] lista = new Fornecedor[fornecedorCount];
            Array.Copy(fornecedores, lista, fornecedorCount);
            return lista;
        }
    }
}