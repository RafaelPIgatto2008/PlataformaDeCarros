using System.Runtime.CompilerServices;
using AutoMapper;
using PlataformaDeCarros.DTOs;
using PlataformaDeCarros.Entities;
using PlataformaDeCarros.Interface;
using PlataformaDeCarros.InterfaceServices;

namespace PlataformaDeCarros.Services;

public class AttendantService : IAttendantService
{
    private readonly IMapper _mapper;
    private readonly IAttendantRepository _attendantRepository;

    public AttendantService(IMapper mapper, IAttendantRepository attendantRepository)
    {
        _mapper = mapper;
        _attendantRepository = attendantRepository;
    }
    
    public async Task<AttendantDto> GetByEmailAsync(string email)
    {
        var attendant = await _attendantRepository.GetByEmailAsync(email);
        if (attendant == null)
            throw new Exception("Attendant not found");
        
        var dto =  _mapper.Map<AttendantDto>(attendant);
        return dto;
    }

    public async Task<AttendantDto> GetByNameAsync(string name)
    {
        var attendant = await _attendantRepository.GetByNameAsync(name);
        if (attendant == null)
            throw new Exception("Attendant not found");
        
        var dto = _mapper.Map<AttendantDto>(attendant);
        return dto;
    }

    public async Task<AttendantDto> GetByCpfAsync(string cpf)
    {
        var attendant = await _attendantRepository.GetByCpfAsync(cpf);
        if (attendant == null)
            throw new Exception("Attendant not found");
        
        var dto = _mapper.Map<AttendantDto>(attendant);
        return dto;
    }

    public async Task<AttendantDto> CreateAttendantAsync(AttendantDto attendantDto)
    {
        var driver = await _attendantRepository.GetByEmailAsync(attendantDto.Email);
        if (driver == null)
        {
            var newAttendant = new Attendant(attendantDto.Name, 
                attendantDto.Cpf, 
                attendantDto.Email, 
                attendantDto.Phone, 
                attendantDto.Cep);
            
            await _attendantRepository.AddAsync(newAttendant);
            await _attendantRepository.SaveChangesAsync();
            
            return attendantDto;
        }
        
        throw new Exception("Attendant already exists");
    }

    public async Task<bool> DeleteAttendantAsync(Guid id)
    {
        var attendant = await _attendantRepository.GetByIdAsync(id);
        if (attendant == null)
            throw new("Attendant not exists");
        
        await  _attendantRepository.DeleteAsync(attendant);
        await _attendantRepository.SaveChangesAsync();
        
        return true;
    }
}