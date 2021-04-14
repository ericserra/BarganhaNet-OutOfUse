using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarganhaNETv3.Models
{
    public class Lance
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public List<LanceLeilao> LanceLeilao { get; set; }
        public Anuncio Anuncio { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [Column(TypeName = "Decimal(7,2)")]
        public decimal PrecoInicial { get; set; }
        [Column(TypeName ="Decimal(7,2)")]
        public decimal PrecoAtual { get; set; }
        public bool StatusLance { get; set; }
        public Lance()
        {
            Start = DateTime.Now;
            End = Start.AddDays(30);
            StatusLance = true;
        }

    }
}
