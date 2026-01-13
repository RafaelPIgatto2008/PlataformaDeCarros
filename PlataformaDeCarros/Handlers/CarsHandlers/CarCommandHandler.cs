using MediatR;
using PlataformaDeCarros.Commands.Car;
using PlataformaDeCarros.DTOs;
using PlataformaDeCarros.InterfaceServices;

namespace PlataformaDeCarros.Handlers.CarsHandlers;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, bool>
{
    private readonly ILogger<CreateCarCommandHandler> _logger;
    private readonly ICarService _carService;

    public CreateCarCommandHandler(ILogger<CreateCarCommandHandler> logger, ICarService carService)
    {
        _logger = logger;
        _carService = carService;
    }
    
    public async Task<bool> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var existsCar = await _carService.GetByPlateAsync(request.Dto.Plate);
        if (existsCar != null)
            throw new Exception("This plate already registered");
        
        var newCar = new CarDto()
        {
            Brand = request.Dto.Brand,
            Color = request.Dto.Color,
            Fabrication = request.Dto.Fabrication,
            Model = request.Dto.Model,
            Plate = request.Dto.Plate,
        };
        
        await _carService.CreateCarAsync(newCar);
        return true;
    }
}