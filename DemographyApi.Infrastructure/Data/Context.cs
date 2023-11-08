using Microsoft.EntityFrameworkCore;

using DemographyApi.Domain;

namespace DemographyApi.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        
        public DbSet<DemographyData> DemographyDatas { get; set; }

        public DbSet<Ethnos> EthnicGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}