using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Person;

public class UpdatePersonCommand : IRequest
{
    public int Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int CountryId { get; init; }
    public DateTime DateOfBirth { get; init; }
    public int Gender { get; init; }
    public string? IdNumber { get; init; }
}

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IApplicationDBContext _context;

    public UpdatePersonCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var personToUpdate =
            await _context.Persons.SingleAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        personToUpdate.FirstName = request.FirstName;
        personToUpdate.LastName = request.LastName;
        personToUpdate.Citizenship = _context.Countries.Single(c => c.Id == request.CountryId);
        personToUpdate.DateOfBirth = request.DateOfBirth;
        personToUpdate.Gender = request.Gender switch
        {
            0 => Domain.Entities.Main.Person.GenderEnum.Female,
            1 => Domain.Entities.Main.Person.GenderEnum.Male,
            2 => Domain.Entities.Main.Person.GenderEnum.Other,
            _ => throw new ArgumentOutOfRangeException()
        };
        personToUpdate.IdNumber = request.IdNumber;
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}