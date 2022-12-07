using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Country;

public class GetCountryByIdQuery : IRequest<GetCountriesResponse>
{
    public int Id { get; init; }
}

public class GetCountriesByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, GetCountriesResponse>
{
    private readonly IApplicationDBContext _context;
    private readonly IMapper _mapper;

    public GetCountriesByIdQueryHandler(IApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetCountriesResponse> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var country = await _context.Countries
            .Include(c=> c.Region)
            .SingleAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        var mappedCountry = _mapper.Map<CountryDto>(country);
        var result = new GetCountriesResponse();
        result.Countries.Add(mappedCountry);
        return result;
    }
}