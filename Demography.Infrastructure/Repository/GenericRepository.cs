using System.Diagnostics.CodeAnalysis;
using Demography.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DemographyApp.Infrastructure;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly Context _context;

    public Context UnitOfWork
    {
        get {return _context;}
    }
    internal DbSet<TEntity> dbSet;

    public GenericRepository(Context context)
    {
        this._context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync([NotNull] TEntity entity)
    {   
        await dbSet.AddAsync(entity);
        _context.SaveChanges();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entityToDelete = await dbSet.FindAsync(id);
        if (entityToDelete == null) return false;

        dbSet.Remove(entityToDelete);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<TEntity> UpdateAsync([NotNull] TEntity entity)
    {
        dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public void ChangeTrackerClear()
    {
        _context.ChangeTracker.Clear(); 
    }
}