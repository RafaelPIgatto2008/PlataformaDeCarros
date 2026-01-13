using MediatR;
using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.Commands.Car;

public class CreateCarCommand : IRequest<bool>
{
    public CarDto Dto { get; set; }

    public CreateCarCommand(CarDto dto)
    {
        Dto = dto;
    }
}