using PlataformaDeCarros.Entities;

namespace PlataformaDeCarros.Interface;

public interface ICarRepository : IRepository<Car>
{
    Task<Car> GetByPlateAsync (string plate);
    Task<Car> GetByBrandAsync (string brand);
}