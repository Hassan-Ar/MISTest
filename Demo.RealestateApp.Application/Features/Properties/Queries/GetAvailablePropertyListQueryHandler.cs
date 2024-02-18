using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Queries
{
    public class GetAvailablePropertyListQueryHandler : IRequestHandler<GetAvailablePropertyListQuery, List<PropertyDto>>
    {
        private readonly IPropertyRepository _propertyrepository;
        private readonly IMapper _mapper;

        public GetAvailablePropertyListQueryHandler(IPropertyRepository propertyrepository, IMapper mapper)
        {
            _propertyrepository = propertyrepository;
            _mapper = mapper;
        }

        public async Task<List<PropertyDto>> Handle(GetAvailablePropertyListQuery request, CancellationToken cancellationToken)
        {
            var result = await _propertyrepository.GetPropertiesByAvailablity(request.available);
            var propertiesDto = _mapper.Map<List<PropertyDto>>(result); 
            return propertiesDto;
        }
    }
}
