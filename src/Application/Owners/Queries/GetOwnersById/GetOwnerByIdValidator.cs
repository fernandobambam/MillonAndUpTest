using FluentValidation;

namespace Application.Owners.Queries.GetOwnersById
{
    public class GetOwnerByIdValidator : AbstractValidator<GetOwnerByIdRequest>
    {
        public GetOwnerByIdValidator()
        {
            RuleFor(x => x.IdOwner)
                .GreaterThan(0);
        }
    }
}
