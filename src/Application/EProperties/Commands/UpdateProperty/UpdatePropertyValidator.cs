using FluentValidation;

namespace Application.EProperties.Commands.UpdateProperty
{
    public class UpdatePropertyValidator : AbstractValidator<UpdatePropertyRequest>
    {
        public UpdatePropertyValidator()
        {
            RuleFor(x => x.IdProperty)
                .NotNull()
                .GreaterThan(0);

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
