using FluentResults;
using MediatR;
using PlataformaDeCarros.Commands.Car;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.UnitOfWork;

namespace PlataformaDeCarros.Handlers;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<bool>>
{
    private readonly ILogger<CreateCarCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarCommandHandler(ILogger<CreateCarCommandHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<bool>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var existCar = await _unitOfWork.CarRepository.GetByPlateAsync(request.Dto.Plate, cancellationToken);
        if (existCar != null)
            return Result.Fail("Car with same plate already registered");

        var newCar = new Car()
        {
            Plate = request.Dto.Plate,
            Model = request.Dto.Model,
            Color = request.Dto.Color,
            Brand = request.Dto.Brand,
            Fabrication = request.Dto.Fabrication,
        };

        await _unitOfWork.CarRepository.AddAsync(newCar);
        await _unitOfWork.CommitAsync();
        
        return Result.Ok(true);
    }
}