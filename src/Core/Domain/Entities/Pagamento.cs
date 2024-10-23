using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Pagamento
    {
        public Pagamento()
        {
        }

        public Pagamento(decimal valor, PagamentoStatus pagamentoStatus)
        {
            Valor = valor;
            Pagamento_Status = pagamentoStatus;
            DataCriacao = DateTime.UtcNow;

            if (pagamentoStatus.Descricao == "Finalizado")
            {
                DataPagamentoEfetuado = DateTime.UtcNow;
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [ForeignKey("PagamentoStatusId")]
        public PagamentoStatus Pagamento_Status { get; set; }

        public DateTime DataPagamentoEfetuado { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}