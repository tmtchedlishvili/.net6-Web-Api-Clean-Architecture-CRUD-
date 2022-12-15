using Domain.Entities;
using Domain.Entities.Main;
using FluentValidation;

namespace Application
{
    public class PersonEntityValidator : AbstractValidator<Person>
    {
        public PersonEntityValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("test");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("test");
        }

    }
}