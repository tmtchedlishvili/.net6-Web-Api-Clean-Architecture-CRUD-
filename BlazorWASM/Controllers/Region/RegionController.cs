// using AldagiTestProject.Application.Commands.Region;
// using AldagiTestProject.Application.Queries.Region;
// using Microsoft.AspNetCore.Mvc;
//
// namespace AldagiTestProject.WebApi.Controllers.Region;
//
// public class RegionController : ApiControllerBase
// {
//     [HttpGet("GetRegions")]
//     public async Task<ActionResult<IEnumerable<GetRegionsResponse>>> GetRegions()
//     {
//         var result = await Mediator.Send(new GetRegionsQuery());
//         return Ok(result);
//     }
//
//     [HttpGet("GetRegionById{id:int}")]
//     public async Task<ActionResult<GetRegionsResponse>> GetRegionById(int id)
//     {
//         var result = await Mediator.Send(new GetRegionByIdQuery { Id = id });
//
//         return Ok(result);
//     }
//
//     [HttpPost("PostRegion")]
//     public async Task<ActionResult<int>> Post(CreateRegionCommand command) => await Mediator.Send(command);
//     
//     [HttpPut("UpdateRegion{id:int}")]
//     public async Task<ActionResult> Update(int id, UpdateRegionCommand command)
//     {
//         if (id != command.Id)
//         {
//             return BadRequest();
//         }
//
//         await Mediator.Send(command);
//
//         return NoContent();
//     }
//     
//     [HttpDelete("DeleteRegion{id:int}")]
//     public async Task<ActionResult> Delete(int id)
//     {
//         await Mediator.Send(new DeleteRegionCommand(id));
//         return NoContent();
//     }
//
//
// }