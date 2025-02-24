using FoodOrder.Application.Queries;
using FoodOrder.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodorder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IMediator _mediator;

        public ClienteController(ILogger<ClienteController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastrar um cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> CadastrarCliente([FromBody] AddClienteCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// Consultar um cliente por CPF
        /// </summary>
        /// <param name="cpf">CPF</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ConsultarPorCpf/{cpf}")]
        public async Task<IActionResult> ConsultarPorCpf(string cpf)
        {
            var query = new GetClienteByCpfQuery(cpf);
            var cliente = await _mediator.Send(query);
            return Ok(cliente);
        }
    }
}
