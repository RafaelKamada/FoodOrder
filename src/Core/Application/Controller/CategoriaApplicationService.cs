using FoodOrder.Application.Commands;
using FoodOrder.Application.DTOs;
using MediatR;

namespace FoodOrder.Application.Controller
{
    public class CategoriaApplicationService
    {
        private readonly IMediator _mediator;

        public CategoriaApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Cadastrar(AddCategoriaCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task<IEnumerable<CategoriaResponse>> Consultar()
        {
            return await _mediator.Send(new GetAllCategoriaQuery());
        }

        public async Task AtualizarCategoria(UpdateCategoriaCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task DeletarCategoria(DeleteCategoriaCommand command)
        {
            await _mediator.Send(command);
        }
    }

}
