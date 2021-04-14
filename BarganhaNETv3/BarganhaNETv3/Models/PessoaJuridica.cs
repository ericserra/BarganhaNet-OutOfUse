using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BarganhaNETv3.Models
{
    public class PessoaJuridica : Usuario
    {
        [Required]
        [StringLength(14, ErrorMessage = "Ultrapassou o limite de 14 caracteres")]
        public string Cnpj { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string NomeEmpresa { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string NomeFantasia { get; set; }
        public string Document { get; set; }
        [NotMapped]
        public bool ChecarNomeFantasia { get; set; }
        [NotMapped]
        public IFormFile DocumentoArquivo { get; set; }
    }
}
