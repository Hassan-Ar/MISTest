using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Queries
{
    public class GetBuildingQuery : IRequest<BuildingDto>
    {
        public Guid Id { get; set; }
    }
}
