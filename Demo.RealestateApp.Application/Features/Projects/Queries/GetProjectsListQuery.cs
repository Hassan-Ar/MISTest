using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Queries
{
    public class GetProjectsListQuery : IRequest<List<ProjectDto>>
    {

    }
}
