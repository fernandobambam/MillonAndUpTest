using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Owners.Commands.DeleteOwner
{
    public class DeleteOwnerCommand : IRequestHandler<DeleteOwnerRequest, Unit>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;

        public DeleteOwnerCommand(IMillonAndUpContext millonAndUpContext)
        {
            _millonAndUpContext = millonAndUpContext;
        }

        public async Task<Unit> Handle(DeleteOwnerRequest request, CancellationToken cancellationToken)
        {
            Owner? ownerEntity = await _millonAndUpContext.Owners.FindAsync(request.IdOwner);

            if(ownerEntity == null)
                throw new NotFoundException($"Owner does not exist with Id = {request.IdOwner}");

            _millonAndUpContext.Owners.Remove(ownerEntity);

            await _millonAndUpContext.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
