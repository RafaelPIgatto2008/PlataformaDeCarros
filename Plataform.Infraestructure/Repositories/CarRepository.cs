using Microsoft.EntityFrameworkCore;
using Plataform.Domain.Entities;
using Plataform.Domain.Interface;
using Plataform.Infraestructure.Data;

namespace Plataform.Infraestructure.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(CarsDbContext context) : base(context) { }

    public async Task<Car> GetByPlateAsync(string plate, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Plate == plate, cancellationToken);
    }

    public async Task<Car> GetByBrandAsync(string brand, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Brand == brand, cancellationToken);
    }
}