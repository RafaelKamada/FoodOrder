using FoodOrder.Application.Queries;
using FoodOrder.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodorder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator, ILogger<PedidoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("ListarPedidos")]
        public async Task<IActionResult> ListarPedidos()
        {
            var query = new GetPedidoByQuery();
            var cliente = await _mediator.Send(query);
            return Ok(cliente);
        }

        [HttpPut]
        [Route("AtualizarStatusPedido")]
        public async Task<IActionResult> AtualizarStatusPedido([FromBody] UpdateStatusPedidoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
