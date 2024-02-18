using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Projects.Queries;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Queries
{
    public class GetBuildingQueryHandler : IRequestHandler<GetBuildingQuery, BuildingDto>
    {
        private readonly IAsyncBaseRepository<Building> _buildingRepository;
        private readonly IAsyncBaseRepository<Project> _projectRepository;
        private readonly IPropertyRepository _PropertyRepository;
        private readonly IMapper _mapper;

        public GetBuildingQueryHandler(IAsyncBaseRepository<Building> buildingRepository, IAsyncBaseRepository<Project> projectRepository, IMapper mapper, IPropertyRepository propertyRepository)
        {
            _buildingRepository = buildingRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
            _PropertyRepository = propertyRepository;
        }

        public async Task<BuildingDto> Handle(GetBuildingQuery request, CancellationToken cancellationToken)
        {
            var Building = await _buildingRepository.GetByIdAsync(request.Id);
            var buildingDto = _mapper.Map<BuildingDto>(Building);
            //if (Building.ProjectId != Guid.Empty)
            //{
            //    var projectbuilding = await _projectRepository.GetByIdAsync(Building.ProjectId);
            //    var projectDto = _mapper.Map<ProjectDto>(projectbuilding);
            //    buildingDto.project = projectDto;
            //}

            //if (Building.ContainsProperties)
            //{
            //    var buildingProperties = (await _PropertyRepository.GetPropertiesByBuildingAsync(Building.Id)).ToList();
            //    var projectDto = _mapper.Map<List<PropertiesBuildingDto>>(buildingProperties);
            //    buildingDto.propeties = projectDto;
            //}

            return buildingDto;
            
        }
    }
}
