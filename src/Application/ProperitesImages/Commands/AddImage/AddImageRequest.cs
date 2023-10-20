using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Application.ProperitesImages.Commands.AddImage
{
    public class AddImageRequest : IRequest<Unit>
    {
        public int IdProperty { get; set; }

        public IFormFile File { get; set; }
    }
}
