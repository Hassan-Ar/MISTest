using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty;
using Demo.RealestateApp.Domain.Entities;
using Demo.RealestateApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.RealestateApp.Application.Features.Images;

namespace Demo.RealestateApp.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectCommandValidator(_projectRepository);
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


            var project = _mapper.Map<Project>(request);
            project.productType = ProductType.Project;
            project = await _projectRepository.AddAsync(project);

            return project.Id;
        }
    }
}
