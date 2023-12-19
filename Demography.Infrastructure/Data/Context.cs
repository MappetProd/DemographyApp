using Microsoft.EntityFrameworkCore;

using Demography.Domain;

namespace Demography.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        
        public DbSet<DemographyData> DemographyDatum { get; set; }

        public DbSet<Ethnos> EthnicGroups { get; set; }

        public DbSet<Age> AgeGroupds {get; set; }

        public DbSet<Density> Densities {get; set; }

        public DbSet<Migration> Migrations {get; set; }

        public DbSet<NaturalGrowth> NaturalGrowths {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}