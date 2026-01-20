using Plataform.Domain.Interface;

namespace Plataform.Infraestructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICarRepository CarRepository { get; }
    IDriverRepository DriverRepository { get; }
    IAttendantRepository AttendantRepository { get; }
    
    Task<bool> CommitAsync();
}