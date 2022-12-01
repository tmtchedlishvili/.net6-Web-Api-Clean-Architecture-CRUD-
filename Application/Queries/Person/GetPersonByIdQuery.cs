using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Person;

public class GetPersonByIdQuery : IRequest<GetPersonsResponse>
{
    public int Id { get; init; }
}


public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, GetPersonsResponse>
{
    private readonly IApplicationDBContext _context;
    private readonly IMapper _mapper;

    public GetPersonByIdQueryHandler(IApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<GetPersonsResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await _context.Persons.Include(p => p.Citizenship)
            .Include(p=> p.Citizenship!.Region)
            .SingleAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        var mappedPerson = _mapper.Map<PersonDto>(person);
        var result = new GetPersonsResponse();
        result.Persons.Add(mappedPerson);
        return result;
    }
}