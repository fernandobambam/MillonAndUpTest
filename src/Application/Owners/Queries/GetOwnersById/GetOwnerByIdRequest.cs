using Application.Owners.Queries.Dtos;
using MediatR;

namespace Application.Owners.Queries.GetOwnersById
{
    public class GetOwnerByIdRequest : IRequest<OwnerDto>
    {
        public int IdOwner { get; set; }
    }
}
