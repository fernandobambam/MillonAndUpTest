using MediatR;

namespace Application.Owners.Commands.DeleteOwner
{
    public class DeleteOwnerRequest : IRequest<Unit>
    {
        public int IdOwner { get; set; }
    }
}
