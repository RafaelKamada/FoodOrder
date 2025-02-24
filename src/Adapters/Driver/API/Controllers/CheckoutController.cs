﻿using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IMediator _mediator;

        public CheckoutController(IMediator mediator, ILogger<ProdutoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        /// <summary>
        /// Fake checkout, apenas enviar os produtos escolhidos para a fila.O checkout é a finalização do pedido
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("FakeCheckout")]
        public async Task<IActionResult> FakeCheckout([FromBody] AddCheckoutCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
