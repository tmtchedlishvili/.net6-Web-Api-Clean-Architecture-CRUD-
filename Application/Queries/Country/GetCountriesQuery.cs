using AutoMapper;
using MediatR;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Country;

public class GetCountriesQuery : IRequest<GetCountriesResponse>
{
}

public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, GetCountriesResponse>
{
    private readonly IApplicationDBContext _context;
    private readonly IMapper _mapper;

    public GetCountriesQueryHandler(IApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetCountriesResponse> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries =  await _context.Countries
            .Include(c => c.Region)
            .ToListAsync(cancellationToken: cancellationToken);
        
        var result = new GetCountriesResponse();
        foreach (var mappedCountries in countries.Select(country => _mapper.Map<CountryDto>(country)))
            result.Countries.Add(mappedCountries);

        return result;
    }
}