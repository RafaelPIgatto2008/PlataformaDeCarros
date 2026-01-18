using Microsoft.EntityFrameworkCore;
using PlataformaDeCarros.Data;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.Interface;

namespace PlataformaDeCarros.Repositories;

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