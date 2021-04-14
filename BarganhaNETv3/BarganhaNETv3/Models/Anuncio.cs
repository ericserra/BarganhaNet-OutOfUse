using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BarganhaNETv3.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public CategoriaEnum Categoria { get; set; }
        [NotMapped]
        public IFormFile ArquivoFoto { get; set; }
    }
}
