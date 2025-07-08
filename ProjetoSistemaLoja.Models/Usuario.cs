namespace ProjetoSistemaLoja.Models
{
    public class Usuario
    {
        public Usuario(int id, string user, string password, string telefone, string email, Endereco endereco)
        {
            Id = id;
            User = user;  
            Password = password;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }

        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"User: {User}\n" +
                $"Senha: {Password}\n" +
                $"Email: {Email}\n" +
                $"Telefone: {Telefone}\n" +
                $"Endereço: {Endereco}";
        }
    }
}

