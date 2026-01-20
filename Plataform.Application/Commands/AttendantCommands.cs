using FluentResults;
using MediatR;
using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.Commands;

public class CreateAttendantCommand : IRequest<Result<bool>>
{
    public AttendantDto AttendantDto { get; set; }
    
    public CreateAttendantCommand(AttendantDto attendantDto)
    {
        AttendantDto = attendantDto;
    }
}