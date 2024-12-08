using Foodorder.API.Controllers;
using FoodOrder.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IMediator _mediator;

        public PagamentoController(ILogger<PedidoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("ConsultarStatus/{numeroPedido}")]
        public async Task<IActionResult> ConsultarStatus(int numeroPedido)
        {
            var query = new GetStatusPagtoByPedidoQuery(numeroPedido);
            var statusPedido = await _mediator.Send(query);
            return Ok(statusPedido);
        }
    }
}
