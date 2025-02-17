using FoodOrder.Application.Commands;
using FoodOrder.Application.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodorder.API.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly CategoriaApplicationController _appController;

        public CategoriaController(ILogger<CategoriaController> logger, CategoriaApplicationController appController)
        {
            _logger = logger;
            _appController = appController;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] AddCategoriaCommand command)
        {
            await _appController.Cadastrar(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Consultar()
        {
            var categorias = await _appController.Consultar();
            return Ok(categorias);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCategoria([FromBody] UpdateCategoriaCommand command)
        {
            await _appController.AtualizarCategoria(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarCategoria([FromBody] DeleteCategoriaCommand command)
        {
            await _appController.DeletarCategoria(command);
            return Ok();
        }
    }
}
