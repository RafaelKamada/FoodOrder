﻿using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Commands
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
