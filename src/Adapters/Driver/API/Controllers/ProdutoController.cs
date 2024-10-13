using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
        [Route("Cadastrar")]
        public async Task<IActionResult> Produto([FromBody] AddProdutoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("ConsultarPorCategoria/{categoria}")]
        public async Task<IActionResult> ConsultarPorCpf(string categoria)
        {
            var query = new GetProdutoByCategoriaQuery(categoria);
            var cliente = await _mediator.Send(query);
            return Ok(cliente);
        }

        [HttpPost]
        [Route("Cadastrar/Categoria")]
        public async Task<IActionResult> Categoria([FromBody] AddCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
