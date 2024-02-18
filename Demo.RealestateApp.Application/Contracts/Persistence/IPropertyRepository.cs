using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Domain.Common;
using Demo.RealestateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Contracts.Persistence
{
    public interface IPropertyRepository : IAsyncBaseRepository<Property>
    {
        public Task<List<Property>> GetPropertiesByAvailablity(bool availablity);

        public Task<List<Property>> GetPropertiesByBuildingAsync(Guid buildingID);
        public Task<List<Property>> GetPropertiesWithAddressAsync();

        Task<bool> IsPropertyNameUnique(string name);

        public Task<IQueryable<Property>> GetListWithfilterAsync(
       AddressDto? address ,
       ProductStatus? status = null,
       double? price = null,
       bool avalability = true
            );

    }
}
