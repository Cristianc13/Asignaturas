using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AFK.Models;

namespace AFK.Data
{
    public class AFKContext : DbContext
    {
        public AFKContext (DbContextOptions<AFKContext> options)
            : base(options)
        {
        }

        public DbSet<AFK.Models.Estudiante> Estudiante { get; set; }
    }
}
