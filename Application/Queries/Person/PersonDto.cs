using Application.Mappings;
using AutoMapper;

namespace Application.Queries.Person;

public class PersonDto : IMapFrom<Domain.Entities.Main.Person>
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Domain.Entities.Main.Person.GenderEnum Gender { get; set; }
    public string? IdNumber { get; set; }
    public Domain.Entities.Main.Country? Citizenship { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Main.Person, PersonDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.IdNumber, opt => opt.MapFrom(src => src.IdNumber))
            .ForMember(dest => dest.Citizenship, opt => opt.MapFrom(src => src.Citizenship))
            .ReverseMap();
    }
}
