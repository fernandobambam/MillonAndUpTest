using Application.Owners.Queries.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Owners.Queries.GetOwners
{
    public class GetOwnersRequest : IRequest<PagedList<OwnerDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
