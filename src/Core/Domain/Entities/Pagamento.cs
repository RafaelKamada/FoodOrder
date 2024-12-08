using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrder.Domain.Entities
{
    public class Pagamento
    {
        public Pagamento()
        {
        }

        public Pagamento(decimal valor, int pagamentoStatusId)
        {
            Valor = valor;
            PagamentoStatusId = pagamentoStatusId;
            DataCriacao = DateTime.UtcNow;
            DataPagamentoEfetuado = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [ForeignKey("PagamentoStatusId")]
        public int PagamentoStatusId { get; set; }

        public DateTime DataPagamentoEfetuado { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}