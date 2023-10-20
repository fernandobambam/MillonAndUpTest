using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.EProperties.Commands.CreateProperty
{
    public class CreatePropertyCommand : IRequestHandler<CreatePropertyRequest, Unit>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;

        public CreatePropertyCommand(IMillonAndUpContext millonAndUpContext)
        {
            _millonAndUpContext = millonAndUpContext;
        }

        public async Task<Unit> Handle(CreatePropertyRequest request, CancellationToken cancellationToken)
        {
            if(request.IdOwner != null)
            {
                Owner? ownerEntity = _millonAndUpContext.Owners.Where(x => x.IdOwner == request.IdOwner)
                                                .FirstOrDefault();

                if (ownerEntity == null)
                    throw new NotFoundException($"Owner does not exist with Id = {request.IdOwner}");
            }

            Property propertyEntity = new()
            {
                Name = request.Name,
                Address = request.Address,
                Price = request.Price,
                CodeInternal = request.CodeInternal,
                Year = request.Year,
                IdOwner = request.IdOwner
            };

            await _millonAndUpContext.Properties.AddAsync(propertyEntity);

            await _millonAndUpContext.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
