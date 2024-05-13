using EFCoreAssignment2.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment2.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly EFDay2Context _dbContext;
    public GenericRepository(EFDay2Context dbContext) {
        _dbContext = dbContext;
    }

    public IEnumerable<T> GetAll() 
    {
        return _dbContext.Set<T>().ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task InsertAsync(T obj)
    {
        await _dbContext.Set<T>().AddAsync(obj);
    }

    public void Update(T obj)
    {
        _dbContext.Set<T>().Update(obj);
    }

    public async Task DeleteAsync(Guid id)
    {
        var obj = await _dbContext.Set<T>().FindAsync(id);
        if (obj != null) {
            _dbContext.Set<T>().Remove(obj);
        }
    }
    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<T> GetAllQueryable()
    {
        return _dbContext.Set<T>();
    }
}