using Api.Responses;
using Application.Common.Interfaces;
using Application.EProperties.Commands.ChangePrice;
using Application.EProperties.Commands.CreateProperty;
using Application.EProperties.Commands.UpdateProperty;
using Application.EProperties.Queries.Dtos;
using Application.EProperties.Queries.GetProperties;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;

        public PropertyController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> Get([FromQuery] GetPropertiesRequest request)
        {
            PagedList<PropertyDto> propertiesDto = await _mediator.Send(request);

            Metadata metadata = new()
            {
                TotalCount = propertiesDto.TotalCount,
                PageSize = propertiesDto.PageSize,
                CurrentPage = propertiesDto.CurrentPage,
                TotalPages = propertiesDto.TotalPages,
                HasNextPage = propertiesDto.HasNextPage,
                HasPreviousPage = propertiesDto.HasPreviousPage,
                NextPageUrl = propertiesDto.HasNextPage ? _uriService.GetAllEntities(request.PageSize, request.PageNumber + 1, Url.RouteUrl(nameof(Get))).ToString() : string.Empty,
                PreviousPageUrl = propertiesDto.HasPreviousPage ? _uriService.GetAllEntities(request.PageSize, request.PageNumber - 1, Url.RouteUrl(nameof(Get))).ToString() : string.Empty
            };

            ApiResponse<PagedList<PropertyDto>> response = new(propertiesDto)
            {
                Meta = metadata
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreatePropertyRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdatePropertyRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpPut("ChangePrice")]
        public async Task<ActionResult> ChangePrice(ChangePriceRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }
    }
}
