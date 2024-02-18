using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Queries
{
    public class GetProjectBuildingsListQuery : IRequest<List<BuildingProjectDto>>
    {
        public Guid ProjectId { get; set; }
    }
}
