using Application.Mappings;
using AutoMapper;

namespace Application.Queries.Region;

public class RegionDto : IMapFrom<Domain.Entities.Main.Region>
{
    public int Id { get; private set; }
    public string? Name { get; private set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Main.Region, RegionDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ReverseMap();
    }
}