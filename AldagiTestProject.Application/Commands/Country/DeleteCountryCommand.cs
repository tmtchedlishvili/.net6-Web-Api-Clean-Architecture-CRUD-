using Application.Common.Interfaces;
using MediatR;

namespace Application.Commands.Country;

public record DeleteCountryCommand(int Id) : IRequest;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand>
{
    private readonly IApplicationDBContext _context;

    public DeleteCountryCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var recordToDelete = _context.Countries.Single(p => p.Id == request.Id);
        _context.Countries.Remove(recordToDelete);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}