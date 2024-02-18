using Demo.RealestateApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductCommand : IRequest<bool>
    {
        public bool AcceptOrder { get; set; } = false;
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Guid ProductId { get; set; }
        public double productPrice { get; set; }
        public ProductType productType { get; set; } = ProductType.Unknown;
        public ProductStatus productStatus { get; set; } = ProductStatus.Unknown;
    }
}
