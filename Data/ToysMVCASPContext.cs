using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToysMVCASP.Models;

namespace ToysMVCASP.Data
{
    public class ToysMVCASPContext : DbContext
    {
        public ToysMVCASPContext (DbContextOptions<ToysMVCASPContext> options)
            : base(options)
        {
        }

        public DbSet<ToysMVCASP.Models.Toy> Toy { get; set; }

        public DbSet<ToysMVCASP.Models.ToyStore> ToyStore { get; set; }

        public DbSet<ToysMVCASP.Models.ToyRel> ToyRel { get; set; }

        public DbSet<ToysMVCASP.Models.Category> Category { get; set; }
    }
}
