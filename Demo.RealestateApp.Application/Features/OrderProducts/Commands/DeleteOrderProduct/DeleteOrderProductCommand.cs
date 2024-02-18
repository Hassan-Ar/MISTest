using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Commands.DeleteOrderProduct
{
    public class DeleteOrderProductCommand : IRequest<bool >
    {
        public Guid Id { get; set; }
    }
}
