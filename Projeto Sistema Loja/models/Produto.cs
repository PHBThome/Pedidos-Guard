namespace Projeto_Sistema_Loja.models
{
    internal class Produto
    {
        public int Id { get; set; }
        public double valor { get; set; }
        public int Quantidade { get; set; }
        public int IdFornecedor { get; set; }

        public Produto(int id, double valor, int quantidade, int idFornecedor)
        {
            Id = id;
            this.valor = valor;
            Quantidade = quantidade;
            IdFornecedor = idFornecedor;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Valor: {valor} | Quantidade: {Quantidade} | ID Fornecedor: {IdFornecedor}";
        }
    }
}
