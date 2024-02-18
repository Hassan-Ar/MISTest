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
    public class GetBuildingListQueryHandler : IRequestHandler<GetBuildingListQuery, List<BuildingDto>>
    {
        private readonly IBuildingRepository _Buildingrepository;
        private readonly IMapper _Mapper;

        public GetBuildingListQueryHandler(IBuildingRepository buildingrepository,  IMapper mapper)
        {
            _Buildingrepository = buildingrepository;
            _Mapper = mapper;
        }

        public async Task<List<BuildingDto>> Handle(GetBuildingListQuery request, CancellationToken cancellationToken)
        {


            var Building = await _Buildingrepository.GetBuildingsWithProjectAndAddress();
            return _Mapper.Map<List<BuildingDto>>(Building);



        }
    }
}
