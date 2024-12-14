using FoodOrder.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodorder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly IMediator _mediator;

        public CategoriaController(ILogger<CategoriaController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] AddCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Consultar()
        {
            var command = new GetAllCategoriaQuery();
            var categoria = await _mediator.Send(command);
            return Ok(categoria);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCategoria([FromBody] UpdateCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarCategoria([FromBody] DeleteCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
