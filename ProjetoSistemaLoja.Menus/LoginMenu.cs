using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Interfaces;
using ProjetoSistemaLoja.Services;

namespace ProjetoSistemaLoja.Menus
{
    internal class LoginMenu
    {
        private IRepositoryBase<Usuario> Repository;
        public LoginMenu(IRepositoryBase<Usuario> repositorio)
        {
            Repository = repositorio;
        }
        public (Usuario? usuario, bool isAdmin) Logar()
        {
            Console.WriteLine("Informe o usuario: ");
            string user = Console.ReadLine();
            Console.WriteLine("Informe a senha: ");
            string password = Console.ReadLine();

            IList<Usuario> usuarios = Repository.GetAll<Usuario>();

            if (user == "admin" && password == "1234")
            {
                return (null, true);
            }

            Usuario usuario = usuarios.Where(u => u.User == user && u.Password == password).FirstOrDefault();

            if (usuario == null)
            {
                throw new Exception("Usu�rio ou senha iv�lidos");
            }

            return (usuario, false);
        }

        public void Registrar()
        {
            IList<Usuario> usuarios = Repository.GetAll<Usuario>();

            string user = "";
            bool userValido = false;
            while (!userValido)
            {
                Console.WriteLine("Usu�rio: ");
                user = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(user))
                {
                    Console.WriteLine("Informe um usu�rio v�lido!");
                    continue;
                }

                bool usuarioExistente = usuarios.Any(u => u != null && u.User == user);
                if (usuarioExistente)
                {
                    Console.WriteLine("Usu�rio j� existente!");
                }
                else
                {
                    userValido = true;
                }
            }

            string password = "";
            bool senhaValida = false;
            while (!senhaValida)
            {
                Console.WriteLine("Senha: ");
                password = Console.ReadLine();

                if (password.Length < 8 || !password.Any(char.IsDigit))
                {
                    Console.WriteLine("A senha deve conter pelo menos 8 d�gitos e 1 n�mero!");
                }
                else
                {
                    senhaValida = true;
                }
            }

            string email = "";
            bool emailValido = false;
            while (!emailValido)
            {
                Console.WriteLine("Email: ");
                email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                {
                    Console.WriteLine("Informe um email v�lido!");
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
                Console.WriteLine("Telefone (10 d�gitos): ");
                telefone = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 10 || !telefone.All(char.IsDigit))
                {
                    Console.WriteLine("Informe um telefone v�lido!");
                }
                else
                {
                    telefoneValido = true;
                }
            }

            Endereco endereco = new EnderecoService().CadastrarEndereco();

            List<int> ids = (from u in usuarios
                             select u.Id).ToList();

            int id = Util.NextId(ids);

            Usuario novoUsuario = new(id, user, password, telefone, email, endereco);
            Repository.Save(novoUsuario);
        }
    }
}
