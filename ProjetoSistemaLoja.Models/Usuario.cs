namespace ProjetoSistemaLoja.Models
{
    public class Usuario
    {
        public Usuario(string user, string password)
        {
            User = user;  
            Password = password;
        }
        public string Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }


    }
}

