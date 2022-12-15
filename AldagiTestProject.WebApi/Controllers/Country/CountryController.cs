using Application.Commands.Country;
using Application.Queries.Country;
using Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers.Country;

public class CountryController : ApiControllerBase
{
    private readonly ApplicationDbContext _context;

    public CountryController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetCountries")]
    public async Task<ActionResult<IEnumerable<GetCountriesResponse>>> GetCountries()
    {
        var result = await Mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
    
    [HttpGet("GetCountriesById{id:int}")]
    public async Task<ActionResult<GetCountriesResponse>> GetPersonById(int id)
    {
        var result = await Mediator.Send(new GetCountryByIdQuery() {Id = id});

        return Ok(result);
    }
    
    [HttpPost("PostCountry")]
    public async Task<ActionResult<int>> Post(CreateCountryCommand command) => await Mediator.Send(command);

    
    [HttpPut("UpdateCountry{id}")]
    public async Task<ActionResult> Update(int id, UpdateCountryCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
    
    [HttpDelete("DeleteCountry{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteCountryCommand(id));
        return NoContent();
    }

}