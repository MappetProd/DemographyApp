namespace DemographyApp.Infrastructure;

public interface IGenericRepository<TEntity>
{

    public Task<TEntity?> GetByIdAsync(Guid id);

    public Task<List<TEntity>> GetAllAsync();

    public Task<TEntity> AddAsync(TEntity entity);

    public Task<TEntity> UpdateAsync(TEntity entity);

    public Task<bool> DeleteAsync(Guid id);

    public void ChangeTrackerClear();
}
