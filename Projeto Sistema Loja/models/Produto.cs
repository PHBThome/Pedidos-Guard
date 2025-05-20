namespace Projeto_Sistema_Loja.models
{
    internal class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int Id { get; set; }
        public int IdFornecedor { get; set; }
    }
}