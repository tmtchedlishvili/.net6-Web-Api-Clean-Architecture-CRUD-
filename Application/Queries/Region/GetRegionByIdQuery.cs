using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Region;

public class GetRegionByIdQuery : IRequest<GetRegionsResponse>
{
    public int Id { get; init; }
}

public class GetRegionsByIdQueryHandler : IRequestHandler<GetRegionByIdQuery, GetRegionsResponse>
{
    private readonly IApplicationDBContext _context;
    private readonly IMapper _mapper;

    public GetRegionsByIdQueryHandler(IApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetRegionsResponse> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
    {
        var region = await _context.Regions
            .SingleAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        var mappedRegion = _mapper.Map<RegionDto>(region);
        var result = new GetRegionsResponse();
        result.Regions.Add(mappedRegion
        );
        return result;
    }
}