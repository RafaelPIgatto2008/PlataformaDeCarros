using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.InterfaceServices;

public interface IAttendantService
{
    Task<AttendantDto> GetByEmailAsync(string email);
    Task<AttendantDto> GetByNameAsync (string name);
    Task<AttendantDto> GetByCpfAsync (string cpf);
    Task<AttendantDto> CreateAttendantAsync (AttendantDto attendantDto);
    Task<bool> DeleteAttendantAsync(Guid id);
}