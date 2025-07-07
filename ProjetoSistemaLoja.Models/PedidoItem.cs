namespace ProjetoSistemaLoja.Models
{
    public class PedidoItem
    {
        public string Nome { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }

        public override string ToString()
        {
            return $"\nNome: {Nome}" +
                   $"ID: {IdProduto}\n" +
                   $"Quantidade: {Quantidade}\n" +
                   $"Valor Total: {ValorTotal}";
        }
    }
}
