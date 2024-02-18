using AutoMapper;
using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.Projects.Commands.CreateProject;
using Demo.RealestateApp.Application.Features.Properties.Commands.UpdateProperty;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProjectCommandValidator(_projectRepository);
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

            var project = await _projectRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, project, typeof(UpdateProjectCommand), typeof(Project));

            await _projectRepository.UpdateAsync(project);

        }
    }
}
