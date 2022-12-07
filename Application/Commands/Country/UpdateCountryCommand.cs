using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Country;

public class UpdateCountryCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public int RegionId { get; init; }
    
}

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand>
{
    private readonly IApplicationDBContext _context;

    public UpdateCountryCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var countryToUpdate =
            await _context.Countries.SingleAsync(c=> c.Id == request.Id, cancellationToken: cancellationToken);
        countryToUpdate.Name = request.Name;
        countryToUpdate.Region = _context.Regions.Single(r => r.Id == request.RegionId);
        
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}