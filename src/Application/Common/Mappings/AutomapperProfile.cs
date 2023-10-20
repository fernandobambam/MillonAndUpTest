using Application.EProperties.Queries.Dtos;
using Application.Owners.Queries.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();

            CreateMap<Property, PropertyDto>();
            CreateMap<PropertyDto, Property>(); 
        }
    }
}
