using FoodOrder.Application.Commands;
using FoodOrder.Application.Controller;
using FoodOrder.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoApplicationService _pedidoService;

        public PedidoController(PedidoApplicationService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("ListarPedidos")]
        public async Task<IActionResult> ListarPedidos()
        {
            var pedidos = await _pedidoService.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpPut("AtualizarStatusPedido")]
        public async Task<IActionResult> AtualizarStatusPedido([FromBody] UpdateStatusPedidoCommand command)
        {
            var pedido = await _pedidoService.AtualizarStatus(command);
            return Ok(pedido);
        }
    }
}
