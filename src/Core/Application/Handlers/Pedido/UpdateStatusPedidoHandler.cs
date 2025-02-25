using FoodOrder.Application.Commands;
using FoodOrder.Application.UseCases.Pedidos;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FoodOrder.Application.Handlers.Produto
{
    public class UpdateStatusPedidoCommandHandler : IRequestHandler<UpdateStatusPedidoCommand, Unit>
    {
        private readonly IPedidoUseCase _pedidoUseCase;

        public UpdateStatusPedidoCommandHandler(IPedidoUseCase pedidoUseCase)
        {
            _pedidoUseCase = pedidoUseCase;
        }

        public async Task<Unit> Handle(UpdateStatusPedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pedido = await _pedidoUseCase.Consultar(request.NumeroPedido);
                var status = await _pedidoUseCase.ConsultarStatus(request.Status);

                if (pedido == null)
                    throw new KeyNotFoundException("Pedido não encontrado!");


                pedido.PedidoStatus = status;

                await _pedidoUseCase.Atualizar(pedido);

                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}
