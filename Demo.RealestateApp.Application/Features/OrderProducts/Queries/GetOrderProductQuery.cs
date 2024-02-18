using MediatR;
using Demo.RealestateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Queries
{
    public class GetOrderProductQuery : IRequest<GetOrderProductDto>
    {
        public Guid Id { get; set; }
    }
}
