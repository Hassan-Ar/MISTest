using Demo.RealestateApp.Application.Contracts.Persistence;
using Demo.RealestateApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {

        private readonly IAsyncBaseRepository<Project> _projectRepository;

        public DeleteProjectCommandHandler(IAsyncBaseRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            await _projectRepository.DeleteAsync(project);
        }
    }
}
