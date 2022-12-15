using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Region;

public class UpdateRegionCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    
}

public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand>
{
    private readonly IApplicationDBContext _context;

    public UpdateRegionCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
    {
        var regionToUpdate =
            await _context.Regions.SingleAsync(c=> c.Id == request.Id, cancellationToken: cancellationToken);
        regionToUpdate.Name = request.Name;
        
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}