using FoodOrder.Application.Commands;
using FoodOrder.Application.DTOs;
using FoodOrder.Application.Output;
using FoodOrder.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Application.Controller
{
    public class PedidoApplicationService
    {
        private readonly IMediator _mediator;

        public PedidoApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PedidoOutput> ListarPedidos()
        {
            var pedidos = await _mediator.Send(new GetPedidoByQuery());
            return pedidos ?? new PedidosOutput();
        }

        public async Task<PedidoResponse> AtualizarStatus(UpdateStatusPedidoCommand command)
        {
            var pedido = await _mediator.Send(command);
            return new PedidoResponse(pedido);
        }
    }
}