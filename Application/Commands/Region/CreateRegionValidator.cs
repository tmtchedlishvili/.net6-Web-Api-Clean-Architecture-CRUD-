using FluentValidation;

namespace Application.Commands.Region;

public class CreateRegionValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionValidator()
    {
        RuleFor(r => r.Name)
            .NotNull()
            .NotEmpty().WithMessage("Are you kidding me?😒");
    }
}