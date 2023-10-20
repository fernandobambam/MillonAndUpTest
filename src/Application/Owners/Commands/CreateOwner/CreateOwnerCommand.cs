using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Owners.Commands.CreateOwner
{
    public class CreateOwnerCommand : IRequestHandler<CreateOwnerRequest, Unit>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;

        public CreateOwnerCommand(IMillonAndUpContext millonAndUpContext)
        {
            _millonAndUpContext = millonAndUpContext;
        }

        public async Task<Unit> Handle(CreateOwnerRequest request, CancellationToken cancellationToken)
        {
            Owner ownerEntity = new()
            {
                Name = request.Name,
                Address = request.Address,
                Photo = request.Photo,
                Birthday = Convert.ToDateTime(request.Birthday)
            };

            await _millonAndUpContext.Owners.AddAsync(ownerEntity);

            await _millonAndUpContext.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
