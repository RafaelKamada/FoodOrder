using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ImagemDto
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
        public string Nome { get; set; }
    }
}
