using Microsoft.EntityFrameworkCore;
using PlataformaDeCarros.Data;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.Interface;

namespace PlataformaDeCarros.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(CarsDbContext context) : base(context) { }

    public async Task<Car> GetByPlateAsync(string plate)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Plate == plate);
    }

    public async Task<Car> GetByBrandAsync(string brand)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Brand == brand);
    }
}