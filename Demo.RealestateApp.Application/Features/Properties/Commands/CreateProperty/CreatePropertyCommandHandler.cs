using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Infrastructuer;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Mail;
using Demo.RealestateApp.Domain.Common;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Guid>
    {

        private readonly IPropertyRepository _propertyrepository;
        private readonly IAsyncBaseRepository<Building> _buildingRepository;
        private readonly IMapper _mapper;
        private readonly ICreateAddressCommand _createAddressCommand;

        public CreatePropertyCommandHandler(IPropertyRepository propertyrepository, IMapper mapper, ICreateAddressCommand createAddressCommand, IAsyncBaseRepository<Building> buildingRepository)
        {

            _mapper = mapper;
            _propertyrepository = propertyrepository;
            _createAddressCommand = createAddressCommand;
            _buildingRepository = buildingRepository;
        }

        public async Task<Guid> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            //Property Validation
            var validator = new CreatePropertyCommandValidator(_propertyrepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            //Images Validation
            if (request.ImagesPath !=null)
            {
                foreach (var image in request.ImagesPath)
                {
                    var validatorImage = new ValidateImageUpload();
                    var imageValidationResult = await validatorImage.ValidateAsync(image);
                    if (imageValidationResult.Errors.Count > 0)
                        throw new Exceptions.ValidationException(imageValidationResult);
                }
            }

            var property = _mapper.Map<Property>(request);
            property.productType = ProductType.Property;

            //Adding property to building Property List
            if (request.buildingId != Guid.Empty)
            {
                var building = await _buildingRepository.GetByIdAsync(request.buildingId);
                if(building is not null)
                {
                    property.building = building;
                }
            }

            property = await _propertyrepository.AddAsync(property);

         

            return property.Id;
        }
    }
}
