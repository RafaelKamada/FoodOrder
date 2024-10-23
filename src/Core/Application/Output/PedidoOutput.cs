
namespace Application.Output
{
    public class PedidoOutput
    {
        public int Id { get; set; }

        public int NumeroPedido { get; set; }

        public TimeSpan TempoEspera { get; set; }

        public DateTime DataCriacao { get; set; }

        public Guid ClienteId { get; set; }

        public int PagamentoId { get; set; }

        public int PedidoStatusId { get; set; }

        public int SacolaId { get; set; }

        public List<ProdutoOutput> Produtos {get;set;}
    }

    public class ProdutoOutput 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

}
