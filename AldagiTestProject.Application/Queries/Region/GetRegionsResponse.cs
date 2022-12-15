namespace Application.Queries.Region;

public class GetRegionsResponse
{
    public IList<RegionDto> Regions { get; set; } = new List<RegionDto>();
}