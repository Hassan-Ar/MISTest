using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features
{
    public class GetProductListInputDto
    {
        public ProductStatus? status { get; set; }
        public bool ProductAvailability { get; set; }
        public int? Price { get; set; }
        public AddressDto? Location { get; set; }

    }
}

/*
   public Task<(List<Building>, int count)> GetListAsync(
       string address, Status? status = null, int? price = null, int skipCount = 0, int maxResultCount = int.MaxValue, string sorting = null);
 
         public IQueryable<Building> ApplyFilter(IQueryable<Building> query, string address = null, Status? status = null, int? minPrice = null)
        {
            return query
                         .WhereIf(!string.IsNullOrEmpty(address), x => x.ProductAddress.Contains(address))
                         .WhereIf(status.HasValue, x => x.ProductStatus == status)
                         .WhereIf(minPrice.HasValue, x => x.Price >= minPrice)
                                ;
        }

        public async Task<(List<Building>, int count)> GetListAsync(string address, Status? status =null, int? price = null, int skipCount = 0, int maxResultCount =int.MaxValue, string sorting = null)
        {
            var query = ApplyFilter(await GetQueryableAsync(), address, status, price);
            var count = query.Count();
            return (query.PageBy(skipCount, maxResultCount).ToList(), count);
        }

  


 
 */