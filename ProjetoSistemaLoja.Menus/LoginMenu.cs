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
                throw new Exception("Usuário ou senha iválidos");
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
                Console.WriteLine("Usuário: ");
                user = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(user))
                {
                    Console.WriteLine("Informe um usuário válido!");
                    continue;
                }

                bool usuarioExistente = usuarios.Any(u => u != null && u.User == user);
                if (usuarioExistente)
                {
                    Console.WriteLine("Usuário já existente!");
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
                    Console.WriteLine("A senha deve conter pelo menos 8 dígitos e 1 número!");
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
                Console.WriteLine("Telefone (10 dígitos): ");
                telefone = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 10 || !telefone.All(char.IsDigit))
                {
                    Console.WriteLine("Informe um telefone válido!");
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
