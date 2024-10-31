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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Produto([FromForm] AddProdutoCommand command)
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

        [HttpPut]
        [Route("Atualizar")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AtualizarProduto([FromForm] UpdateProdutoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> DeletarProduto([FromBody] DeleteProdutoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("Categoria/Cadastrar")]
        public async Task<IActionResult> CadastrarCategoria([FromBody] AddCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("Categoria/Consultar")]
        public async Task<IActionResult> ConsultarCategoria()
        {
            var command = new GetAllCategoriaQuery();
            var categoria = await _mediator.Send(command);
            return Ok(categoria);
        }

        [HttpPut]
        [Route("Categoria/Atualizar")]
        public async Task<IActionResult> AtualizarCategoria([FromBody] UpdateCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Route("Categoria/Deletar")]
        public async Task<IActionResult> DeletarCategoria([FromBody] DeleteCategoriaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
