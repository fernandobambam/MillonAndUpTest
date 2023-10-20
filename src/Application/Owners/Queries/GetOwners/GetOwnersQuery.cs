using Application.Common.Interfaces;
using Application.Owners.Queries.Dtos;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.Owners.Queries.GetOwners
{
    public class GetOwnersQuery : IRequestHandler<GetOwnersRequest, PagedList<OwnerDto>>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;
        private readonly IMapper _mapper;
        private readonly FiltersOptions _paginationOptions;

        public GetOwnersQuery(IMillonAndUpContext millonAndUpContext, IMapper mapper, IOptions<FiltersOptions> options)
        {
            _millonAndUpContext = millonAndUpContext;
            _mapper = mapper;
            _paginationOptions = options.Value;
        }

        public Task<PagedList<OwnerDto>> Handle(GetOwnersRequest request, CancellationToken cancellationToken)
        {
            request.PageNumber = request.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : request.PageNumber;
            request.PageSize = request.PageSize == 0 ? _paginationOptions.DefaultPageSize : request.PageSize;

            IQueryable<Owner> listOwners = _millonAndUpContext.Owners.AsQueryable();

            IEnumerable<OwnerDto> listOwnersDto = _mapper.Map<IEnumerable<OwnerDto>>(listOwners.ToList());

            PagedList<OwnerDto>? pagedOwners = PagedList<OwnerDto>.Create(listOwnersDto, request.PageNumber, request.PageSize);

            return Task.FromResult(pagedOwners);
        }
    }
}
