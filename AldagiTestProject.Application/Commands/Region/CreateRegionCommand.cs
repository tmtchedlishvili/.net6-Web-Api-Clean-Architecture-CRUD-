using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Region;

public class CreateRegionCommand : IRequest<int>
{
    public string? Name { get; init; }
}

public class CreatePersonCommandHandler : IRequestHandler<CreateRegionCommand, int>
{
    private readonly IApplicationDBContext _context;
    
    public CreatePersonCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        var region = new Domain.Entities.Main.Region
        {
            Name = request.Name
        };

        _context.Regions.Add(region);
        await _context.SaveChangesAsync();
        return region.Id;
    }
}