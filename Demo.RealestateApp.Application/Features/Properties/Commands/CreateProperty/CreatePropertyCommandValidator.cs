using Demo.RealestateApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty
{
    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        private readonly IPropertyRepository _propertyRepository;
        public CreatePropertyCommandValidator(IPropertyRepository _propertyRepository)
        {
            this._propertyRepository = _propertyRepository;
            RuleFor(x => x.ProductTitle)
             .NotEmpty().WithMessage("{ProductTitle} is required.")
             .NotNull()
             .MinimumLength(4).WithMessage("{ProductTitle} must use more than 3 characters.")
             .MaximumLength(50).WithMessage("{ProductTitle} must not exceed 50 characters.");

            RuleFor(x => x)
               .MustAsync(PropertyNameUnique)
               .WithMessage("The property already exists");

            RuleFor(x => x.ProductDescription)
                 .NotEmpty().WithMessage("{ProductDescription} is required.")
                 .NotNull()
                 .MaximumLength(200).WithMessage("{ProductDescription} must not exceed 200 characters.");

            RuleFor(x => x.ProductPrice)
                .NotEmpty().WithMessage("{ProductPrice} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{ProductPrice} must be Greater Than 0 .");

            RuleFor(x => x.ProductSize)
                .NotEmpty().WithMessage("{ProductPrice} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{ProductPrice} must be Greater Than 0 .");

            RuleFor(x => x.Address.City)
            .NotEmpty().WithMessage("{City} is required.")
            .NotNull()
            .MinimumLength(4).WithMessage("{City} must use more than 3 characters.")
            .MaximumLength(50).WithMessage("{City} must not exceed 50 characters.");


            RuleFor(x => x.Address.Country)
            .NotEmpty().WithMessage("{Country} is required.")
            .NotNull()
            .MinimumLength(4).WithMessage("{Country} must use more than 3 characters.")
            .MaximumLength(50).WithMessage("{Country} must not exceed 50 characters.");

            RuleFor(x => x.Address.Street)
            .NotEmpty().WithMessage("{Street} is required.")
            .NotNull()
            .MinimumLength(4).WithMessage("{Street} must use more than 3 characters.")
            .MaximumLength(50).WithMessage("{Street} must not exceed 50 characters.");


        }
        private async Task<bool> PropertyNameUnique(CreatePropertyCommand x, CancellationToken token)
        {
            return !(await _propertyRepository.IsPropertyNameUnique(x.ProductTitle));
        }


    }
}
