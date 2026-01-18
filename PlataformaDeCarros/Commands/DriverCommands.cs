using FluentResults;
using MediatR;
using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.Commands;

public class CreateDriverCommand : IRequest<Result<bool>>
{
    public DriverDto DriverDto { get; set; }

    public CreateDriverCommand(DriverDto driverDto)
    {
        DriverDto = driverDto;
    }
}