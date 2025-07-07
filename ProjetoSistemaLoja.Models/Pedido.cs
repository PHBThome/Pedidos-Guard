namespace ProjetoSistemaLoja.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataEntrega { get; set; }
        public string Situacao { get; set; } //Novo, Em Transporte, Entregue, Cancelada
        public double PrecoFrete { get; set; }
        public IList<PedidoItem> Itens { get; set; }
        public double Valor { get; set; }

        public override string ToString()
        {
            return $"\nID: {Id}\n" +
                $"Data do pedido: {DataPedido}\n" +
                $"Data de entrega: {DataEntrega}" +
                $"Situação: {Situacao}\n" +
                $"Preço do Frete: {PrecoFrete}\n" +
                $"Preço do pedido: {Valor}";
        }
    }
}
