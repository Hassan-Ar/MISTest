using Demo.RealestateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Contracts.Persistence
{
    public interface IOrderProductRepository : IAsyncBaseRepository<OrderProduct>
    {
        public Task<List<OrderProduct>> GetAcceptedOredersOrNotAccepted(bool accepte);
        Task<bool> IsOrderProductUnique(Guid userId, Guid productId);
    }
}
