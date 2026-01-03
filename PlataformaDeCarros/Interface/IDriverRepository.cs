using PlataformaDeCarros.Entities;

namespace PlataformaDeCarros.Interface;

public interface IDriverRepository : IRepository<Driver>
{
    Task<Driver> GetByNameAsync(string name);
}