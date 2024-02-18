using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Queries
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private readonly IAsyncBaseRepository<Project> _projectrepository;
        private readonly IBuildingRepository _buildingrepository;
        private readonly IMapper _mapper;

        public GetProjectQueryHandler(IAsyncBaseRepository<Project> projectrepository
            , IBuildingRepository buildingrepository
            , IMapper mapper
            )
        {
            _projectrepository = projectrepository;
            _buildingrepository = buildingrepository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectrepository.GetByIdAsync(request.Id);

            var projectDto = _mapper.Map<ProjectDto>(project);

            //if (project.ContainsBuildings)
            //{
            //    var buildings = (await _buildingrepository.GetBuildingsByProjectAsync(request.Id)).ToList();
            //    var buildingsDto = _mapper.Map<List<BuildingProjectDto>>(buildings);
            //    projectDto.Buildings = buildingsDto;
            //}

            return projectDto;
        }
    }
}
