using FluentResults;
using MediatR;
using Plataform.Application.DTOs;

namespace PlataformaDeCarros.Commands.Car;

public class CreateCarCommand : IRequest<Result<bool>>
{
    public CarDto Dto { get; set; }

    public CreateCarCommand(CarDto dto)
    {
        Dto = dto;
    }
}