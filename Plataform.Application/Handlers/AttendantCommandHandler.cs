using FluentResults;
using MediatR;
using Plataform.Application.Commands;
using Plataform.Domain.Entities;
using Plataform.Infraestructure.UnitOfWork;

namespace Plataform.Application.Handlers;

public class CreateAttendantCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateAttendantCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    
    public async Task<Result<bool>> Handle(CreateAttendantCommand request, CancellationToken cancellationToken)
    {
        var existAttendant =
            await _unitOfWork.AttendantRepository.GetByCpfAsync(request.AttendantDto.Cpf, cancellationToken);
        if (existAttendant != null)
            return Result.Fail("Attendant with same CPF already exists");

        var newAttendant = new Attendant()
        {
            Name = request.AttendantDto.Name,
            Cpf = request.AttendantDto.Cpf,
            Cep = request.AttendantDto.Cep,
            Email = request.AttendantDto.Email,
            IsActive = true,
            Phone = request.AttendantDto.Phone,
        };

        await unitOfWork.AttendantRepository.AddAsync(newAttendant);
        await _unitOfWork.CommitAsync();
        
        return Result.Ok(true);
    }
}