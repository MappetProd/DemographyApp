using Demography.Domain;
using Demography.Infrastructure;

namespace DemographyApp.Infrastructure;

public class EthnosRepository : GenericRepository<Ethnos>, IGenericRepository<Ethnos>
{
    public Context _context { get; }
    public EthnosRepository(Context context) : base(context)
    {
        _context = context;
    }
}
