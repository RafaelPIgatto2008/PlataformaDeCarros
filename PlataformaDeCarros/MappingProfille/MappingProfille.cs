using AutoMapper;
using PlataformaDeCarros.DTOs;
using PlataformaDeCarros.Entities;

namespace PlataformaDeCarros.MappingProfille;

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