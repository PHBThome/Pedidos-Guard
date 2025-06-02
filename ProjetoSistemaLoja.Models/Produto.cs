namespace ProjetoSistemaLoja.Models
{
    public class Produto
    {
        public Produto(int id, string nome, double valor, int quantidade, int idFornecedor)
        {
            Id = id;
            Valor = valor;
            Quantidade = quantidade;
            IdFornecedor = idFornecedor;
            Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int IdFornecedor { get; set; }

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

