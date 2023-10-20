using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.ProperitesImages.Commands.AddImage
{
    public class AddImageCommand : IRequestHandler<AddImageRequest, Unit>
    {
        private readonly IMillonAndUpContext _millonAndUpContext;

        public AddImageCommand(IMillonAndUpContext millonAndUpContext)
        {
            _millonAndUpContext = millonAndUpContext;
        }

        public async Task<Unit> Handle(AddImageRequest request, CancellationToken cancellationToken)
        {
            Property? property = _millonAndUpContext.Properties.Where(x => x.IdProperty == request.IdProperty)
                                                            .FirstOrDefault();

            if (property == null)
                throw new NotFoundException($"Property does not exist {request.IdProperty}");

            if(request.File != null && request.File.Length > 0)
            {
                PropertyImage propertyImageEntity = new PropertyImage
                {
                    IdProperty = request.IdProperty,
                    Enabled = true
                };

                using (var stream = new MemoryStream())
                {
                    request.File.CopyTo(stream);
                    propertyImageEntity.File = stream.ToArray();
                }

               await _millonAndUpContext.PropertiesImages.AddAsync(propertyImageEntity);
               await _millonAndUpContext.SaveChangesAsync(cancellationToken);

                return Unit.Value; 
            }

            return Unit.Value;
        }
    }
}
