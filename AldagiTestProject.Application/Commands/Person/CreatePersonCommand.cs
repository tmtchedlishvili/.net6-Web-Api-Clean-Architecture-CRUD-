using Application.Common.Interfaces;
using MediatR;

namespace Application.Commands.Person;

public class CreatePersonCommand : IRequest<int>
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int CountryId { get; init; }
    public DateTime DateOfBirth { get; init; }
    public int Gender { get; init; }
    public string? IdNumber { get; init; }
    public string? Email { get; init; }
}

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IApplicationDBContext _context;
    
    public CreatePersonCommandHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Main.Person
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Citizenship = _context.Countries.Single(c => c.Id == request.CountryId),
            Gender = request.Gender switch
            {
                0 => Domain.Entities.Main.Person.GenderEnum.Female,
                1 => Domain.Entities.Main.Person.GenderEnum.Male,
                2 => Domain.Entities.Main.Person.GenderEnum.Other,
                _ => throw new ArgumentOutOfRangeException()
            },
            IdNumber = request.IdNumber,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email
            
        };
        
        _context.Persons.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}