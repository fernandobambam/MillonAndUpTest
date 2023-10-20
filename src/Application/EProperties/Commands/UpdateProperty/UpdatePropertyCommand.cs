using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.EProperties.Commands.UpdateProperty
{
    public class UpdatePropertyCommand : IRequestHandler<UpdatePropertyRequest, Unit>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;

        public UpdatePropertyCommand(IMillonAndUpContext millonAndUpContext)
        {
            _millonAndUpContext = millonAndUpContext;
        }


        public async Task<Unit> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {
            Property? propertyEntity = _millonAndUpContext.Properties.Where(x => x.IdProperty == request.IdProperty)
                                                            .FirstOrDefault();

            if (propertyEntity == null)
                throw new NotFoundException($"Property does not exist with Id = {request.IdProperty}");

            propertyEntity.Name = request.Name;
            propertyEntity.Address = request.Address;
            propertyEntity.Price = request.Price;
            propertyEntity.CodeInternal = request.CodeInternal;
            propertyEntity.Year = request.Year; 
            propertyEntity.IdOwner = request.IdOwner;

            _millonAndUpContext.Properties.Update(propertyEntity);

            await _millonAndUpContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
