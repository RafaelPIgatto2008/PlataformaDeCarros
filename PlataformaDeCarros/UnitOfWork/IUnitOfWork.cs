using PlataformaDeCarros.Interface;
using PlataformaDeCarros.InterfaceServices;

namespace PlataformaDeCarros.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICarService CarService { get; }
    IDriverService DriverService { get; }
    IAttendantService AttendantService { get; }
    
    Task<bool> CommitAsync();
}