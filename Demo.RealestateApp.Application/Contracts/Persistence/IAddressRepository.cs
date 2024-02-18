using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Contracts.Persistence
{
    public interface IAddressRepository : IAsyncBaseRepository<Address>
    {
        Task<Address> GetProductAddressAsync(Guid productId);

    }
}
