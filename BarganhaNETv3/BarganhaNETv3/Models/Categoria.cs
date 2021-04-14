using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarganhaNETv3.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public CategoriaEnum CategoriaEnum { get; set; }
        public Usuario CategoriaUsuarios { get; set; }
    }
}
