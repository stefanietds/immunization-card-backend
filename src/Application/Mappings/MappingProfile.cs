using AutoMapper;
using backend.src.Application.DTOs;
using backend.src.Domain.Models;

namespace backend.src.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PatientDto, Patient>();
        CreateMap<VaccineDto, Vaccine>();
        CreateMap<CardDto, ImmunizationCard>()
            .ForMember(dest => dest.ApplicationDate, opt => opt.Ignore());
    }
}
