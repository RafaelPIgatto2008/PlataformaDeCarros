using MediatR;
using PlataformaDeCarros.Commands.Car;
using PlataformaDeCarros.DTOs;
using PlataformaDeCarros.InterfaceServices;
using PlataformaDeCarros.UnitOfWork;

namespace PlataformaDeCarros.Handlers.CarsHandlers;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, bool>
{
    private readonly ILogger<CreateCarCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarCommandHandler(ILogger<CreateCarCommandHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<bool> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var existsCar = await _unitOfWork.CarService.GetByPlateAsync(request.Dto.Plate);
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
        
        await _unitOfWork.CarService.CreateCarAsync(newCar);
        return true;
    }
}