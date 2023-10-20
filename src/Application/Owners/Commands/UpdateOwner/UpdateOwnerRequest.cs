using MediatR;

namespace Application.Owners.Commands.UpdateOwner
{
    public class UpdateOwnerRequest : IRequest<Unit>
    {
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Birthday { get; set; }
    }
}
