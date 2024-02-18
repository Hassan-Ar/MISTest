using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Properties.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Queries.GetProjectsWithFilter
{
    public class GetProjectsWithFilterQueryHandler : IRequestHandler<GetProjectsWithFilterQuery, List<ProjectDto>>
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public GetProjectsWithFilterQueryHandler(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> Handle(GetProjectsWithFilterQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetListWithfilterAsync(request.Location, request.status, request.Price, request.ProductAvailability);
            var resultDto = _mapper.Map<List<ProjectDto>>(result);
            return resultDto;
        }
    }
}
