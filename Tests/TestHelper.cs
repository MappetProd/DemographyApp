using Demography.Domain;
using Demography.Infrastructure;
using DemographyApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class TestHelper
{
    private readonly Context _context;

    public TestHelper()
    {
        var contextOptions = new DbContextOptionsBuilder<Context>()
            .UseNpgsql("Host=localhost;Port=5432;Database=demography_unit_test;Username=elmir;Password=")
            .Options;

        _context = new Context(contextOptions);

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        var region = new Region { Id = Guid.NewGuid(), Name = "TestRegion1" };

        _context.Regions.Add(region);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();

        var demographyData = new DemographyData { Year = 2002, RegionId = region.Id };

        demographyData.AgeGroups = new List<Age>();
        demographyData.AgeGroups.Add(new Age { MenQuantity = 30, WomenQuantity = 30, AgeValue = 25 });
        demographyData.AgeGroups.Add(new Age { MenQuantity = 20, WomenQuantity = 30, AgeValue = 60 });

        demographyData.EthnicGroups = new List<Ethnos>();
        demographyData.EthnicGroups.Add( new Ethnos { Name = "TestEthno1", MenQuantity = 30, WomenQuantity = 30 });
        demographyData.EthnicGroups.Add( new Ethnos { Name = "TestEthnos2", MenQuantity = 100, WomenQuantity = 300 });

        demographyData.DensityGroups = new List<Density>();
        demographyData.DensityGroups.Add( new Density { AreaSize = 300, PopulationDensity = 200, PopulationSize = 200 });
        demographyData.DensityGroups.Add( new Density { AreaSize = 20000, PopulationDensity = 3000, PopulationSize = 2000 });

        demographyData.Migrations = new List<Migration>();
        demographyData.Migrations.Add( new Migration { MigrantsCount = 300, EmigrantsCount=200, MigrationRatio = 200});
        demographyData.Migrations.Add( new Migration { MigrantsCount = 200, EmigrantsCount = 100, MigrationRatio = 300});

        demographyData.NaturalGrowthGroups = new List<NaturalGrowth>();
        demographyData.NaturalGrowthGroups.Add( new NaturalGrowth { BithRate = 30, MortalityRate = 20 });
        demographyData.NaturalGrowthGroups.Add( new NaturalGrowth { BithRate = 40, MortalityRate = 60 });

        _context.DemographyDatum.Add(demographyData);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public DemographyDataRepository DemographyDataRepository
    {
        get
        {
            return new DemographyDataRepository(_context);
        }
    }

    public RegionRepository RegionRepository
    {
        get
        {
            return new RegionRepository(_context);
        }
    }
}

