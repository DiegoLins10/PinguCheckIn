using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinguCheckIn.Models;

namespace PinguCheckIn.Data
{
    public class PinguCheckInContext : DbContext
    {
        public PinguCheckInContext (DbContextOptions<PinguCheckInContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
