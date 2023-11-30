using Demography.Domain;
using Demography.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DemographyApp.Infrastructure;

public class AgeRepository : GenericRepository<Age>, IGenericRepository<Age>
{
    public Context _context { get; }
    public AgeRepository(Context context) : base(context)
    {
        _context = context;
    }
}
