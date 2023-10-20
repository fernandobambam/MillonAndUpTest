using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.EProperties.Commands.ChangePrice
{
    public class ChangePriceCommand : IRequestHandler<ChangePriceRequest, Unit>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;

        public ChangePriceCommand(IMillonAndUpContext millonAndUpContext)
        {
            _millonAndUpContext = millonAndUpContext;
        }

        public async Task<Unit> Handle(ChangePriceRequest request, CancellationToken cancellationToken)
        {
            Property? property = _millonAndUpContext.Properties.Where(x => x.IdProperty == request.IdProperty)
                                                                        .FirstOrDefault();  

            if (property == null)
                throw new NotFoundException($"Property does not exist {request.IdProperty}");

            property.Price = request.Price;

            _millonAndUpContext.Properties.Update(property);

            await _millonAndUpContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
