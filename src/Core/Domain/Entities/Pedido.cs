using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Pedido
    {
        public Pedido()
        {
        }

        public Pedido(int numeroPedido, TimeSpan tempoEspera, Cliente cliente, Pagamento pagamento, PedidoStatus pedidoStatus, Sacola sacola)
        {
            NumeroPedido = numeroPedido;
            TempoEspera = tempoEspera;
            DataCriacao = DateTime.UtcNow;
            Cliente = cliente;
            Pagamento = pagamento;
            Pedido_Status = pedidoStatus;
            Sacola = sacola;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int NumeroPedido { get; set; }

        public TimeSpan TempoEspera { get; set; }

        [JsonIgnore]
        public DateTime DataCriacao { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [ForeignKey("PagamentoId")]
        public Pagamento Pagamento { get; set; }

        [ForeignKey("PedidoStatusId")]
        public PedidoStatus Pedido_Status { get; set; }

        [ForeignKey("SacolaId")]
        public Sacola Sacola { get; set; }

    }
}
