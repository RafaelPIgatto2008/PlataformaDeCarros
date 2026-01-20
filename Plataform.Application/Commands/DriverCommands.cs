using FluentResults;
using MediatR;
using Plataform.Application.DTOs;

namespace Plataform.Application.Commands;

public class CreateDriverCommand : IRequest<Result<bool>>
{
    public DriverDto DriverDto { get; set; }

    public CreateDriverCommand(DriverDto driverDto)
    {
        DriverDto = driverDto;
    }
}