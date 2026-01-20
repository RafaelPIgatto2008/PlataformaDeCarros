using Microsoft.EntityFrameworkCore;
using Plataform.Domain.Entities;
using Plataform.Domain.Interface;
using Plataform.Infraestructure.Data;

namespace Plataform.Infraestructure.Repositories;

public class DriverRepository : BaseRepository<Driver>, IDriverRepository
{
    public DriverRepository(CarsDbContext context) : base(context) { }

    public async Task<Driver> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }
}