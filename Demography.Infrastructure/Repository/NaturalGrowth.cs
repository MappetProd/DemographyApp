using Demography.Domain;
using Demography.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DemographyApp.Infrastructure;

public class NaturalGrowthRepository : GenericRepository<NaturalGrowth>, IGenericRepository<NaturalGrowth>
{
    public Context _context { get; }
    public NaturalGrowthRepository(Context context) : base(context)
    {
        _context = context;
    }
}
