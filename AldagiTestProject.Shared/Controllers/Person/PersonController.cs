using Application.Commands.Person;
using Application.Common.Interfaces;
using Application.Queries.Person;
using Microsoft.AspNetCore.Mvc;

namespace AldagiTestProject.Shared.Controllers.Person;

public class PersonController : ApiControllerBase, IPersonDataRepository
{
 
    [HttpGet("GetPersons")]
    public async Task<ActionResult<IEnumerable<GetPersonsResponse>>> GetPersons()
    {
        var result = await Mediator.Send(new GetPersonsQuery());
        return Ok(result);
    }
    
    [HttpGet("GetPersonById{id:int}")]
    public async Task<ActionResult<GetPersonsResponse>> GetPersonById(int id)
    {
        var result = await Mediator.Send(new GetPersonByIdQuery {Id = id});

        return Ok(result);
    }
    
    
    [HttpPost("PostPerson")]
    public async Task<ActionResult<int>> Post(CreatePersonCommand command) => await Mediator.Send(command);
    
    
    [HttpPut("UpdatePerson{id:int}")]
    public async Task<ActionResult> Update(int id, UpdatePersonCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
    
    [HttpDelete("DeletePerson{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePersonCommand(id));
        return NoContent();
    }

}