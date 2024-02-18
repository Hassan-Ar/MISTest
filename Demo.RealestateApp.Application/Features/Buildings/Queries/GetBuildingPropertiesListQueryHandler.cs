using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Queries
{
    public class GetBuildingPropertiesListQueryHandler : IRequestHandler<GetBuildingPropertiesListQuery, List<PropertiesBuildingDto>>
    {
        private readonly IPropertyRepository _PropertyRepository;
        private readonly IMapper _mapper;

        public GetBuildingPropertiesListQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _PropertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<List<PropertiesBuildingDto>> Handle(GetBuildingPropertiesListQuery request, CancellationToken cancellationToken)
        {
            var buildingproperties = (await _PropertyRepository.GetPropertiesByBuildingAsync(request.BuildingID)) ;
            if (buildingproperties is null)
            {
                // I have to change it
                throw new NotImplementedException();

            }
            var buildingpropertiesDto = _mapper.Map<List<PropertiesBuildingDto>>(buildingproperties) ;
            return buildingpropertiesDto ;
        }
    }
}
