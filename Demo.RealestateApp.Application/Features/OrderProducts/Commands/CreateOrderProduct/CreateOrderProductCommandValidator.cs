using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductCommandValidator : AbstractValidator<CreateOrderProductCommand>
    {
        private readonly IOrderProductRepository _orderProductRepository;
        public CreateOrderProductCommandValidator(IOrderProductRepository _orderProductRepository)
        {
            this._orderProductRepository = _orderProductRepository;

            RuleFor(x => x.UserName)
             .NotEmpty().WithMessage("{UserName} is required.")
             .NotNull()
             .MinimumLength(4).WithMessage("{UserName} must use more than 3 characters.")
             .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

            RuleFor(x => x.UserEmail)
            .NotEmpty().WithMessage("{UserEmail} is required.")
            .NotNull()
            .MinimumLength(4).WithMessage("{UserEmail} must use more than 3 characters.")
            .MaximumLength(50).WithMessage("{UserEmail} must not exceed 50 characters.");

            RuleFor(x => x)
               .MustAsync(OrderProductUnique)
               .WithMessage("The order was sent successfully");
        }
        private async Task<bool> OrderProductUnique(CreateOrderProductCommand x, CancellationToken token)
        {
            return !(await _orderProductRepository.IsOrderProductUnique(x.UserId,x.ProductId));
        }

    }
}
