using MediatR;

namespace Application.Owners.Commands.CreateOwner
{
    public class CreateOwnerRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Birthday { get; set; }
    }
}
