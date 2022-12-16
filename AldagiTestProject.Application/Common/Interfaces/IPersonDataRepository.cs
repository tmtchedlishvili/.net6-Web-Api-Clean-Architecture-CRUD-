using Application.Commands.Person;
using Application.Queries.Person;
using Microsoft.AspNetCore.Mvc;

namespace Application.Common.Interfaces;

public interface IPersonDataRepository
{
    Task<ActionResult<IEnumerable<GetPersonsResponse>>> GetPersons();
    Task<ActionResult<GetPersonsResponse>> GetPersonById(int id);
    Task<ActionResult<int>> Post(CreatePersonCommand command);
    Task<ActionResult> Update(int id, UpdatePersonCommand command);
    Task<ActionResult> Delete(int id);

}