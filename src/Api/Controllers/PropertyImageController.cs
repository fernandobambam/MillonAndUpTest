using Application.ProperitesImages.Commands.AddImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertyImageController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddImage([FromQuery]AddImageRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }
    }
}
