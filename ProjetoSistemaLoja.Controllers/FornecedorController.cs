using ProjetoSistemaLoja.Menus;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Data;

namespace ProjetoSistemaLoja.Controllers
{
    public   class FornecedorController
    {
        private readonly LojaData LojaData;

        public FornecedorController(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public string AdicionarFornecedor()
        {
            try
            {
                int fornecedorCount = LojaData.Fornecedores.Count(f => f != null);

                if (fornecedorCount >= LojaData.Fornecedores.Length)
                    return "\nNúmero máximo de fornecedores atingido!";

                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Informe um nome válido!");

                foreach (var f in LojaData.Fornecedores)
                {
                    if (f != null && f.Nome == nome)
                        throw new Exception("Nome já existente!");
                }

                Console.WriteLine("Email: ");
                string email = Console.ReadLine();
                if (!email.Contains('@') || string.IsNullOrWhiteSpace(email))
                    throw new Exception("Informe um email válido!");

                Console.WriteLine("Telefone: ");
                string telefone = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(telefone) || telefone.Length != 10)
                    throw new Exception("Informe um telefone válido!");


                Endereco endereco = new EnderecoController().CadastrarEndereco();
                int id = fornecedorCount + 1;

                Fornecedor novoFornecedor = new(id, nome, email, telefone, endereco);

                int posicaoLivre = -1;
                for (int i = 0; i < LojaData.Fornecedores.Length; i++)
                {
                    if (LojaData.Fornecedores[i] == null)
                    {
                        posicaoLivre = i;
                        break;
                    }
                }

                Fornecedor[] novoArray = new Fornecedor[LojaData.Fornecedores.Length];
                Array.Copy(LojaData.Fornecedores, novoArray, LojaData.Fornecedores.Length);
                novoArray[posicaoLivre] = novoFornecedor;
                LojaData.Fornecedores = novoArray;

                return "Produto adicionado com sucesso!";

            }
            catch (Exception ex)
            {
                return "Erro ao adicionar fornecedor: " + ex.Message;
            }
        }

        public string RemoverFornecedor()
        {
            try
            {
                Console.Write("Id do fornecedor a remover: ");
                int id = int.Parse(Console.ReadLine());
                bool existe = false;
                foreach (Fornecedor f in LojaData.Fornecedores)
                {
                    if (f == null) continue;
                    if (f.Id == id) existe = true;
                }
                if (!existe)
                    throw new Exception("Informe um id válido");

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
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
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

        public string EditarFornecedor()
        {
            try
            {
                Console.WriteLine("Id do fornecedor a editar: ");
                int id = int.Parse(Console.ReadLine());
                bool existe = false;
                foreach (Fornecedor f in LojaData.Fornecedores)
                {
                    if (f == null) continue;
                    if (f.Id == id)
                        existe = true;
                }
                if (!existe)
                    throw new Exception("Informe um id válido");

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
                            bool emailValido = false;
                            while (!emailValido)
                            {
                                Console.WriteLine("Novo email: ");
                                f.Email = Console.ReadLine();
                                if(!f.Email.Contains('@') || string.IsNullOrWhiteSpace(f.Email))
                                    Console.WriteLine("Informe um email válido!");
                                else
                                     emailValido = true;
                            }
                        }

                        Console.WriteLine("Deseja editar o telefone? (s/n)");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            bool telValido = false;
                            while (!telValido)
                            {
                                Console.WriteLine("Novo telefone: ");
                                f.Telefone = Console.ReadLine();
                                if (f.Telefone.Length != 10 || string.IsNullOrWhiteSpace(f.Telefone))
                                    Console.WriteLine("Informe um telefone válido");
                                else
                                    telValido = true;
                            }
                        }

                        Console.WriteLine("Deseja editar o endereço? (s/n)");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            f.Endereco = new EnderecoController().CadastrarEndereco();
                        }

                        return "Fornecedor editado com sucesso!";
                    }
                }
            }
            catch(Exception ex)
            {
                return "Erro: " + ex.Message;
            }

            return "Fornecedor não encontrado";
        }
    }
}

