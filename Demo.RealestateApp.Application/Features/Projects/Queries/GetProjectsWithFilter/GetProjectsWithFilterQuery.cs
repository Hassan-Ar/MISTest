using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Queries.GetProjectsWithFilter
{
    public class GetProjectsWithFilterQuery : IRequest<List<ProjectDto>>
    {
        public ProductStatus? status { get; set; }
        public bool ProductAvailability { get; set; } = true;
        public double? Price { get; set; }
        public AddressDto? Location { get; set; }
    }
}
