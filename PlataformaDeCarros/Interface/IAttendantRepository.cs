using PlataformaDeCarros.Entities;

namespace PlataformaDeCarros.Interface;

public interface IAttendantRepository : IRepository<Attendant>
{
    Task<Attendant> GetByEmailAsync(string email);
    Task<Attendant> GetByNameAsync (string name);
    Task<Attendant> GetByCpfAsync (string cpf);
}