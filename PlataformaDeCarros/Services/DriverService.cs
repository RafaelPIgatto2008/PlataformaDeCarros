using AutoMapper;
using PlataformaDeCarros.DTOs;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.Interface;
using PlataformaDeCarros.InterfaceServices;

namespace PlataformaDeCarros.Services;

public class DriverService : IDriverService
{
    private readonly IDriverRepository _repository;
    private readonly IMapper _mapper;
    
    public DriverService(IDriverRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DriverDto> GetByName(string name)
    {
        var driver  = await _repository.GetByNameAsync(name);
        if (driver == null)
            throw new ("Driver not found");
        
        var dto = _mapper.Map<DriverDto>(driver);
        return dto;
    }

    public async Task<DriverDto> CreateDriverAsync(DriverDto driverDto)
    {
        var driver = await _repository.GetByNameAsync(driverDto.Name);
        if (driver == null)
        {
            var newDriver = new Driver(
                driverDto.Name, 
                driverDto.Email, 
                driverDto.Password, 
                driverDto.PhoneNumber, 
                driverDto.Cep);
            
            await _repository.AddAsync(newDriver);
            await _repository.SaveChangesAsync();
            
            return _mapper.Map<DriverDto>(newDriver);
        }
        
        throw new Exception("Driver already exists");
    }

    public async Task<DriverDto> DeleteDriverAsync(Guid id)
    {
        var driver = await _repository.GetByIdAsync(id);
        if (driver == null)
            throw new ("Driver not exists");
        
        await _repository.DeleteAsync(driver);
        await _repository.SaveChangesAsync();
        
        var dto = _mapper.Map<DriverDto>(driver);
        return dto;
    }
}