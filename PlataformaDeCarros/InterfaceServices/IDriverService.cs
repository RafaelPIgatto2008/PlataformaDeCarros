using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.InterfaceServices;

public interface IDriverService
{
    Task<DriverDto> GetByName(string name);
    Task<DriverDto> CreateDriverAsync(DriverDto driverDto);
    Task<DriverDto> DeleteDriverAsync(Guid id);
}