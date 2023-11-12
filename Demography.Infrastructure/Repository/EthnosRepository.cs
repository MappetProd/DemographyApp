using Demography.Domain;
using Demography.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class EthnosRepository
{
    private readonly Context _context;

    public Context UnitOfWork
    {
        get {return _context;}
    }

    public EthnosRepository(Context context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Ethnos?> GetByNameAsync(string name)
    {
        return await _context.EthnicGroups
            .Where(ethnos => ethnos.Name == name)
            .FirstOrDefaultAsync();
    }

    public async Task<Ethnos?> GetByIdAsync(Guid id)
    {
        return await _context.EthnicGroups
            .Where(ethnos => ethnos.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Ethnos>> GetAllAsync()
    {
        return await _context.EthnicGroups.OrderBy(p => p.Name).ToListAsync();
    }

    public async Task<Ethnos> AddAsync(Ethnos ethnos)
    {
        _context.EthnicGroups.Add(ethnos);
        await _context.SaveChangesAsync();
        return ethnos;
    }

    public async Task<Ethnos?> UpdateAsync(Ethnos ethnos)
    {
        var result = await _context.EthnicGroups.FirstOrDefaultAsync(e => e.Id == ethnos.Id);

        if (result != null){
            result.Name = ethnos.Name;
            result.MenQuantity = ethnos.MenQuantity;
            result.WomenQuantity = ethnos.WomenQuantity;
            await _context.SaveChangesAsync();
            return result;
        }

        return null;
    }

    public async Task DeleteAsync(Guid id)
    {
        var result = await _context.EthnicGroups.FirstOrDefaultAsync(e => e.Id == id);
        if (result != null){
            _context.EthnicGroups.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

    public void ChangeTrackerClear()
    {
        _context.ChangeTracker.Clear();
    }
}