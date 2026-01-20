using Plataform.Domain.Entities;

namespace Plataform.Domain.Interface;

public interface ICarRepository : IRepository<Car>
{
    Task<Car> GetByPlateAsync (string plate, CancellationToken cancellationToken);
    Task<Car> GetByBrandAsync (string brand, CancellationToken cancellationToken);
}