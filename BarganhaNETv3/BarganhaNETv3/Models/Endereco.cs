using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarganhaNETv3.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string Logradouro { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string Numero { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string Bairro { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string Complemento { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Ultrapassou o limite de 8 caracteres")]
        public string Cep { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string UF { get; set; }
    }
}
