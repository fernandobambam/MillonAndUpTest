using Application.EProperties.Queries.Dtos;
using Domain.Common;
using MediatR;

namespace Application.EProperties.Queries.GetProperties
{
    public class GetPropertiesRequest : IRequest<PagedList<PropertyDto>>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public string? CodeInternal { get; set; }
        public int? Year { get; set; }
        public int? IdOwner { get; set; }


        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
