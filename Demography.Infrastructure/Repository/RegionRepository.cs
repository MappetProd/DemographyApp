using Demography.Domain;
using Demography.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DemographyApp.Infrastructure;

public class RegionRepository : GenericRepository<Region>, IGenericRepository<Region>
{
    public Context _context { get; }
    public RegionRepository(Context context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Region>> GetAllAsync(string? name)
    {   

        var query = _context.Regions.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(r => r.Name.Contains(name));
        }

        var regions = await query
            .OrderBy(r => r.Name)
            .ToListAsync();

        return regions;
    }

    public async Task<Region> GetAsyncById(Guid id)
    {
        var region = await _context.Regions
            .Where(r => r.Id == id)
            .Include(r => r.DemographyDatum)
                .ThenInclude(dd => dd.EthnicGroups)
            .Include(r => r.DemographyDatum)
                .ThenInclude(dd => dd.AgeGroups)
            .Include(r => r.DemographyDatum)
                .ThenInclude(dd => dd.NaturalGrowthGroups)
            .Include(r => r.DemographyDatum)
                .ThenInclude(dd => dd.DensityGroups)
            .Include(r => r.DemographyDatum)
                .ThenInclude(dd => dd.Migrations)
            .FirstAsync();
        
        return region;
    }
}