using Microsoft.EntityFrameworkCore;
using PlataformaDeCarros.Data;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.Interface;

namespace PlataformaDeCarros.Repositories;

public class AttendantRepository : BaseRepository<Attendant>, IAttendantRepository
{
    public AttendantRepository(CarsDbContext context) : base(context) { }

    public async Task<Attendant> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<Attendant> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Name == name);
    }

    public async Task<Attendant> GetByCpfAsync(string cpf)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Cpf == cpf);
    }
}