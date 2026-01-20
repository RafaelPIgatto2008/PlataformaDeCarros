using Plataform.Domain.Interface;
using Plataform.Infraestructure.Data;

namespace Plataform.Infraestructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private CarsDbContext _context { get; }
    public ICarRepository CarRepository { get; }
    public IDriverRepository DriverRepository { get; }
    public IAttendantRepository AttendantRepository { get; }
    
    
    public UnitOfWork(CarsDbContext context, 
        IDriverRepository driverRepository, 
        IAttendantRepository attendantRepository, 
        ICarRepository carRepository)
    {
        _context = context;
        CarRepository = carRepository;
        AttendantRepository = attendantRepository;
        DriverRepository = driverRepository;
    }



    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}