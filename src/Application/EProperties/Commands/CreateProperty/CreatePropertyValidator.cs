using FluentValidation;

namespace Application.EProperties.Commands.CreateProperty
{
    public class CreatePropertyValidator : AbstractValidator<CreatePropertyRequest>
    {
        public CreatePropertyValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.Address)
                .NotNull()
                .MaximumLength(200);

            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
