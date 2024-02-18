using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Queries
{
    public class GetPropertyQueryHandler : IRequestHandler<GetPropertyQuery, PropertyDto>
    {
        private readonly IAsyncBaseRepository<Property> _propertyrepository;
        private readonly IAsyncBaseRepository<Building> _buildingrepository;
        private readonly IMapper _mapper;

        public GetPropertyQueryHandler(IAsyncBaseRepository<Property> propertyrepository, IAsyncBaseRepository<Building> buildingrepository, IMapper mapper)
        {
            _propertyrepository = propertyrepository;
            _buildingrepository = buildingrepository;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(GetPropertyQuery request, CancellationToken cancellationToken)
        {
            var property = await _propertyrepository.GetByIdAsync(request.Id);

            var propertyDto = _mapper.Map<PropertyDto>(property);

            //if (property.BuildingId != Guid.Empty)
            //{
            //    var propertybuilding = await _buildingrepository.GetByIdAsync(property.BuildingId);
            //    var BuildingDto = _mapper.Map<BuildingDto>(propertybuilding);
            //    propertyDto.building = BuildingDto;
            //}

            return propertyDto; 
        }
    }
}
