namespace Projeto_Sistema_Loja.models
{
    internal class Fornecedor
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public Endereco Endereco { get; set; }
    }
}
