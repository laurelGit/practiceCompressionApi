using App.Models;
using AutoMapper;

namespace PracticeDotnetWebApiCompression.Helper;

public class PersonProfile : Profile
{
    public PersonProfile(){
        CreateMap<String, Person>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src)
            );
    }
}