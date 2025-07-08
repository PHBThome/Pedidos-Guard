namespace ProjetoSistemaLoja.Models
{
    public class Produto
    {
        public Produto(int id, string nome, string descricao, double valor, int quantidade, int idFornecedor)
        {
            Descricao = descricao;
            Id = id;
            Valor = valor;
            Quantidade = quantidade;
            IdFornecedor = idFornecedor;
            Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int IdFornecedor { get; set; }

        public override string ToString()
        {
            return $"\nID: {Id}\n" +
                $"Nome: {Nome}\n" +
                $"Descrição: {Descricao}\n" +
                $"Valor: {Valor}\n" +
                $"Quantidade: {Quantidade}\n" +
                $"ID Fornecedor: {IdFornecedor}";
        }
    }
}

