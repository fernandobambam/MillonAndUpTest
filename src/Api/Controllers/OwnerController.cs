using Application.Owners.Commands.CreateOwner;
using Application.Owners.Commands.DeleteOwner;
using Application.Owners.Commands.UpdateOwner;
using Application.Owners.Queries.GetOwnersById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediator; 

        public OwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var producto = await _mediator.Send(new GetOwnerByIdRequest()
            {
                IdOwner = id
            });

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateOwnerRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateOwnerRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteOwnerRequest()
            {
                IdOwner = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
