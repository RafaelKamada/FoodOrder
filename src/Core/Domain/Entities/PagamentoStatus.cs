using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class PagamentoStatus
    {
        public PagamentoStatus()
        {
        }
        public PagamentoStatus(string descricao)
        {
            Descricao = descricao;
            DataCriacao = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [JsonIgnore]
        public DateTime DataCriacao { get; set; }

    }
}