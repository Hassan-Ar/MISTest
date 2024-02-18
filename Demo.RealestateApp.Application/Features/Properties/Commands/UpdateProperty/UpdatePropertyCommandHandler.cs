using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty;
using Demo.RealestateApp.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Commands.UpdateProperty
{
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand>
    {

        private readonly IPropertyRepository _propertyrepository;
        private readonly IAsyncBaseRepository<Building> _buildingRepository;
        private readonly IMapper _mapper;

        public UpdatePropertyCommandHandler(IPropertyRepository propertyrepository, IMapper mapper, IAsyncBaseRepository<Building> buildingRepository)
        {
            _propertyrepository = propertyrepository;
            _mapper = mapper;
            _buildingRepository = buildingRepository;
        }

        public async Task Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdatePropertyCommandValidator(_propertyrepository);
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

            var property = await _propertyrepository.GetByIdAsync(request.Id);
             _mapper.Map(request , property,typeof(UpdatePropertyCommand),typeof(Property));

            if (request.BuildingId != Guid.Empty)
            {
                var building = await _buildingRepository.GetByIdAsync(request.BuildingId);
                if (building is not null)
                {
                    property.building = building;
                }
            }

            await _propertyrepository.UpdateAsync(property);
        }
    }
}
