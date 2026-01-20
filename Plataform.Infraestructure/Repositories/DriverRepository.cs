using Microsoft.EntityFrameworkCore;
using Plataform.Infraestructure.Data;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.Interface;

namespace Plataform.Infraestructure.Repositories;

public class DriverRepository : BaseRepository<Driver>, IDriverRepository
{
    public DriverRepository(CarsDbContext context) : base(context) { }

    public async Task<Driver> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }
}