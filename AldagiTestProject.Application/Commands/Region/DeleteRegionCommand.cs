using Application.Common.Interfaces;
using MediatR;

namespace Application.Commands.Region;

public record DeleteRegionCommand(int Id) : IRequest;

public class DeleteRegionCommandHandler : IRequestHandler<DeleteRegionCommand>
{
    private readonly IApplicationDBContext _context;

    public DeleteRegionCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
    {
        var recordToDelete = _context.Regions.Single(r => r.Id == request.Id);
        _context.Regions.Remove(recordToDelete);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}