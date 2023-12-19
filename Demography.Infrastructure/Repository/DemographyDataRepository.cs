using Demography.Domain;
using Demography.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DemographyApp.Infrastructure;

public class DemographyDataRepository : GenericRepository<DemographyData>, IGenericRepository<DemographyData>
{
    public Context _context { get; }
    public DemographyDataRepository(Context context) : base(context)
    {
        _context = context;
    }

    public async Task<DemographyData> GetAsyncById(Guid id)
    {
        var demographyData = await _context.DemographyDatum
            .Include(dd => dd.EthnicGroups)
            .Include(dd => dd.AgeGroups)
            .Include(dd => dd.NaturalGrowthGroups)
            .Include(dd => dd.DensityGroups)
            .Include(dd => dd.Migrations)
            .FirstAsync();
        
        return demographyData;
    }
}