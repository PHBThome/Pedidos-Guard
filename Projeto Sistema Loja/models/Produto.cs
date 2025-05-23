namespace Projeto_Sistema_Loja.models
{
    internal class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int IdFornecedor { get; set; }

        public Produto(int id, string nome, double valor, int quantidade, int idFornecedor)
        {
            Id = id;
            this.Valor = valor;
            Quantidade = quantidade;
            IdFornecedor = idFornecedor;
        }

        public override string ToString()
        {
            return $"\nID: {Id}\n" +
                $"Nome: {Nome}\n" +
                $"Valor: {Valor}\n" +
                $"Quantidade: {Quantidade}\n" +
                $"ID Fornecedor: {IdFornecedor}";
        }
    }
}
