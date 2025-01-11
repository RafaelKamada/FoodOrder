using Foodorder.API.Controllers;
using FoodOrder.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookController : Controller
    {
        private readonly ILogger<WebhookController> _logger;
        private readonly IMediator _mediator;

        public WebhookController(IMediator mediator, ILogger<WebhookController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Webhook de pagamentos, para receber o status do pagamento.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Pagamentos")]
        public async Task<IActionResult> Pagamentos([FromBody] UpdatePagtoWebhookCommand command)
        {
            var identificacaoPedido = await _mediator.Send(command);
            return Ok(identificacaoPedido);
        }
    }
}
