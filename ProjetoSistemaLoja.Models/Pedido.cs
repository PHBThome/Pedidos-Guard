namespace ProjetoSistemaLoja.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<PedidoItem> Itens { get; set; }
        public double Valor { get; set; }
    }
}
