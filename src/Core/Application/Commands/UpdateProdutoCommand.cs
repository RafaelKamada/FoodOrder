﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace FoodOrder.Application.Commands
{
    public class UpdateProdutoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }

        [SwaggerSchema(Format = "binary")]
        public List<IFormFile?> Imagens { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TempoPreparo { get; set; }
    }
}
