using Demography.Domain;
using Demography.Infrastructure;

namespace DemographyApp.Infrastructure;

public class DensityRepository : GenericRepository<Density>, IGenericRepository<Density>
{
    public Context _context { get; }
    public DensityRepository(Context context) : base(context)
    {
        _context = context;
    }
}
