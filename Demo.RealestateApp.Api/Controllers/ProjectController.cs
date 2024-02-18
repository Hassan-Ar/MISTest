using Demo.RealestateApp.Application.Features.Buildings.Queries.GetBuildingsWithFilter;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Application.Features.Projects.Commands.CreateProject;
using Demo.RealestateApp.Application.Features.Projects.Commands.DeleteProject;
using Demo.RealestateApp.Application.Features.Projects.Commands.UpdateProject;
using Demo.RealestateApp.Application.Features.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Demo.RealestateApp.Application.Features.Projects.Queries.GetProjectsWithFilter;

namespace Demo.RealestateApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllProjects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjects()
        {
            var result = await _mediator.Send(new GetProjectsListQuery());
            return Ok(result);
        }

        [HttpGet("GetPriojectsWithFilterQuery", Name = "GetAllProjectsWithInputFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjectsWithInputFilter([FromQuery] GetProjectsWithFilterQuery input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }



        [HttpGet("{id}", Name = "GetProjectById")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(Guid id)
        {
            var result = new GetProjectQuery() { Id = id };
            return Ok(await _mediator.Send(result));
        }

        [HttpPost(Name = "AddProject")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectCommand createProjectCommand)
        {
            var id = await _mediator.Send(createProjectCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateProject")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProjectCommand updateProjectCommand)
        {
            await _mediator.Send(updateProjectCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteProject")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = new DeleteProjectCommand() { Id = id };
            await _mediator.Send(result);
            return NoContent();
        }
    }
}
