using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CitireContoareApa.Models;

namespace CitireContoareApa.Data
{
    public class CitireContoareApaContext : DbContext
    {
        public CitireContoareApaContext (DbContextOptions<CitireContoareApaContext> options)
            : base(options)
        {
        }

        public DbSet<CitireContoareApa.Models.User> User { get; set; } = default!;
        public DbSet<CitireContoareApa.Models.Tarif> Tarif { get; set; } = default!;
        public DbSet<CitireContoareApa.Models.Plata> Plata { get; set; } = default!;
        public DbSet<CitireContoareApa.Models.Factura> Factura { get; set; } = default!;
        public DbSet<CitireContoareApa.Models.Contor> Contor { get; set; } = default!;
    }
}
