using ProjetoSistemaLoja.Menus;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Interfaces;
using ProjetoSistemaLoja.Services;

namespace ProjetoSistemaLoja.Controllers
{
    public class FornecedorService
    {
        private IRepositoryBase<Fornecedor> Repository { get; set; }

        public FornecedorService(IRepositoryBase<Fornecedor> repositorio)
        {
            Repository = repositorio;
        }

        public string AdicionarFornecedor()
        {
            try
            {
                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Informe um nome válido!");

                IList<Fornecedor> fornecedores = Repository.GetAll<Fornecedor>();

                foreach (var f in fornecedores)
                {
                    if (f != null && f.Nome == nome)
                        throw new Exception("Nome já existente!");
                }

                string email = "";
                bool emailValido = false;
                while (!emailValido)
                {
                    Console.WriteLine("Email: ");
                    email = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                    {
                        Console.WriteLine("Informe um email válido!");
                    }
                    else
                    {
                        emailValido = true;
                    }
                }

                string telefone = "";
                bool telefoneValido = false;
                while (!telefoneValido)
                {
                    Console.WriteLine("Telefone (11 dígitos): ");
                    telefone = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 11 || !telefone.All(char.IsDigit))
                    {
                        Console.WriteLine("Informe um telefone válido!");
                    }
                    else
                    {
                        telefoneValido = true;
                    }
                }

                Console.WriteLine("Descrição: ");
                string descricao = Console.ReadLine();

                Endereco endereco = new EnderecoService().CadastrarEndereco();

                List<int> ids = (from f in fornecedores
                                 select f.Id).ToList();

                int id = Util.NextId(ids);

                Fornecedor novoFornecedor = new(id, nome, email, telefone, descricao, endereco);

                Repository.Save(novoFornecedor);

                return "Fornecedor adicionado com sucesso!";

            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public string RemoverFornecedor()
        {
            try
            {
                Console.WriteLine("Id do fornecedor a remover: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                {
                    throw new Exception("Informe um id válido!");
                }

                IList<Fornecedor> fornecedores = Repository.GetAll<Fornecedor>();
                var fornecedor = fornecedores.FirstOrDefault(t => t != null && t.Id == id);

                if (fornecedor == null)
                {
                    throw new Exception("Transportadora não encontrada!");
                }

                Repository.Remove<Fornecedor>(id);
                return "Fornecedor removido com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Fornecedor? ObterFornecedorPorId(int id)
        {
            return Repository.GetById<Fornecedor>(id);
        }

        public IList<Fornecedor> ObterTodosFornecedores()
        {
            return Repository.GetAll<Fornecedor>();
        }

        public string EditarFornecedor()
        {
            try
            {
                Console.WriteLine("Id do fornecedor a editar: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                    throw new Exception("Informe um id válido!");

                IList<Fornecedor> fornecedores = Repository.GetAll<Fornecedor>();
                var fornecedorEditado = fornecedores.FirstOrDefault(f => f != null && f.Id == id);

                Console.WriteLine($"Fornecedor atual:\n{fornecedorEditado}");

                Console.WriteLine($"Deseja alterar o nome? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool nomeValido = false;
                    while (!nomeValido)
                    {
                        Console.WriteLine("Novo nome: ");
                        string nome = Console.ReadLine();

                        bool nomeExistente = fornecedores.Any(f => f != null && f.Nome.ToLower() == nome.ToLower() && f.Id != id);

                        if (nomeExistente)
                        {
                            Console.WriteLine("Nome já existente! Tente novamente.");
                        }
                        else
                        {
                            fornecedorEditado.Nome = nome;
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
                        string email = Console.ReadLine();
                        if (email.Contains('@') || string.IsNullOrWhiteSpace(email))
                            Console.WriteLine("Informe um email válido!");
                        else
                            fornecedorEditado.Email = email;
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
                        string telefone = Console.ReadLine();
                        if (telefone.Length != 11 || string.IsNullOrWhiteSpace(telefone))
                            Console.WriteLine("Informe um telefone válido");
                        else
                            fornecedorEditado.Telefone = telefone;
                            telValido = true;
                    }
                }

                Console.WriteLine("Deseja editar a descrição? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    Console.WriteLine("Nova descrição: ");
                    fornecedorEditado.Descricao = Console.ReadLine();
                }

                Console.WriteLine("Deseja editar o endereço? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    fornecedorEditado.Endereco = new EnderecoService().CadastrarEndereco();
                }

                Repository.Update<Fornecedor>(fornecedorEditado);

                return "Fornecedor editado com sucesso!";
                   
   
            }
            catch(Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }
    }
}

