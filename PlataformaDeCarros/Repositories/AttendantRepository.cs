using Microsoft.EntityFrameworkCore;
using PlataformaDeCarros.Data;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.Interface;

namespace PlataformaDeCarros.Repositories;

public class AttendantRepository : BaseRepository<Attendant>, IAttendantRepository
{
    public AttendantRepository(CarsDbContext context) : base(context) { }

    public async Task<Attendant> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
    }

    public async Task<Attendant> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Name == name, cancellationToken);
    }

    public async Task<Attendant> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Cpf == cpf, cancellationToken);
    }
}