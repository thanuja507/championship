using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using F1Championship.Models;

namespace F1Championship.Data
{
    public class F1ChampionshipContext : DbContext
    {
        public F1ChampionshipContext (DbContextOptions<F1ChampionshipContext> options)
            : base(options)
        {
        }

        public DbSet<F1Championship.Models.Teams> Teams { get; set; } = default!;

        public DbSet<F1Championship.Models.Drivers> Drivers { get; set; } = default!;

        public DbSet<F1Championship.Models.Leagues> Leagues { get; set; } = default!;
    }
}
