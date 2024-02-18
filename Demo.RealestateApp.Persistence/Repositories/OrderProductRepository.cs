using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Persistence.Repositories
{
    public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepository
    {
        private readonly RealestateAppDbContext _context;

        public OrderProductRepository(RealestateAppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<OrderProduct>> GetAcceptedOredersOrNotAccepted(bool accepte)
        {
            var result = await _context.orderProducts.Where(x=>x.AcceptOrder==accepte).ToListAsync();
            return result;

        }

        public  Task<bool> IsOrderProductUnique(Guid userId, Guid productId)
        {
            var result =   _context.orderProducts.Where(x => x.UserId == userId && x.ProductId==productId).Any();
            return Task.FromResult(result);        
        }
    }
}
