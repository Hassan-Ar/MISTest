using Demo.RealestateApp.Application.Features.Buildings.Commands.CreateBuilding;
using Demo.RealestateApp.Application.Features.Buildings.Commands.DeleteBuilding;
using Demo.RealestateApp.Application.Features.Buildings.Commands.UpdateBuilding;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Application.Features.Projects.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Demo.RealestateApp.Application.Features.Buildings.Queries.GetBuildingsWithFilter;

namespace Demo.RealestateApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : Controller
    {
        private readonly IMediator _mediator;

        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllBuilding")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BuildingDto>>> GetAllBuildings()
        {
            var result = await _mediator.Send(new GetBuildingListQuery());
            return Ok(result);
        }
        [HttpGet("GetBuildingsWithFilterQuery", Name = "GetAllBuildingsWithInputFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BuildingDto>>> GetAllBuildingsWithInputFilter([FromQuery] GetBuildingsWithFilterQuery input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }




        [HttpGet("{Projectid}", Name = "GetProjectBuildings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BuildingDto>>> GetProjectBuildings(Guid Projectid)
        {
            var result = await _mediator.Send(new GetProjectBuildingsListQuery() { ProjectId = Projectid });
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetBuildingById")]
        public async Task<ActionResult<BuildingDto>> GetBuildingById(Guid id)
        {
            var result = new GetBuildingQuery() { Id = id };
            return Ok(await _mediator.Send(result));
        }

        [HttpPost(Name = "AddBuilding")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBuildingCommand createBuildingCommand)
        {
            var id = await _mediator.Send(createBuildingCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateBuilding")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBuildingCommand updateBuildingCommand)
        {
            await _mediator.Send(updateBuildingCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBuilding")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = new DeleteBuildingCommand() { Id = id };
            await _mediator.Send(result);
            return NoContent();
        }
    }
}
