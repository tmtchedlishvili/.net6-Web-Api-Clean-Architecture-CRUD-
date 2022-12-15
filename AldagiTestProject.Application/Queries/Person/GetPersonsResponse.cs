using Application.Mappings;

namespace Application.Queries.Person;

public class GetPersonsResponse
{
    public IList<PersonDto> Persons { get; set; } = new List<PersonDto>();
}