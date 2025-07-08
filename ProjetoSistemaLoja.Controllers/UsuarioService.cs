using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Interfaces;
using ProjetoSistemaLoja.Menus;
using ProjetoSistemaLoja.Services;

namespace ProjetoSistemaLoja.Controllers
{
    public class UsuarioService
    {
        private IRepositoryBase<Usuario> Repository;

        public UsuarioService(IRepositoryBase<Usuario> repositorio)
        {
            Repository = repositorio;
        }

        public string AdicionarUsuario()
        {
            try
            {
                Console.WriteLine("Usuario: ");
                string user = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(user))
                {
                    throw new Exception("Informe um usuario v�lido!");
                }

                IList<Usuario> usuarios = Repository.GetAll<Usuario>();

                foreach (var u in usuarios)
                {
                    if (u != null && u.User == user)
                    {
                        throw new Exception("Usuario j� existente!");
                    }
                }

                Console.WriteLine("Senha: ");
                string password = Console.ReadLine();
                if (password.Length < 8 || !password.Any(char.IsDigit))
                    throw new Exception("A senha deve conter pelo menos 8 digitos e 1 numero");

                Console.WriteLine("Email: ");
                string email = Console.ReadLine();
                if (!email.Contains('@') || string.IsNullOrWhiteSpace(email))
                    throw new Exception("Informe um email v�lido!");

                Console.WriteLine("Telefone: ");
                string telefone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 11)
                    throw new Exception("Informe um telefone v�lido!");

                Endereco endereco = new EnderecoService().CadastrarEndereco();

                List<int> ids = (from u in usuarios
                                 select u.Id).ToList();

                int id = Util.NextId(ids);  
        

                Usuario novoUsuario = new(id, user, telefone, email, email, endereco);

                Repository.Save(novoUsuario);

                return "Usuario cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public string RemoverUsuario()
        {
            try
            {
                Console.WriteLine("Id do Usuario a remover: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                {
                    throw new Exception("Informe um id v�lido!");
                }

                IList<Usuario> usuarios = Repository.GetAll<Usuario>();
                var usuario = usuarios.FirstOrDefault(u => u != null && u.Id == id);

                if (usuario == null)
                {
                    throw new Exception("Usuario n�o encontrado!");
                }

                Repository.Remove<Usuario>(id);
                return "Usuario removido com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            return Repository.GetById<Usuario>(id);
        }

        public IList<Usuario> ObterTodosUsuarios()
        {
            return Repository.GetAll<Usuario>();
        }

        public string EditarUsuario()
        {
            try
            {
                Console.WriteLine("Id do Usuario a editar: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                {
                    throw new Exception("Informe um id v�lido");
                }

                IList<Usuario> usuarios = Repository.GetAll<Usuario>();
                Usuario usuarioEditado = usuarios.FirstOrDefault(u => u != null && u.Id == id);

                if (usuarioEditado == null)
                {
                    throw new Exception("Usu�rio n�o encontrado!");
                }

                Console.WriteLine($"Usu�rio atual:\n{usuarioEditado}");

                Console.WriteLine("Deseja editar a senha? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool senhaValida = false;
                    while (!senhaValida)
                    {
                        Console.WriteLine("Nova senha: ");
                        string senha = Console.ReadLine();
                        Console.WriteLine("Informe a senha novamente: ");
                        string senha2 = Console.ReadLine();

                        if (senha.Length < 8 || !senha.Any(char.IsDigit))
                        {
                            Console.WriteLine("A senha deve conter pelo menos 8 d�gitos e 1 n�mero!");
                        }
                        else if(senha == senha2)
                        {
                            usuarioEditado.Password = senha;
                            senhaValida = true;
                        }
                    }
                }

                Console.WriteLine("Deseja editar o telefone? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool telefoneValido = false;
                    while (!telefoneValido)
                    {
                        Console.WriteLine("Novo telefone (apenas n�meros): ");
                        string telefone = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 11)
                        {
                            Console.WriteLine("Informe um telefone v�lido (11 d�gitos)!");
                        }
                        else
                        {
                            usuarioEditado.Telefone = telefone;
                            telefoneValido = true;
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

                        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                        {
                            Console.WriteLine("Informe um email v�lido!");
                        }
                        else
                        {
                            usuarioEditado.Email = email;
                            emailValido = true;
                        }
                    }
                }

                Console.WriteLine("Deseja editar o endere�o? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    usuarioEditado.Endereco = new EnderecoService().CadastrarEndereco();
                }

                Repository.Update<Usuario>(usuarioEditado);

                return "Usu�rio editado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }
    }
}

