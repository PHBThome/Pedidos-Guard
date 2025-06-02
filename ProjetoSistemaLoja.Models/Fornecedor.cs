namespace ProjetoSistemaLoja.Models
{
    public class Fornecedor
    {
        public Fornecedor(int id, string nome, string email, string telefone, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return $"\nID: {Id}\n" +
                $"Nome: {Nome}\n" +
                $"Email: {Email}\n" +
                $"Telefone: {Telefone}\n" +
                $"Endereço: {Endereco}";
        }
    }
}

