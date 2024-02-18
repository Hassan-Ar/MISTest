using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Buildings.Commands.CreateBuilding;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.Properties.Commands.UpdateProperty;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand>
    {
        private readonly IBuildingRepository _Buildingrepository;
        private readonly IAsyncBaseRepository<Project> _projectRepository;
        private readonly IMapper _Mapper;

        public UpdateBuildingCommandHandler(IBuildingRepository buildingrepository, IMapper mapper, IAsyncBaseRepository<Project> projectRepository)
        {
            _Buildingrepository = buildingrepository;
            _Mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBuildingCommandValidator(_Buildingrepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            //Images Validation
            if (request.Images != null)
            {
                foreach (var image in request.Images)
                {
                    var validatorImage = new ValidateImageUpload();
                    var imageValidationResult = await validatorImage.ValidateAsync(image);
                    if (imageValidationResult.Errors.Count > 0)
                        throw new Exceptions.ValidationException(imageValidationResult);
                }
            }


            var building = await _Buildingrepository.GetByIdAsync(request.Id);
            _Mapper.Map(request, building, typeof(UpdateBuildingCommand), typeof(Building));



            if (request.ProjectId != Guid.Empty)
            {
                var project = await _projectRepository.GetByIdAsync(request.ProjectId);
                if (building is not null)
                {
                    building.project = project;
                }
            }
            await _Buildingrepository.UpdateAsync(building);

        }
    }
}
