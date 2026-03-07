using AutoMapper;
using backend.DTO;
using backend.Models;

namespace backend.Mappings
{
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
}