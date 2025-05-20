namespace Projeto_Sistema_Loja.models
{
    internal class Transportadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorKm { get; set; }
        public Endereco Endereco { get; set; }
    }
}