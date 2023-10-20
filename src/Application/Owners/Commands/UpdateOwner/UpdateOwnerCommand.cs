using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Owners.Commands.UpdateOwner
{
    public class UpdateOwnerCommand : IRequestHandler<UpdateOwnerRequest, Unit>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;

        public UpdateOwnerCommand(IMillonAndUpContext millonAndUpContext)
        {
            _millonAndUpContext = millonAndUpContext;
        }

        public async Task<Unit> Handle(UpdateOwnerRequest request, CancellationToken cancellationToken)
        {
            Owner? ownerEntity = _millonAndUpContext.Owners.Where(x => x.IdOwner == request.IdOwner)
                                                .FirstOrDefault();

            if (ownerEntity == null)
                throw new NotFoundException($"Owner does not exist with Id = {request.IdOwner}");

            ownerEntity.Name = request.Name;
            ownerEntity.Address = request.Address;
            ownerEntity.Photo = request.Photo;
            ownerEntity.Birthday = Convert.ToDateTime(request.Birthday);

            _millonAndUpContext.Owners.Update(ownerEntity);

            await _millonAndUpContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;  
        }
    }
}
