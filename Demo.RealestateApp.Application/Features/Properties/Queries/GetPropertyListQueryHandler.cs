using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Queries
{
    public class GetPropertyListQueryHandler : IRequestHandler<GetPropertyListQuery, List<PropertyDto>>
    {
        private readonly IPropertyRepository _propertyrepository;
        private readonly IMapper _mapper;

        public GetPropertyListQueryHandler(IPropertyRepository propertyrepository, IMapper mapper)
        {
            _propertyrepository = propertyrepository;
            _mapper = mapper;
        }


        public async Task<List<PropertyDto>> Handle(GetPropertyListQuery request, CancellationToken cancellationToken)
        {
            var propertyList = await _propertyrepository.GetPropertiesWithAddressAsync() ;
            var propertyListDto = _mapper.Map<List<PropertyDto>>(propertyList) ;
            return propertyListDto ;
        }
    }
}
