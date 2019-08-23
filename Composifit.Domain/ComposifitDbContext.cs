using Composifit.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Domain
{
    public class ComposifitDbContext : DbContext
    {
        public ComposifitDbContext(DbContextOptions<ComposifitDbContext> options) : base(options) { }
        public DbSet<Meso> Mesocycles { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Cardio> Cardio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
