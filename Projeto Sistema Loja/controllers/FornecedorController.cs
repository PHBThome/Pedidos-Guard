using System.Runtime.CompilerServices;
using Projeto_Sistema_Loja.menus;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class FornecedorController
    {
        private Fornecedor[] fornecedores = new Fornecedor[100];
        private int fornecedorCount = 0;
        private readonly EnderecoMenu endereco = new EnderecoMenu();

        public string AdicionarFornecedor(Fornecedor novoFornecedor)
        {
            if (fornecedorCount >= fornecedores.Length)
                return "\nNúmero máximo de fornecedores atingido!";

            foreach (Fornecedor f in fornecedores)
            {
                if (f == null) continue;
                if (f.Id == novoFornecedor.Id)
                    return "Id já existente!";
                if (f.Nome == novoFornecedor.Nome)
                    return "Nome já existente!";
            }

            fornecedores[fornecedorCount++] = novoFornecedor;
            return "Fornecedor incluído com sucesso!";
        }

        public string RemoverFornecedor(int id)
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

        public Fornecedor ObterFornecedorPorId(int id)
        {
            foreach (Fornecedor f in fornecedores)
            {
                if (f != null && f.Id == id)
                    return f;
            }
            return null;
        }

        public Fornecedor[] ObterTodosFornecedores()
        {
            Fornecedor[] lista = new Fornecedor[fornecedorCount];
            Array.Copy(fornecedores, lista, fornecedorCount);
            return lista;
        }

        public string EditarFornecedor(int id)
        {
            for (int i = 0; i < fornecedorCount; i++)
            {
                if (fornecedores[i].Id == id)
                {
                    var f = fornecedores[i];
                    Console.WriteLine($"Fornecedor atual:\n{f}");

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

                            foreach (Fornecedor t in fornecedores)
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
                        f.Nome = nome;
                    }

                    Console.WriteLine("Deseja editar o email? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        Console.WriteLine("Novo email: ");
                        string email = Console.ReadLine();
                    }

                    Console.WriteLine("Deseja editar o telefone: (s/n)");
                    if(Console.ReadLine().ToLower() == "s")
                    {
                        Console.WriteLine("Novo telefone: ");
                        string telefone = Console.ReadLine();
                    }

                    Console.WriteLine("Deseja editar o endereço? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        var novo = endereco.CadastrarEndereco();
                    }
                    

                    return "Fornecedor editado com sucesso!";
                }

            }
            return "Fornecedor não encontrado";
        }
    }
}
