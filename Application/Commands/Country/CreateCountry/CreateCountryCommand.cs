using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Country.CreateCountry;

public class CreateCountryCommand : IRequest<int>
{
    public string? Name { get; init; }
    public int RegionId { get; init; }
}

public class CreatePersonCommandHandler : IRequestHandler<CreateCountryCommand, int>
{
    private readonly IApplicationDBContext _context;
    
    public CreatePersonCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Domain.Entities.Main.Country
        {
            Name = request.Name,
            Region = await _context.Regions.SingleAsync(r => r.Id == request.RegionId)
        };

        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
        return country.Id;
    }
}