using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BarganhaNETv3.Models;

namespace BarganhaNETv3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BarganhaNETv3.Models.PessoaFisica> PessoaFisica { get; set; }
        public DbSet<BarganhaNETv3.Models.PessoaJuridica> PessoaJuridica { get; set; }
    }
}
