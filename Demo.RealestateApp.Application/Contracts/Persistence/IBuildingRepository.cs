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
    public interface IBuildingRepository : IAsyncBaseRepository<Building>
    {
        public Task<List<Building>> GetBuildingByAvailablity(bool availablity);

        public Task<List<Building>> GetBuildingsByProjectAsync(Guid projectID);
        Task<bool> IsBuildingNameUnique(string name);
        Task<List<Building>> GetBuildingsWithProjectAndAddress();

        public Task<IQueryable<Building>> GetListWithfilterAsync(
          AddressDto? address,
          ProductStatus? status = null,
          double? price = null,
           bool avalability = true  );


    }
}
