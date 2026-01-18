using FluentResults;
using MediatR;
using PlataformaDeCarros.Commands;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.UnitOfWork;

namespace PlataformaDeCarros.Handlers;

public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Result<bool>>
{
    private readonly ILogger<CreateDriverCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDriverCommandHandler(ILogger<CreateDriverCommandHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<bool>> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        var existsDriver = await _unitOfWork.DriverRepository.GetByNameAsync(request.DriverDto.Name, cancellationToken);
        if (existsDriver != null)
            return Result.Fail("Driver with same name already exsists");

        var newDriver = new Driver()
        {
            Name = request.DriverDto.Name,
            Email = request.DriverDto.Email,
            Cep = request.DriverDto.Cep,
            Password = request.DriverDto.Password,
            PhoneNumber = request.DriverDto.PhoneNumber
        };
        
        await _unitOfWork.DriverRepository.AddAsync(newDriver);
        await _unitOfWork.CommitAsync();
        
        return Result.Ok(true);
    }
}