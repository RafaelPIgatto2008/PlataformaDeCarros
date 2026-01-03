using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.InterfaceServices;

public interface ICarService
{
    Task<CarDto> GetByBrandAsync (string brand);
    Task<CarDto> GetByPlateAsync (string plate);
    Task<CarDto> CreateCarAsync (CarDto carDto);
    Task<bool> DeleteCarAsync(Guid id);
}