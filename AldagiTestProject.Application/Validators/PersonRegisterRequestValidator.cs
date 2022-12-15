using Application.Commands.Person;
using FluentValidation;

namespace Application.Validators;

public class PersonRegisterRequestValidator : AbstractValidator<CreatePersonCommand>
{
    public PersonRegisterRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("Name must not be empty").MaximumLength(30).WithMessage("Invalid name");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email");
        // RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(30);
        // RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(30);
    }
}