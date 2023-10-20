using FluentValidation;

namespace Application.EProperties.Commands.ChangePrice
{
    public class ChangePriceValidator : AbstractValidator<ChangePriceRequest>
    {
        public ChangePriceValidator()
        {
            RuleFor(x => x.Price)
               .NotNull()
               .GreaterThan(0);
        }
    }
}
