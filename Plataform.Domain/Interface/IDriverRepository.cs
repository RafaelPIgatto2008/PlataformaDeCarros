using Plataform.Domain.Entities;

namespace Plataform.Domain.Interface;

public interface IDriverRepository : IRepository<Driver>
{
    Task<Driver> GetByNameAsync(string name, CancellationToken cancellationToken);
}