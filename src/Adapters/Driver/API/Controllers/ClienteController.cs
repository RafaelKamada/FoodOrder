using Application.UseCases.Clientes;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteUseCase _clienteUseCase;

        public ClienteController(ILogger<ClienteController> logger, IClienteUseCase clienteUseCase)
        {
            _logger = logger;
            _clienteUseCase = clienteUseCase;
        }

        /// <summary>
        /// Cadastrar um cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Cliente cliente)
        {
            await _clienteUseCase.Cadastrar(cliente);
            return Ok(cliente);
        }

        /// <summary>
        /// Consultar um cliente por CPF
        /// </summary>
        /// <param name="cpf">CPF</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ConsultarPorCpf")]
        public async Task<IActionResult> ConsultarPorCpf(string cpf)
        {
            var cliente = await _clienteUseCase.ConsultarPorCpf(cpf);
            return Ok(cliente);
        }
    }
}
