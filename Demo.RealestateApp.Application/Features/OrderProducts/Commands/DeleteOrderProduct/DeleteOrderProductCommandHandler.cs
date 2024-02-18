using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Commands.DeleteOrderProduct
{
    public class DeleteOrderProductCommandHandler : IRequestHandler<DeleteOrderProductCommand, bool>
    {
        private readonly IAsyncBaseRepository<OrderProduct> _orderRepository;

        public DeleteOrderProductCommandHandler(IAsyncBaseRepository<OrderProduct> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(DeleteOrderProductCommand request, CancellationToken cancellationToken)
        {
                var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order != null)
            {
                var result = _orderRepository.DeleteAsync(order);
                return true;
            }
            return false;
        }
    }
}
