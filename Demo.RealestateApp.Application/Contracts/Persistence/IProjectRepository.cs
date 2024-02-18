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
    public interface IProjectRepository : IAsyncBaseRepository<Project>
    {
        public Task<List<Project>> GetProjectByAvailablity(bool availablity);

        Task<bool> IsProjectNameUnique(string name);
        public  Task<List<Project>> GetProjectWithAddress();
        public Task<IQueryable<Project>> GetListWithfilterAsync(
         AddressDto? address,
         ProductStatus? status = null,
         double? price = null,
          bool avalability = true);

    }
}
