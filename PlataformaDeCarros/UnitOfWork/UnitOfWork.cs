using PlataformaDeCarros.Data;
using PlataformaDeCarros.Interface;
using PlataformaDeCarros.InterfaceServices;
using PlataformaDeCarros.Services;

namespace PlataformaDeCarros.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private CarsDbContext _context { get; }
    public ICarService CarService { get; }
    public IDriverService DriverService { get; }
    public IAttendantService AttendantService { get; }
    
    public UnitOfWork(CarsDbContext context, 
        ICarService carService, 
        IAttendantService attendantService, 
        IDriverService driverService)
    {
        _context = context;
        CarService = carService;
        DriverService = driverService;
        AttendantService = attendantService;
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