using MediatR;
using Demo.RealestateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.RealestateApp.Application.Contracts.Persistence;
using AutoMapper;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Queries
{
    public class GetOrderProductQueryHandler : IRequestHandler<GetOrderProductQuery, GetOrderProductDto>
    {
        private readonly IOrderProductRepository _orederProductRepository;
        private readonly IAsyncBaseRepository<Building> _buildingRepository;
        private readonly IAsyncBaseRepository<Property> _PropertyRepository;
        private readonly IAsyncBaseRepository<Project> _ProjectRepository;
        private readonly IMapper _mapper;

        public GetOrderProductQueryHandler(IOrderProductRepository orederProductRepository,
            IAsyncBaseRepository<Building> buildingRepository,
            IAsyncBaseRepository<Property> propertyRepository,
            IAsyncBaseRepository<Project> projectRepository,
            IMapper mapper)
        {
            _orederProductRepository = orederProductRepository;
            _buildingRepository = buildingRepository;
            _PropertyRepository = propertyRepository;
            _ProjectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderProductDto> Handle(GetOrderProductQuery request, CancellationToken cancellationToken)
        {
            var order = await _orederProductRepository.GetByIdAsync(request.Id);
            var orderDto = _mapper.Map<GetOrderProductDto>(order);
            return orderDto;
        }
    }
}
