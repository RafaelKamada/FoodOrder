using FoodOrder.Application.Commands;
using FoodOrder.Application.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Foodorder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoApplicationService _produtoService;

        public ProdutoController(ProdutoApplicationService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AdicionarProduto([FromForm] AddProdutoCommand command)
        {
            var produto = await _produtoService.AdicionarProduto(command);
            return Ok(produto);
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AtualizarProduto([FromForm] UpdateProdutoCommand command)
        {
            var produto = await _produtoService.AtualizarProduto(command);
            return Ok(produto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarProduto([FromBody] DeleteProdutoCommand command)
        {
            await _produtoService.DeletarProduto(command);
            return Ok();
        }

        [HttpGet("ConsultarPorCategoria/{categoria}")]
        public async Task<IActionResult> ConsultarPorCategoria(string categoria)
        {
            var produtos = await _produtoService.ConsultarPorCategoria(categoria);
            return Ok(produtos);
        }
    }
}