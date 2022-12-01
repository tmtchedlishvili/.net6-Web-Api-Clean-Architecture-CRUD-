using Application.Queries.Region;
using Domain.Entities.Main;
using Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Country___Region;

[Route("[controller]")]
[ApiController]
public class RegionController : ApiControllerBase
{
    private readonly ApplicationDbContext _context;

    public RegionController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetRegions")]
    public async Task<ActionResult<IEnumerable<GetRegionsResponse>>> GetRegions()
    {
        var result = await Mediator.Send(new GetRegionsQuery());
        return Ok(result);
    }
    
    [HttpGet("GetRegionById{id:int}")]
    public async Task<ActionResult<GetRegionsResponse>> GetPersonById(int id)
    {
        var result = await Mediator.Send(new GetRegionByIdQuery {Id = id});

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Region region)
    {
        _context.Add(region);
        await _context.SaveChangesAsync();
        return Ok(region.Id);
    }
}