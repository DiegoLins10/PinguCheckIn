using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinguCheckIn.Models;
using PinguCheckIn.Models.Entidades;

namespace PinguCheckIn.Data
{
    public class PinguCheckInContext : DbContext
    {
        public PinguCheckInContext (DbContextOptions<PinguCheckInContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Quarto> Quarto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

    }
}
