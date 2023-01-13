using Application.Mappings;
using Application.Queries.Region;
using AutoMapper;

namespace Application.Queries.Country;

public class CountryDto : IMapFrom<Domain.Entities.Main.Country>
{
    public int Id { get; private set; }
    public string? Name { get; private set; }
    public Domain.Entities.Main.Region? Region { get; private set; }
    public string? Code { get; private set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Main.Country, CountryDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ReverseMap();
    }
}