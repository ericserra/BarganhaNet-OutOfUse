using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BarganhaNETv3.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public IdentityUser Client { get; set; }
        public Endereco Endereco{ get; set; }
        public string Foto { get; set; }
        public bool StatusDaConta { get; set; }
        public List<Lance> Lance { get; set; }
        public List<Categoria> Interesse { get; set; }
        public int Avaliacao { get; set; }
        [NotMapped]
        public string Senha { get; set; }
        [NotMapped]
        public string Email { get; set; }
        [NotMapped]
        public IFormFile ArquivoFoto { get; set; }
    }
}
