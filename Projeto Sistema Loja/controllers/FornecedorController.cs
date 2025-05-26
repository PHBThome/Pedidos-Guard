using Projeto_Sistema_Loja.data;
using Projeto_Sistema_Loja.menus;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class FornecedorController
    {
        private readonly LojaData LojaData;

        public FornecedorController(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public string AdicionarFornecedor(Fornecedor novoFornecedor)
        {
            int fornecedorCount = LojaData.Fornecedores.Count(f => f != null);

            if (fornecedorCount >= LojaData.Fornecedores.Length)
                return "\nNúmero máximo de fornecedores atingido!";

            foreach (Fornecedor f in LojaData.Fornecedores)
            {
                if (f == null) continue;
                if (f.Id == novoFornecedor.Id)
                    return "Id já existente!";
                if (f.Nome == novoFornecedor.Nome)
                    return "Nome já existente!";
            }

            // Encontrar a próxima posição livre
            for (int i = 0; i < LojaData.Fornecedores.Length; i++)
            {
                if (LojaData.Fornecedores[i] == null)
                {
                    LojaData.Fornecedores[i] = novoFornecedor;
                    return "Fornecedor incluído com sucesso!";
                }
            }

            return "Erro ao adicionar fornecedor!";
        }

        public string RemoverFornecedor(int id)
        {
            for (int i = 0; i < LojaData.Fornecedores.Length; i++)
            {
                var fornecedor = LojaData.Fornecedores[i];
                if (fornecedor != null && fornecedor.Id == id)
                {
                    // Deslocar os elementos à esquerda
                    for (int j = i; j < LojaData.Fornecedores.Length - 1; j++)
                    {
                        LojaData.Fornecedores[j] = LojaData.Fornecedores[j + 1];
                    }
                    LojaData.Fornecedores[LojaData.Fornecedores.Length - 1] = null;

                    return "Fornecedor excluído com sucesso!";
                }
            }
            return "Fornecedor não encontrado!";
        }

        public Fornecedor? ObterFornecedorPorId(int id)
        {
            foreach (Fornecedor f in LojaData.Fornecedores)
            {
                if (f != null && f.Id == id)
                    return f;
            }
            return null;
        }

        public Fornecedor[] ObterTodosFornecedores()
        {
            return LojaData.Fornecedores.Where(f => f != null).ToArray();
        }

        public string EditarFornecedor(int id)
        {
            for (int i = 0; i < LojaData.Fornecedores.Length; i++)
            {
                var f = LojaData.Fornecedores[i];
                if (f != null && f.Id == id)
                {
                    Console.WriteLine($"Fornecedor atual:\n{f}");

                    Console.WriteLine($"Deseja alterar o nome? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        bool nomeValido = false;
                        while (!nomeValido)
                        {
                            Console.WriteLine("Novo nome: ");
                            string nome = Console.ReadLine();

                            bool nomeExistente = LojaData.Fornecedores
                                .Any(t => t != null && t.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

                            if (nomeExistente)
                            {
                                Console.WriteLine("Nome já existente! Tente novamente.");
                            }
                            else
                            {
                                f.Nome = nome;
                                nomeValido = true;
                            }
                        }
                    }

                    Console.WriteLine("Deseja editar o email? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        Console.WriteLine("Novo email: ");
                        f.Email = Console.ReadLine();
                    }

                    Console.WriteLine("Deseja editar o telefone? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        Console.WriteLine("Novo telefone: ");
                        f.Telefone = Console.ReadLine();
                    }

                    Console.WriteLine("Deseja editar o endereço? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        f.Endereco = new EnderecoMenu().CadastrarEndereco();
                    }

                    return "Fornecedor editado com sucesso!";
                }
            }

            return "Fornecedor não encontrado!";
        }
    }
}
