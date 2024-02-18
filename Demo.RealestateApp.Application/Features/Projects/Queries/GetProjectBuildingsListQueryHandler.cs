using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Queries
{
    public class GetProjectBuildingsListQueryHandler : IRequestHandler<GetProjectBuildingsListQuery, List<BuildingProjectDto>>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public GetProjectBuildingsListQueryHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<List<BuildingProjectDto>> Handle(GetProjectBuildingsListQuery request, CancellationToken cancellationToken)
        {
            var projectBuildings = (await _buildingRepository.GetBuildingsByProjectAsync(request.ProjectId));
            if(projectBuildings is not null)
            {
                
            }
            var projectBuildingsDto = _mapper.Map<List<BuildingProjectDto>>(projectBuildings);
            return projectBuildingsDto;
        }
    }
}
