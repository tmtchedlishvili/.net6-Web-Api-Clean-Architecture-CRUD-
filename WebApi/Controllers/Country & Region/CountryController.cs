using Application.Commands.Country.CreateCountry;
using Application.Queries.Country;
using Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers.Country___Region;

[Route("[controller]")]
[ApiController]
public class CountryController : ApiControllerBase
{
    private readonly ApplicationDbContext _context;

    public CountryController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCountriesResponse>>> GetCountries()
    {
        var result = await Mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var country = await _context.Countries.SingleAsync(p=> p.Id == id);
        return Ok(country);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Post(CreateCountryCommand command) => await Mediator.Send(command);

}