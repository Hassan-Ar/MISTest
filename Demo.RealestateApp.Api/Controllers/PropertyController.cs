using Demo.RealestateApp.Application.Features.Addresses;
using Demo.RealestateApp.Application.Features.Buildings.Queries;
using Demo.RealestateApp.Application.Features.Images;
using Demo.RealestateApp.Application.Features.Projects.Queries;
using Demo.RealestateApp.Application.Features.Projects.Queries.GetProjectsWithFilter;
using Demo.RealestateApp.Application.Features.Properties.Commands.CreateProperty;
using Demo.RealestateApp.Application.Features.Properties.Commands.DeleteProperty;
using Demo.RealestateApp.Application.Features.Properties.Commands.UpdateProperty;
using Demo.RealestateApp.Application.Features.Properties.Queries;
using Demo.RealestateApp.Application.Features.Properties.Queries.GetPropertiesWithFilter;
using Demo.RealestateApp.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.RealestateApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
  //  [Authorize]
    public class PropertyController : Controller
    {
        
        private readonly IMediator _mediator;
        public PropertyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(Name = "GetAllProperties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PropertyDto>>> GetAllProperties()
        {
            var result = await _mediator.Send(new GetPropertyListQuery());
            return Ok(result);
        }

        [HttpGet("GetPropertiesWithFilterQuery", Name = "GetAllPropertiesWithInputFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PropertyDto>>> GetAllPropertiesWithInputFilter([FromQuery] GetPropertiesWithFilterQuery input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }

        [HttpGet("{Buildingtid}", Name = "GetBuildingProperties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PropertiesBuildingDto>>> GetPropertiesBuildings(Guid Buildingtid)
        {
            var result = await _mediator.Send(new GetBuildingPropertiesListQuery() { BuildingID = Buildingtid });
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetPropertyById")]
        public async Task<ActionResult<PropertyDto>> GetPropertyById(Guid id)
        {
            var result = new GetPropertyQuery() { Id = id };
            return Ok(await _mediator.Send(result));
        }

        [HttpPost(Name = "AddProperty")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePropertyCommand createPropertyCommand)
        {
            var id = await _mediator.Send(createPropertyCommand);
            return Ok(id);
        }

      

        [HttpPut(Name = "UpdateProperty")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePropertyCommand updatePropertyCommand)
        {
            await _mediator.Send(updatePropertyCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteProperty")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = new DeletePropertyCommand() { Id = id };
            await _mediator.Send(result);
            return NoContent();
        }

    }
}
