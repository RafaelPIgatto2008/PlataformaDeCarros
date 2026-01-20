using AutoMapper;
using Plataform.Application.DTOs;
using Plataform.Domain.Entities;

namespace Plataform.Application.MappingProfille;

public class MappingProfille : Profile
{
    public MappingProfille()
    {
        // Driver mapping
        CreateMap<Driver, DriverDto>();
        
        // Car mapping
        CreateMap<Car, CarDto>();
        
        // Attendant mapping
        CreateMap<Attendant, AttendantDto>();
    }
}