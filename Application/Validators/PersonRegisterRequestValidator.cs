using Application.Commands.Person;
using FluentValidation;

namespace Application.Validators;

public class PersonRegisterRequestValidator : AbstractValidator<CreatePersonCommand>
{
    public PersonRegisterRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().NotNull().Length(50);
    }
}