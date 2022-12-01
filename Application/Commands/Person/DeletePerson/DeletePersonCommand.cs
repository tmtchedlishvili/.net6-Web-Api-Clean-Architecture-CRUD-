using Application.Common.Interfaces;
using MediatR;

namespace Application.Commands.Person.DeletePerson;

public record DeletePersonCommand(int Id) : IRequest;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IApplicationDBContext _context;

    public DeletePersonCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var recordToDelete = _context.Persons.Single(p => p.Id == request.Id);
        _context.Persons.Remove(recordToDelete);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
