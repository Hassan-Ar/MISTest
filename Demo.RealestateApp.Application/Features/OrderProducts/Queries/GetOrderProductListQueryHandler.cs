using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.OrderProducts.Queries
{
    public class GetOrderProductListQueryHandler : IRequestHandler<GetOrderProductListQuery, List<GetOrderProductDto>>
    {
        private readonly IOrderProductRepository _orederProductRepository;
        private readonly IMapper _mapper;

        public GetOrderProductListQueryHandler(IOrderProductRepository orederProductRepository, IMapper mapper)
        {
            _orederProductRepository = orederProductRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderProductDto>> Handle(GetOrderProductListQuery request, CancellationToken cancellationToken)
        {
   
                var result = await _orederProductRepository.ListAllAsync();
                var resultDto = _mapper.Map<List<GetOrderProductDto>>(result);
                return resultDto;
        }
    }
}
