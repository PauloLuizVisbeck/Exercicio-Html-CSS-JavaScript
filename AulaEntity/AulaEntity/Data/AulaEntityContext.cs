using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AulaEntity.Models;

namespace AulaEntity.Data
{
    public class AulaEntityContext : DbContext
    {
        public AulaEntityContext (DbContextOptions<AulaEntityContext> options)
            : base(options)
        {
        }

        public DbSet<AulaEntity.Models.Contato> Contato { get; set; } = default!;
        public DbSet<AulaEntity.Models.Local> Local { get; set; } = default!;
        public DbSet<AulaEntity.Models.Compromisso>? Compromisso { get; set; }

    }
}
