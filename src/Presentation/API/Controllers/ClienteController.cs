using FoodOrder.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController(ILogger<ClienteController> logger, IMediator mediator) : Controller
{
    private readonly ILogger<ClienteController> _logger = logger;
    private readonly IMediator _mediator = mediator;

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

    /// <summary>
    /// Consultar um cliente por CPF
    /// </summary>
    /// <param name="cpf">CPF</param>
    /// <returns></returns>
    [HttpGet]
    [Route("ConsultarPorCpf/{cpf}")]
    public async Task<IActionResult> ConsultarPorCpf(string cpf)
    {
        var query = new ClienteCollectionQuery(cpf);
        var cliente = await _mediator.Send(query);
        return Ok(cliente);
    }
}
