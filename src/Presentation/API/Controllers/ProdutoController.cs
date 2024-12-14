using FoodOrder.Application.Queries;
using FoodOrder.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodorder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IMediator _mediator;

        public ProdutoController(ILogger<ProdutoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Produto([FromForm] AddProdutoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Atualizar([FromForm] UpdateProdutoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar([FromBody] DeleteProdutoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("ConsultarPorCategoria/{categoria}")]
        public async Task<IActionResult> ConsultarPorCategoria(string categoria)
        {
            var query = new GetProdutoByCategoriaQuery(categoria);
            var produto = await _mediator.Send(query);
            return Ok(produto);
        }
    }
}
