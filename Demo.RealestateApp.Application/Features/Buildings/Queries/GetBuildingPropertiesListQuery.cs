using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Queries
{
    public class GetBuildingPropertiesListQuery : IRequest<List<PropertiesBuildingDto>>
    {
        public Guid BuildingID { get; set; }
    }
}
