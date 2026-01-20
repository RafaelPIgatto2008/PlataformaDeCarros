using PlataformaDeCarros.Interface;

namespace PlataformaDeCarros.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICarRepository CarRepository { get; }
    IDriverRepository DriverRepository { get; }
    IAttendantRepository AttendantRepository { get; }
    
    Task<bool> CommitAsync();
}