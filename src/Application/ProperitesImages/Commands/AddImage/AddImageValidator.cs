using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.ProperitesImages.Commands.AddImage
{
    public class AddImageValidator : AbstractValidator<AddImageRequest>
    {
        public AddImageValidator()
        {
            RuleFor(x => x).Custom((model, context) =>
            {
                bool failed = false;

                if (FileIsEmpty(model.File))
                {
                    context.AddFailure("File is empty");
                    failed = true;
                }

                if (failed)
                    return;

                if (ValidateFileExtension(model.File))
                {
                    context.AddFailure("Invalid Format");
                    failed = true;
                }
            });
        }

        private bool FileIsEmpty(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return true;
            }

            return false;
        }

        private bool ValidateFileExtension(IFormFile file)
        {
            string[] allowedImageExtensions = { ".jpg", ".jpeg", ".png"};

            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedImageExtensions.Contains(fileExtension))
            {
                return true;
            }

            return false;
        }
    }
}
