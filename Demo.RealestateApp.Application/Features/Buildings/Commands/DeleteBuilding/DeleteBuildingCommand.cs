using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
