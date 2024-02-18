using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Queries
{
    public class GetAvailablePropertyListQuery : IRequest<List<PropertyDto>>
    {
        public bool available { get; set; }

    }
}
