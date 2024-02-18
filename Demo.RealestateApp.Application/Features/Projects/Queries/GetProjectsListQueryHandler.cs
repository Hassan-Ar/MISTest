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
    public class GetProjectsListQueryHandler : IRequestHandler<GetProjectsListQuery, List<ProjectDto>>
    {
        private readonly IProjectRepository _projectrepository;
        private readonly IAsyncBaseRepository<Building> _buildingrepository;
        private readonly IMapper _mapper;

        public GetProjectsListQueryHandler(IProjectRepository repository, IMapper mapper, IAsyncBaseRepository<Building> buildingrepository)
        {
            _projectrepository = repository;
            _mapper = mapper;
            _buildingrepository = buildingrepository;

        }

        public async Task<List<ProjectDto>> Handle(GetProjectsListQuery request, CancellationToken cancellationToken)
        {
            var projects = (await _projectrepository.GetProjectWithAddress());
            return _mapper.Map<List<ProjectDto>>(projects);
        }
    }
}
