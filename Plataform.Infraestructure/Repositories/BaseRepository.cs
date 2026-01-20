using Microsoft.EntityFrameworkCore;
using Plataform.Domain.Interface;
using Plataform.Infraestructure.Data;

namespace Plataform.Infraestructure.Repositories;

public class BaseRepository <T> : IRepository<T> where T : class
{
    protected readonly CarsDbContext _context;
    protected readonly DbSet<T> _dbSet;
    
    public BaseRepository(CarsDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        await _dbSet.ToListAsync();
        return _dbSet;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return true;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}