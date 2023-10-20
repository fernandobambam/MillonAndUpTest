using Application.Common.Interfaces;
using Application.Owners.Queries.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Owners.Queries.GetOwnersById
{
    public class GetOwnerByIdQuery : IRequestHandler<GetOwnerByIdRequest, OwnerDto>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;
        private readonly IMapper _mapper;

        public GetOwnerByIdQuery(IMillonAndUpContext millonAndUpContext, IMapper mapper)
        {
            _millonAndUpContext = millonAndUpContext;
            _mapper = mapper;
        }

        public Task<OwnerDto> Handle(GetOwnerByIdRequest request, CancellationToken cancellationToken)
        {
            Owner? ownerEntity = _millonAndUpContext.Owners.Where(x => x.IdOwner == request.IdOwner)
                                            .FirstOrDefault();

            if (ownerEntity == null)
                throw new NotFoundException($"Owner does not exist with Id = {request.IdOwner}");

            OwnerDto ownerDto = _mapper.Map<OwnerDto>(ownerEntity);

            return Task.FromResult(ownerDto);
        }
    }
}
