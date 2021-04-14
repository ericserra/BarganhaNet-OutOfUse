using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarganhaNETv3.Models
{
    public class LanceLeilao
    {
        public int Id { get; set; }
        public Usuario UsuarioLance { get; set; }
        [Column(TypeName = "Decimal(7,2)")]
        public decimal ValorLance { get; set; }
    }
}
