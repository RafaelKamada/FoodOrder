using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodOrder.Domain.Entities
{
    public class Pedido
    {
        public Pedido()
        {
        }

        public Pedido(TimeSpan tempoEspera, Guid clienteId, int pagamentoId, int pedidoStatusId, int sacolaId)
        {
            TempoEspera = tempoEspera;
            DataCriacao = DateTime.UtcNow;
            ClienteId = clienteId;
            PagamentoId = pagamentoId;
            PedidoStatusId = pedidoStatusId;
            SacolaId = sacolaId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int NumeroPedido { get; set; }

        public TimeSpan TempoEspera { get; set; }

        [JsonIgnore]
        public DateTime DataCriacao { get; set; }

        [ForeignKey("ClienteId")]
        public Guid ClienteId { get; set; }

        [ForeignKey("PagamentoId")]
        public int PagamentoId { get; set; }

        [ForeignKey("PedidoStatusId")]
        public int PedidoStatusId { get; set; }

        [ForeignKey("SacolaId")]
        public int SacolaId { get; set; }

    }
}
