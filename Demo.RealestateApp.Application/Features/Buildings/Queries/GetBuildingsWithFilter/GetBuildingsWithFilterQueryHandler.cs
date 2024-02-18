using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Properties.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Queries.GetBuildingsWithFilter
{
    public class GetBuildingsWithFilterQueryHandler : IRequestHandler<GetBuildingsWithFilterQuery, List<BuildingDto>>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public GetBuildingsWithFilterQueryHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<List<BuildingDto>> Handle(GetBuildingsWithFilterQuery request, CancellationToken cancellationToken)
        {
            var result = await _buildingRepository.GetListWithfilterAsync(request.Location, request.status, request.Price, request.ProductAvailability);
            var resultDto = _mapper.Map<List<BuildingDto>>(result);
            return resultDto;
        }
    }
}
