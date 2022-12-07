// using Application.Commands.Person;
// using Application.Queries.Person;
// using Infrastructure.DB;
// using Microsoft.AspNetCore.Mvc;
//
// namespace WebApi.Controllers.Person;
//
// public class PersonController : ApiControllerBase
// {
//     private readonly ApplicationDbContext _context;
//
//     public PersonController(ApplicationDbContext context)
//     {
//         _context = context;
//     }
//     
//     [HttpGet("GetPersons")]
//     public async Task<ActionResult<IEnumerable<GetPersonsResponse>>> GetPersons()
//     {
//         var result = await Mediator.Send(new GetPersonsQuery());
//         return Ok(result);
//     }
//     
//     [HttpGet("GetPersonById{id:int}")]
//     public async Task<ActionResult<GetPersonsResponse>> GetPersonById(int id)
//     {
//         var result = await Mediator.Send(new GetPersonByIdQuery {Id = id});
//
//         return Ok(result);
//     }
//     
//     
//     [HttpPost("PostPerson")]
//     public async Task<ActionResult<int>> Post(CreatePersonCommand command) => await Mediator.Send(command);
//     
//     
//     [HttpPut("UpdatePerson{id}")]
//     public async Task<ActionResult> Update(int id, UpdatePersonCommand command)
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
//     [HttpDelete("DeletePerson{id}")]
//     public async Task<ActionResult> Delete(int id)
//     {
//         await Mediator.Send(new DeletePersonCommand(id));
//         return NoContent();
//     }
//
// }