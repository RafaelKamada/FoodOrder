using Foodorder.API.Controllers;
using FoodOrder.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FoodOrder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookController : Controller
    {
        private readonly ILogger<WebhookController> _logger;
        private readonly IMediator _mediator;

        public WebhookController(IMediator mediator, ILogger<WebhookController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Webhook de pagamentos, para receber o status do pagamento.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Pagamentos")]
        public async Task<IActionResult> Pagamentos([FromBody] UpdatePagtoWebhookCommand command)
        {
            var identificacaoPedido = await _mediator.Send(command);
            return Ok(identificacaoPedido);
        }


        [HttpPost]
        [Route("ReceiveJson")]
        public IActionResult ReceiveJson([FromBody] JsonElement jsonPayload)
        {
            // Log the entire JSON payload
            _logger.LogInformation("Received JSON payload: {JsonPayload}",
                JsonSerializer.Serialize(jsonPayload, new JsonSerializerOptions { WriteIndented = true }));

            // Log additional details about the JSON structure
            LogJsonStructure(jsonPayload);

            return Ok("JSON received and logged successfully");
        }

        private void LogJsonStructure(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    _logger.LogInformation("Payload is a JSON Object with {PropertyCount} properties",
                        element.EnumerateObject().Count());
                    foreach (var property in element.EnumerateObject())
                    {
                        _logger.LogInformation("Property Name: {PropertyName}, Type: {PropertyType}",
                            property.Name, property.Value.ValueKind);
                    }
                    break;

                case JsonValueKind.Array:
                    _logger.LogInformation("Payload is a JSON Array with {ArrayLength} items",
                        element.GetArrayLength());
                    break;

                default:
                    _logger.LogInformation("Payload is a simple {ValueType} with value: {Value}",
                        element.ValueKind, element.ToString());
                    break;
            }
        }
    }
}
