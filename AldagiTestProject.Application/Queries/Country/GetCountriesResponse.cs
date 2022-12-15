namespace Application.Queries.Country;

public class GetCountriesResponse
{
    public IList<CountryDto> Countries { get; set; } = new List<CountryDto>();
}