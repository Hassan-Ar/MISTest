﻿using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Domain.Common;
using Demo.RealestateApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Persistence.Repositories
{
    public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        private readonly RealestateAppDbContext _dbContext;

        public BuildingRepository(RealestateAppDbContext context) : base(context)
        {
            this._dbContext = context;
        }

        public async Task<List<Building>> GetBuildingByAvailablity(bool availablity)
        {
            var result = await _dbContext.buildings.Where(x => x.ProductAvailability == availablity).Include(x => x.ProductAddress).ToListAsync();
            return result;
        }

        public async Task<List<Building>> GetBuildingsByProjectAsync(Guid projectID)
        {
            return await _dbContext.buildings.Where(x => x.ProjectId == projectID).ToListAsync();
        }

        public async Task<List<Building>> GetBuildingsWithProjectAndAddress()
        {
            var data =await _dbContext.buildings.ToListAsync();
            int count = await _dbContext.buildings.CountAsync();
            return await _dbContext.buildings.Include(x=>x.ProductAddress).Include(x=>x.project).ToListAsync();
        }

        public async Task<bool> IsBuildingNameUnique(string name)
        {
            return await _dbContext.properties.AnyAsync(x => x.ProductTitle == name);
        }

        public async Task<IQueryable<Building>> GetListWithfilterAsync(AddressDto? address, ProductStatus? status = null, double? price = null, bool avalability = true)
        {
            var result =  _dbContext.buildings.Where(x => x.ProductAvailability == avalability).Include(x => x.ProductAddress).AsQueryable();
            result = ApplyFilter(result, address, status, price);
            return result;
        }


        public IQueryable<Building> ApplyFilter(IQueryable<Building> query, AddressDto? address = null, ProductStatus? status = null, double? minPrice = null)
        {


            var result = WhereIf(query, status.HasValue, x => x.ProductStatus == status);
            result = WhereIf(result, minPrice.HasValue, x => x.ProductPrice >= minPrice);
            if (address is not null)
            {
                result = WhereIf(result, address.Country != string.Empty, x => x.ProductAddress.Country.Contains(address.Country));
                result = WhereIf(result, address.City != string.Empty, x => x.ProductAddress.City.Contains(address.City));
                result = WhereIf(result, address.Street != string.Empty, x => x.ProductAddress.Street.Contains(address.Street));
            }
            return result;
        }

        public IQueryable<T> WhereIf<T>(IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (!condition)
            {
                return query;
            }

            return query.Where(predicate);
        }

    }
}
