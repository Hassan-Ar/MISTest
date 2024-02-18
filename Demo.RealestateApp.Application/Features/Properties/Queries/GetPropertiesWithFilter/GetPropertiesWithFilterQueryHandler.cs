using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Queries.GetPropertiesWithFilter
{
    public class GetPropertiesWithFilterQueryHandler : IRequestHandler<GetPropertiesWithFilterQuery, List<PropertyDto>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetPropertiesWithFilterQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<List<PropertyDto>> Handle(GetPropertiesWithFilterQuery request, CancellationToken cancellationToken)
        {
            var result = await _propertyRepository.GetListWithfilterAsync(request.Location, request.status, request.Price, request.ProductAvailability);
            var resultDto = _mapper.Map<List<PropertyDto>>(result);
            return resultDto;
        }
    }
}
