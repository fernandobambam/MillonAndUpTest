using MediatR;

namespace Application.EProperties.Commands.ChangePrice
{
    public class ChangePriceRequest : IRequest<Unit>
    {
        public int IdProperty { get; set; }
        public decimal Price { get; set; }
    }
}
