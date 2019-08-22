using Composifit.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conposifit.Infrastructure
{
    public class ComposifitDbContext : DbContext
    {
        public DbSet<Meso> Mesocycles { get; set; }
    }
}
