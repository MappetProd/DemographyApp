using Demography.Domain;
using Demography.Infrastructure;

namespace DemographyApp.Infrastructure;

public class MigrationRepository : GenericRepository<Migration>, IGenericRepository<Migration>
{
    public Context _context { get; }
    public MigrationRepository(Context context) : base(context)
    {
        _context = context;
    }
}
