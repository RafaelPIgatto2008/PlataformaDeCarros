using PlataformaDeCarros.Entities;

namespace PlataformaDeCarros.Interface;

public interface IAttendantRepository : IRepository<Attendant>
{
    Task<Attendant> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<Attendant> GetByNameAsync (string name, CancellationToken cancellationToken);
    Task<Attendant> GetByCpfAsync (string cpf, CancellationToken cancellationToken);
}