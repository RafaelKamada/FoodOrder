using FoodOrder.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace FoodOrder.Application.DTOs
{
    public class PedidoResponse
    {
        private Unit pedido;

        public PedidoResponse(Pedido pedido)
        {
            Id = pedido.Id;
            NumeroPedido = pedido.NumeroPedido;
            TempoEspera = pedido.TempoEspera;
            DataCriacao = pedido.DataCriacao;
            ClienteId = pedido.ClienteId;
            PagamentoId = pedido.PagamentoId;
            PedidoStatusId = pedido.PedidoStatusId;
            SacolaId = pedido.SacolaId;
        }

        public PedidoResponse(Unit pedido)
        {
            this.pedido = pedido;
        }

        public int Id { get; set; }
        public int NumeroPedido { get; set; }
        public TimeSpan TempoEspera { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ClienteId { get; set; }
        public int PagamentoId { get; set; }
        public int PedidoStatusId { get; set; }
        public int SacolaId { get; set; }
    }
}
