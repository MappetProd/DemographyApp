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

    public async Task AddDemographyDatumAsync(Guid ethnosId, Guid demographyDatumId)
    {
        var ethnos = await _context.EthnicGroups.FindAsync(ethnosId);
        var demographyDatum = await _context.DemographyDatum.FindAsync(demographyDatumId);

        if (ethnos != null && demographyDatum != null)
        {
            ethnos.DemographyDatum.Add(demographyDatum);
            await _context.SaveChangesAsync();
        }
    }
}
