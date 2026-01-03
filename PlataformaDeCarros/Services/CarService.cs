using AutoMapper;
using PlataformaDeCarros.DTOs;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.Interface;
using PlataformaDeCarros.InterfaceServices;

namespace PlataformaDeCarros.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _repository;    
    private readonly IMapper _mapper;
    
    
    public CarService(ICarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<CarDto> GetByBrandAsync(string brand)
    {
        var car = await _repository.GetByBrandAsync(brand);
        if (car == null)
            throw new ("Car not found");

        var dto = _mapper.Map<CarDto>(car);
        return dto;
    }

    public async Task<CarDto> GetByPlateAsync(string plate)
    {
        var car = await _repository.GetByPlateAsync(plate);
        if (car == null)
            throw new("Plate not found");
        
        var dto = _mapper.Map<CarDto>(car);
        return dto;
    }

    public async Task<CarDto> CreateCarAsync(CarDto carDto)
    {
        var car = await _repository.GetByPlateAsync(carDto.Plate);
        if (car == null)
        {
            var newCar = new Car(
                carDto.Model, 
                carDto.Color, 
                carDto.Brand, 
                carDto.Plate, 
                carDto.Fabrication);
            
            await _repository.AddAsync(newCar);
            await _repository.SaveChangesAsync();

            return carDto;
        }
        
        throw new Exception("Car already exists");
    }

    public async Task<bool> DeleteCarAsync(Guid id)
    {
        var car = await _repository.GetByIdAsync(id);
        if (car == null)
            throw new("Nothing to delete");
        
        await _repository.DeleteAsync(car);
        await _repository.SaveChangesAsync();
        
        return true;
    }
}