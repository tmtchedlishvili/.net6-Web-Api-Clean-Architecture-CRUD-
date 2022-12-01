using AutoMapper;
using MediatR;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Region;

public class GetRegionsQuery : IRequest<GetRegionsResponse>
{
}

public class GetRegionsQueryHandler : IRequestHandler<GetRegionsQuery, GetRegionsResponse>
{
    private readonly IApplicationDBContext _context;
    private readonly IMapper _mapper;

    public GetRegionsQueryHandler(IApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetRegionsResponse> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        var regions =  await _context.Regions
            .ToListAsync(cancellationToken: cancellationToken);
        
        var result = new GetRegionsResponse();
        foreach (var mappedRegions in regions.Select(region => _mapper.Map<RegionDto>(region)))
            result.Regions.Add(mappedRegions);

        return result;
    }
}