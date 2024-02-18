using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Queries
{
    public class GetProjectQuery : IRequest<ProjectDto>
    {
        public Guid Id { get; set; }
    }
}
