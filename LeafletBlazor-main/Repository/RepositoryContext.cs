using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
            { 

            }
        }
   /*     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MarkersConfiguration());
        }*/
        public DbSet<MarkerProperties> Markers { get; set; }
    }
}
