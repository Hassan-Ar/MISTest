using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Images
{
    public class ValidateImageUpload : AbstractValidator<ImageUploadRequestDto>
    {
        public ValidateImageUpload()
        {
            RuleFor(x => x)
                .Must(ValidateImageUploadExtensions).WithMessage("Incorrect File Extension");

            RuleFor(x => x)
                .Must(ValidateImageUploadLength).WithMessage("{FileLength} must not exceed 10000000 ");
        }

        public static bool ValidateImageUploadExtensions(ImageUploadRequestDto request)
        {
            var allowedExtensions = new List<string>() {".jpg",".jpej",".png" };
            if (allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                return true;
            }
            return false;
        }
        public bool ValidateImageUploadLength(ImageUploadRequestDto request)
        {
            if(request.File.Length > 10000000)
            {
                return false;
            }
            return true;
        }

    }
}
