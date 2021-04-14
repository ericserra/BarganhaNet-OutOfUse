using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarganhaNETv3.Models
{
    public class PessoaFisica : Usuario
    {
        [Required]
        [StringLength(11, ErrorMessage = "Ultrapassou o limite de 11 caracteres")]
        public string Cpf { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Ultrapassou o limite de 100 caracteres")]
        public string Sobrenome { get; set; }

    }
}
