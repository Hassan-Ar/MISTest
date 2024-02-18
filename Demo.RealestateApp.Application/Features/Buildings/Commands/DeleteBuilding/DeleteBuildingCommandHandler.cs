using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand>
    {
        private readonly IAsyncBaseRepository<Building> _Buildingrepository;

        public DeleteBuildingCommandHandler(IAsyncBaseRepository<Building> buildingrepository)
        {
            _Buildingrepository = buildingrepository;
        }

        public async Task Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _Buildingrepository.GetByIdAsync(request.Id);
            await _Buildingrepository.DeleteAsync(building);
        }
    }
}
