using ProjetoSistemaLoja.Menus;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Interfaces;

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
                    throw new Exception("Informe um nome v�lido!");

                IList<Fornecedor> fornecedores = Repository.GetAll<Fornecedor>();

                foreach (var f in fornecedores)
                {
                    if (f != null && f.Nome == nome)
                        throw new Exception("Nome j� existente!");
                }

                Console.WriteLine("Email: ");
                string email = Console.ReadLine();
                if (!email.Contains('@') || string.IsNullOrWhiteSpace(email))
                    throw new Exception("Informe um email v�lido!");

                Console.WriteLine("Telefone: ");
                string telefone = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(telefone) || telefone.Length != 10)
                    throw new Exception("Informe um telefone v�lido!");


                Endereco endereco = new EnderecoService().CadastrarEndereco();
                int id = fornecedores.Count + 1;

                Fornecedor novoFornecedor = new(id, nome, email, telefone, endereco);

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
                    throw new Exception("Informe um id v�lido!");
                }

                IList<Fornecedor> fornecedores = Repository.GetAll<Fornecedor>();
                var fornecedor = fornecedores.FirstOrDefault(t => t != null && t.Id == id);

                if (fornecedor == null)
                {
                    throw new Exception("Transportadora n�o encontrada!");
                }

                Repository.Remove<Fornecedor>(id);
                return "Transportadora removida com sucesso!";
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
                    throw new Exception("Informe um id v�lido!");

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
                            Console.WriteLine("Nome j� existente! Tente novamente.");
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
                            Console.WriteLine("Informe um email v�lido!");
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
                        if (telefone.Length != 10 || string.IsNullOrWhiteSpace(telefone))
                            Console.WriteLine("Informe um telefone v�lido");
                        else
                            fornecedorEditado.Telefone = telefone;
                            telValido = true;
                    }
                }

                Console.WriteLine("Deseja editar o endere�o? (s/n)");
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

            return "Fornecedor n�o encontrado";
        }
    }
}

