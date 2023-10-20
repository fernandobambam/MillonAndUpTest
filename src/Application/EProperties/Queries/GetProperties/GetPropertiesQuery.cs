using Application.Common.Interfaces;
using Application.EProperties.Queries.Dtos;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Application.EProperties.Queries.GetProperties
{
    public class GetPropertiesQuery : IRequestHandler<GetPropertiesRequest, PagedList<PropertyDto>>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;
        private readonly IMapper _mapper;
        private readonly FiltersOptions _paginationOptions;

        public GetPropertiesQuery(IMillonAndUpContext millonAndUpContext, IMapper mapper, IOptions<FiltersOptions> options)
        {
            _millonAndUpContext = millonAndUpContext;
            _mapper = mapper;
            _paginationOptions = options.Value;
        }

        public Task<PagedList<PropertyDto>> Handle(GetPropertiesRequest request, CancellationToken cancellationToken)
        {
            request.PageNumber = request.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : request.PageNumber;
            request.PageSize = request.PageSize == 0 ? _paginationOptions.DefaultPageSize : request.PageSize;

            IQueryable<Property> listProperties = _millonAndUpContext.Properties.AsQueryable();

            if(request.Name != null)
                listProperties = listProperties.Where(x => x.Name == request.Name); 

            if(request.Address != null)
                listProperties = listProperties.Where(x => x.Address == request.Address);

            if(request.Price != null)
                listProperties = listProperties.Where(x => x.Price == request.Price);

            if (request.Year != null)
                listProperties = listProperties.Where(x => x.Year == request.Year);

            if (request.IdOwner != null)
                listProperties = listProperties.Where(x => x.IdOwner == request.IdOwner);


            IEnumerable<PropertyDto> listPropertiesDto = _mapper.Map<IEnumerable<PropertyDto>>(listProperties.ToList());

            PagedList<PropertyDto>? pagedProperties = PagedList<PropertyDto>.Create(listPropertiesDto, request.PageNumber, request.PageSize);

            return Task.FromResult(pagedProperties);
        }
    }
}
