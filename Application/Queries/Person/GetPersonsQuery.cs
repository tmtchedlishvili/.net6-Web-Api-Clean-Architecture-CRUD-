using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Person;

public class GetPersonsQuery : IRequest<GetPersonsResponse>
{
}

public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, GetPersonsResponse>
{
    private readonly IApplicationDBContext _context;
    private readonly IMapper _mapper;

    public GetPersonsQueryHandler(IApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetPersonsResponse> Handle(GetPersonsQuery request,
        CancellationToken cancellationToken)
    {
        var persons = await _context.Persons
            .Include(p => p.Citizenship)
            .Include(p => p.Citizenship!.Region)
            // .Include(p => p.DateOfBirth)
            .ToListAsync(cancellationToken: cancellationToken);

        var result = new GetPersonsResponse();
        foreach (var mappedPerson in persons.Select(person => _mapper.Map<PersonDto>(person))) result.Persons.Add(mappedPerson);

        return result;
    }
}